using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using System.Reflection;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(Town))]
    internal class TownPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Governor", MethodType.Getter)]
        private static void GovernorGetterPatch(Town __instance, ref Hero __result)
        {
            if (ModSettings.Settings.EnablePlayerAsGovernor && __result == null)
            {
                var instanceType = __instance.GetType();
                var ownerClan = (Clan)instanceType.GetProperty("OwnerClan", BindingFlags.Instance | BindingFlags.Public).GetValue(__instance);
                if (ownerClan != null && ownerClan.StringId == Hero.MainHero.Clan.StringId)
                {
                    __result = Hero.MainHero;
                }
            }
        }
    }
}