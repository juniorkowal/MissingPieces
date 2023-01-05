using HarmonyLib;
using static PluginConfig;


namespace MissingPieces.Patches
{
    [HarmonyPatch(typeof(ZoneSystem))]
    public class ZoneSystemPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(ZoneSystem.Start))]
        static void StartPostfix(ref ZoneSystem __instance)
        {
            if (IsModEnabled.Value)
            {
                __instance.StartCoroutine(MissingPiecesMain.AddPieces());
            }
        }
    }
}