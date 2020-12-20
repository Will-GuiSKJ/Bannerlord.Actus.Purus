using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetPartyLimitForTier))]
    class GetPartyLimitForTierPatch
    {
        static void Postfix(Clan clan, int clanTierToCheck, ref int __result)
        {
            if (clan.StringId == Clan.PlayerClan.StringId)
                __result = ModSettings.Settings.InitialPartyCount + clanTierToCheck;
        }
    }
}