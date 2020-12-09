using Bannerlord.Actus.Purus.Dialogs.MinorFactionTroopRecruitment;
using Bannerlord.Actus.Purus.Utils;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace Bannerlord.Actus.Purus.Behaviors
{
    class MinorFactionTroopRecruitmentBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
        }

        public override void SyncData(IDataStore dataStore) { }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            Logger.Log("ActusPurus: Minor Faction Troop Recruitment activated");
            starter.AddPlayerLine(MinorFactionTroopRecruitmentQuery.Id, MinorFactionTroopRecruitmentQuery.entry, MinorFactionTroopRecruitmentQuery.next, MinorFactionTroopRecruitmentQuery.message, () => Hero.OneToOneConversationHero.IsMinorFactionHero, null);

            // Main Flow
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponsePositive.Id, MinorFactionTroopRecruitmentResponsePositive.entry, MinorFactionTroopRecruitmentResponsePositive.next, MinorFactionTroopRecruitmentResponsePositive.message, RecruitmentCondition, null);
            starter.AddPlayerLine(MinorFactionTroopRecruitmentAgreement.Id, MinorFactionTroopRecruitmentAgreement.entry, MinorFactionTroopRecruitmentAgreement.next, MinorFactionTroopRecruitmentAgreement.message, null, null);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseSuccess.Id, MinorFactionTroopRecruitmentResponseSuccess.entry, MinorFactionTroopRecruitmentResponseSuccess.next, MinorFactionTroopRecruitmentResponseSuccess.message, null, RecruitmentConsequence);

            // Player Cancel Flow
            starter.AddPlayerLine(MinorFactionTroopRecruitmentDecline.Id, MinorFactionTroopRecruitmentDecline.entry, MinorFactionTroopRecruitmentDecline.next, MinorFactionTroopRecruitmentDecline.message, null, null);

            // Negative Flows
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeRenown.Id, MinorFactionTroopRecruitmentResponseNegativeRenown.entry, MinorFactionTroopRecruitmentResponseNegativeRenown.next, MinorFactionTroopRecruitmentResponseNegativeRenown.message, LacksRenown, null);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeRelation.Id, MinorFactionTroopRecruitmentResponseNegativeRelation.entry, MinorFactionTroopRecruitmentResponseNegativeRelation.next, MinorFactionTroopRecruitmentResponseNegativeRelation.message, LacksRelationship, null);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.Id, MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.entry, MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.next, MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.message, HasRecruits, LowerRelationConsequence);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeNoMoney.Id, MinorFactionTroopRecruitmentResponseNegativeNoMoney.entry, MinorFactionTroopRecruitmentResponseNegativeNoMoney.next, MinorFactionTroopRecruitmentResponseNegativeNoMoney.message, LacksMoney, null);

        }

        private bool RecruitmentCondition()
        {
            return !LacksRenown() && !LacksRelationship() && !HasRecruits() && !LacksMoney();
        }

        private bool LacksRenown()
        {
            return (Hero.MainHero.Culture.StringId == Hero.OneToOneConversationHero.Culture.StringId && Hero.MainHero.Clan.Tier > 2) || Hero.MainHero.Clan.Tier > 3;
        }

        private bool LacksRelationship()
        {
            return Hero.OneToOneConversationHero.GetRelationWithPlayer() < 30;
        }

        private bool HasRecruits()
        {
            var playerParty = new List<PartyBase>(Hero.MainHero.OwnedParties)[0];
            var troops = new List<CharacterObject>(playerParty.MemberRoster.Troops);
            return troops.FindAll(troop => troop.StringId == GetRecruitUnitId()).Count > 10;
        }

        private bool LacksMoney()
        {
            return Hero.MainHero.Gold < 1000;
        }

        private string GetRecruitUnitId()
        {
            var troopId = "";
            var clanBaseTroop = Hero.OneToOneConversationHero.Clan.BasicTroop;

            if (clanBaseTroop != null)
            {
                troopId = clanBaseTroop.StringId;
            }
            else
            {
                var template = Hero.OneToOneConversationHero.Clan.DefaultPartyTemplate;
                CharacterObject troop = null;
                template.Stacks.ForEach(stack =>
                {
                    if (troop == null || troop.Tier > stack.Character.Tier)
                        troop = stack.Character;
                });
                troopId = troop.StringId;
            }

            return troopId;
        }

        private void RecruitmentConsequence()
        {
            MobileParty.MainParty.MemberRoster.AddToCounts(MBObjectManager.Instance.GetObject<CharacterObject>(GetRecruitUnitId()), 20);
        }

        private void LowerRelationConsequence()
        {
            Hero.OneToOneConversationHero.SetPersonalRelation(Hero.MainHero, -10);
            //Hero.OneToOneConversationHero.Clan.Leader.SetPersonalRelation(Hero.MainHero, -10);
        }
    }
}
