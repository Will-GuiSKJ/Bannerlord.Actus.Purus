using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace Bannerlord.Actus.Purus.Models
{
    internal class ClanTierModel : DefaultClanTierModel
    {
        public override int GetPartyLimitForTier(Clan clan, int clanTierToCheck)
        {
            if (clan.StringId == Clan.PlayerClan.StringId && ModSettings.Settings.InitialPartyCount.Enabled)
                return ModSettings.Settings.InitialPartyCount.Value + clanTierToCheck;
            else
                return base.GetPartyLimitForTier(clan, clanTierToCheck);
        }

        public override int GetCompanionLimit(Clan clan)
        {
            if (clan.StringId == Clan.PlayerClan.StringId && ModSettings.Settings.InitialCompanionCount.Enabled)
            {
                var baseLimit = ModSettings.Settings.InitialCompanionCount.Value + clan.Tier;
                ExplainedNumber explainedNumber = new ExplainedNumber((float)baseLimit);
                if (clan.Leader.GetPerkValue(DefaultPerks.Leadership.WePledgeOurSwords))
                    explainedNumber.Add(DefaultPerks.Leadership.WePledgeOurSwords.PrimaryBonus);
                return (int)explainedNumber.ResultNumber;
            }
            else
                return base.GetCompanionLimit(clan);
        }
    }
}