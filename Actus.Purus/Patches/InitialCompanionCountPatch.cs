using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using System.Reflection;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(Clan), nameof(Clan.CompanionLimit), MethodType.Getter)]
    class InitialCompanionCountPatch
    {
        static void Postfix(Clan __instance, ref int __result)
        {
            if (ModSettings.Settings.InitialCompanionCount.Enabled)
            {
                var instanceType = __instance.GetType();
                var clanLeader = (Hero)instanceType.GetField("_leader", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance);

                var isPlayerClan = clanLeader.StringId == Hero.MainHero.StringId;
                if (isPlayerClan)
                {
                    var clanTier = (int)instanceType.GetField("_tier", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance);
                    __result = ModSettings.Settings.InitialCompanionCount.Value + clanTier;
                }
            }
        }
    }
}