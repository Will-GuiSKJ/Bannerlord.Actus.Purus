using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace Bannerlord.Actus.Purus.Models
{
    class ClanTierModel : DefaultClanTierModel
    {
        public override int GetPartyLimitForTier(Clan clan, int clanTierToCheck)
        {
            if (clan.StringId == Clan.PlayerClan.StringId)
                return ModSettings.Settings.InitialPartyCount.Value + clanTierToCheck;
            else
                return base.GetPartyLimitForTier(clan, clanTierToCheck);
        }
    }
}