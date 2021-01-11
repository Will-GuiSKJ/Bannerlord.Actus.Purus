using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel))]
    internal class CavalryWorldMapSpeedPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("GetCavalryRatioModifier")]
        private static bool GetCavalryRatioModifierPatch(ref float __result, MobileParty party, int totalMenCount, int totalCavalryCount)
        {
            if (ModSettings.Settings.CavalrySpeedModifiers.Enabled)
            {
                if (totalMenCount == 0)
                    __result = 0.0f;
                var bonuses = new ExplainedNumber(ModSettings.Settings.CavalrySpeedModifiers.CavalryRatioModifier);
                if (!ModSettings.Settings.CavalrySpeedModifiers.DisableKhuzaitRacialBonus)
                    PerkHelper.AddFeatBonusForPerson(DefaultFeats.Cultural.KhuzaitCavalryAgility, party.Leader, ref bonuses);
                __result = bonuses.ResultNumber * (float)totalCavalryCount / (float)totalMenCount;
                return false;
            }
            else
                return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch("GetMountedFootmenRatioModifier")]
        private static bool GetMountedFootmenRatioModifier(ref float __result, int totalMenCount, int totalCavalryCount)
        {
            if (ModSettings.Settings.CavalrySpeedModifiers.Enabled)
            {
                __result = totalMenCount == 0 ? 0.0f : ModSettings.Settings.CavalrySpeedModifiers.MountedFootmenRatioModifier * (float)totalCavalryCount / (float)totalMenCount;
                return false;
            }
            else
                return true;
        }
    }
}