using Bannerlord.Actus.Purus.Reports;
using Bannerlord.Actus.Purus.Utils;
using System;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.Actus.Purus.Behaviors
{
    internal class GarrisonRecruitmentBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.AfterDailyTickEvent.AddNonSerializedListener(this, OnDailyTick);
        }

        private void OnDailyTick()
        {
            var settlements = ModSettings.Settings.GarrisonRecruitment.EnabledForAI ? Settlement.All : Hero.MainHero.Clan.Settlements;
            foreach (var settlement in settlements)
            {
                if (CheckEligibility(settlement))
                {
                    var dailyNumberOfRecruits = (int)Math.Ceiling(ModSettings.Settings.GarrisonRecruitment.DailyNumberOfRecruits);
                    var garrisonSizeLimit = Campaign.Current.Models.PartySizeLimitModel.GetPartyMemberSizeLimit(settlement.Town.GarrisonParty.Party);
                    var currentGarrisonSize = settlement.Town.GarrisonParty.MemberRoster.TotalManCount;

                    var numberOfTroopsToAdd = (int)Math.Min(dailyNumberOfRecruits, garrisonSizeLimit.ResultNumber - currentGarrisonSize);
                    var troop = GetTroopToAdd(settlement);
                    if (troop != null)
                    {
                        settlement.Town.GarrisonParty.MemberRoster.AddToCounts(troop, numberOfTroopsToAdd);
                        if (settlement.OwnerClan.Leader.StringId == Hero.MainHero.StringId)
                            Logger.Log($"{numberOfTroopsToAdd} {troop.Name} were added to {settlement.Name}'s guarrison", true);

                        if (ModSettings.Settings.DebugMode)
                        {
                            GarrisonRecruitmentReport.AddEntry(settlement, troop, numberOfTroopsToAdd);
                        }
                    }
                    else
                        Logger.Log($"{settlement.Culture.Name} or {settlement.OwnerClan.Culture} have missing troop data");
                }
            }
        }

        private bool CheckEligibility(Settlement settlement)
        {
            if (settlement == null || !(settlement.IsTown || settlement.IsCastle) || settlement.OwnerClan == null || settlement.Town.GarrisonParty == null)
                return false;

            var isPlayerSettlement = settlement.OwnerClan.Leader.StringId == Hero.MainHero.StringId;
            var isEnabled = (isPlayerSettlement && ModSettings.Settings.GarrisonRecruitment.EnabledForPlayer) || (!isPlayerSettlement && ModSettings.Settings.GarrisonRecruitment.EnabledForAI);
            if (!isEnabled)
                return false;

            if (ModSettings.Settings.GarrisonRecruitment.DailyNumberOfRecruits < 1)
            {
                var rand = new Random();
                var flip = rand.NextDouble();
                if (flip >= ModSettings.Settings.GarrisonRecruitment.DailyNumberOfRecruits)
                    return false;
            }

            return true;
        }

        private CharacterObject GetTroopToAdd(Settlement settlement)
        {
            var isOwnerCultureTroop = (new Random()).NextDouble() < ModSettings.Settings.GarrisonRecruitment.RatioOfOwnerCultureTroops;
            var isNobleTroop = (new Random()).NextDouble() < ModSettings.Settings.GarrisonRecruitment.ChanceToSpawnNobleTroop;

            CharacterObject troop;
            if (isOwnerCultureTroop)
            {
                if (isNobleTroop)
                    troop = settlement.OwnerClan.Culture.EliteBasicTroop;
                else
                    troop = settlement.OwnerClan.Culture.BasicTroop;
            }
            else
            {
                if (isNobleTroop)
                    troop = settlement.Culture.EliteBasicTroop;
                else
                    troop = settlement.Culture.BasicTroop;
            }

            return troop;
        }

        public override void SyncData(IDataStore dataStore)
        {
        }
    }
}