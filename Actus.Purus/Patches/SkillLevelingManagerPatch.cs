using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment.Managers;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(SkillLevelingManager))]
    internal class SkillLevelingManagerPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("OnSettlementGoverned")]
        private static bool OnSettlementGovernedPatch(Hero governor)
        {
            if (ModSettings.Settings.EnablePlayerAsGovernor && governor != null && governor.StringId == Hero.MainHero.StringId)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch("OnSettlementSkillExercised")]
        private static bool OnSettlementSkillExercisedPatch(Settlement settlement)
        {
            if (ModSettings.Settings.EnablePlayerAsGovernor && settlement != null && settlement.Town?.Governor?.StringId == Hero.MainHero.StringId && Hero.MainHero.CurrentSettlement != settlement)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}