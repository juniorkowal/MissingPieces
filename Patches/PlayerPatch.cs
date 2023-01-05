﻿using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using static PluginConfig;
using static MissingPieces.MissingPiecesMain;


namespace MissingPieces.Patches
{
    [HarmonyPatch(typeof(Player))]
    static class PlayerPatch
    {
        [HarmonyTranspiler]
        [HarmonyPatch(nameof(Player.SetupPlacementGhost))]
        static IEnumerable<CodeInstruction> SetupPlacementGhostTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            return new CodeMatcher(instructions)
                .MatchForward(
                    useEnd: false,
                    new CodeMatch(OpCodes.Stsfld, AccessTools.Field(typeof(ZNetView), nameof(ZNetView.m_forceDisableInit))),
                    new CodeMatch(OpCodes.Ldarg_0),
                    new CodeMatch(OpCodes.Ldloc_0),
                    new CodeMatch(OpCodes.Call))
                .Advance(offset: 3)
                .SetInstructionAndAdvance(
                    Transpilers.EmitDelegate<Func<GameObject, GameObject>>(SetupPlacementGhostInstantiateDelegate))
                .InstructionEnumeration();
        }

        static GameObject SetupPlacementGhostInstantiateDelegate(GameObject selectedPrefab)
        {
            if (!IsModEnabled.Value)
            {
                return UnityEngine.Object.Instantiate(selectedPrefab);
            }

            bool setActive = false;

            if (selectedPrefab.GetComponent<MonsterAI>()
                || selectedPrefab.GetComponent<AnimalAI>()
                || selectedPrefab.GetComponent<Tameable>()
                || selectedPrefab.GetComponent<Ragdoll>()
                || selectedPrefab.GetComponent<Humanoid>())
            {
                setActive = selectedPrefab.activeSelf;
                selectedPrefab.SetActive(false);
            }

            GameObject clonedPrefab = UnityEngine.Object.Instantiate(selectedPrefab);

            if (!setActive)
            {
                return clonedPrefab;
            }

            selectedPrefab.SetActive(true);

            if (clonedPrefab.TryGetComponent(out MonsterAI monsterAi))
            {
                UnityEngine.Object.DestroyImmediate(monsterAi);
            }

            if (clonedPrefab.TryGetComponent(out AnimalAI animalAi))
            {
                UnityEngine.Object.DestroyImmediate(animalAi);
            }

            if (clonedPrefab.TryGetComponent(out Tameable tameable))
            {
                UnityEngine.Object.DestroyImmediate(tameable);
            }

            if (clonedPrefab.TryGetComponent(out Ragdoll ragdoll))
            {
                UnityEngine.Object.DestroyImmediate(ragdoll);
            }

            if (clonedPrefab.TryGetComponent(out Humanoid humanoid))
            {
                humanoid.m_defaultItems ??= Array.Empty<GameObject>();
                humanoid.m_randomWeapon ??= Array.Empty<GameObject>();
                humanoid.m_randomArmor ??= Array.Empty<GameObject>();
                humanoid.m_randomShield ??= Array.Empty<GameObject>();
                humanoid.m_randomSets ??= Array.Empty<Humanoid.ItemSet>();
            }

            clonedPrefab.SetActive(true);

            return clonedPrefab;
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(Player.CheckCanRemovePiece))]
        static bool CheckCanRemovePrefix(Player __instance, Piece piece, ref bool __result)
        {
            if (IsModEnabled.Value)
            {
                // Prevents world generated piece from player removal with build hammer.
                if (!piece.IsPlacedByPlayer() && IsCreatorShopPiece(piece))
                {
                    __result = false;
                    return false;
                }

                // Prevents player from breaking pottery barn pieces they didn't create themselves.
                if (IsCreatorShopPiece(piece) && !piece.IsCreator())
                {
                    __result = false;
                    return false;
                }

                // Enforces destruction by damage rather than build hammer.
                if (!IsDestructibleCreatorShopPiece(piece) && IsCreatorShopPiece(piece))
                {
                    __result = false;
                    return false;
                }
            }

            return true;
        }
    }
}