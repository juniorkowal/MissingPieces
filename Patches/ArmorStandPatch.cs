using HarmonyLib;
using static PluginConfig;


namespace MissingPieces.Patches
{
    [HarmonyPatch(typeof(ArmorStand))]
    public static class ArmorStandPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(ArmorStand.SetPose))]
        static void SetPosePrefix(ref bool effect)
        {
            if (IsModEnabled.Value)
            {
                effect = false;
            }
        }
    }
}