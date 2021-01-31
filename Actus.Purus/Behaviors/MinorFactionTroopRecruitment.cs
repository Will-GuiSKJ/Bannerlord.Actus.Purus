using Bannerlord.Actus.Purus.Dialogs.MinorFactionTroopRecruitment;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace Bannerlord.Actus.Purus.Behaviors
{
    internal class MinorFactionTroopRecruitmentBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
        }

        public override void SyncData(IDataStore dataStore)
        {
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            starter.AddPlayerLine(MinorFactionTroopRecruitmentQuery.Id, MinorFactionTroopRecruitmentQuery.entry, MinorFactionTroopRecruitmentQuery.next, MinorFactionTroopRecruitmentQuery.message.ToString(), () => Hero.OneToOneConversationHero.IsMinorFactionHero, null);

            // Main Flow
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponsePositive.Id, MinorFactionTroopRecruitmentResponsePositive.entry, MinorFactionTroopRecruitmentResponsePositive.next, MinorFactionTroopRecruitmentResponsePositive.message.ToString(), RecruitmentCondition, null);
            starter.AddPlayerLine(MinorFactionTroopRecruitmentAgreement.Id, MinorFactionTroopRecruitmentAgreement.entry, MinorFactionTroopRecruitmentAgreement.next, MinorFactionTroopRecruitmentAgreement.message.ToString(), null, null);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseSuccess.Id, MinorFactionTroopRecruitmentResponseSuccess.entry, MinorFactionTroopRecruitmentResponseSuccess.next, MinorFactionTroopRecruitmentResponseSuccess.message.ToString(), null, RecruitmentConsequence);

            // Player Cancel Flow
            starter.AddPlayerLine(MinorFactionTroopRecruitmentDecline.Id, MinorFactionTroopRecruitmentDecline.entry, MinorFactionTroopRecruitmentDecline.next, MinorFactionTroopRecruitmentDecline.message.ToString(), null, null);

            // Negative Flows
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeRenown.Id, MinorFactionTroopRecruitmentResponseNegativeRenown.entry, MinorFactionTroopRecruitmentResponseNegativeRenown.next, MinorFactionTroopRecruitmentResponseNegativeRenown.message.ToString(), LacksRenown, null);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeRelation.Id, MinorFactionTroopRecruitmentResponseNegativeRelation.entry, MinorFactionTroopRecruitmentResponseNegativeRelation.next, MinorFactionTroopRecruitmentResponseNegativeRelation.message.ToString(), LacksRelationship, null);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.Id, MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.entry, MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.next, MinorFactionTroopRecruitmentResponseNegativeAlreadyRecruited.message.ToString(), HasRecruits, LowerRelationConsequence);
            starter.AddDialogLine(MinorFactionTroopRecruitmentResponseNegativeNoMoney.Id, MinorFactionTroopRecruitmentResponseNegativeNoMoney.entry, MinorFactionTroopRecruitmentResponseNegativeNoMoney.next, MinorFactionTroopRecruitmentResponseNegativeNoMoney.message.ToString(), LacksMoney, null);
        }

        private bool RecruitmentCondition()
        {
            return !LacksRenown() && !LacksRelationship() && !HasRecruits() && !LacksMoney();
        }

        private bool LacksRenown()
        {
            return (Hero.MainHero.Culture.StringId == Hero.OneToOneConversationHero.Culture.StringId && Hero.MainHero.Clan.Tier < 2) || Hero.MainHero.Clan.Tier < 3;
        }

        private bool LacksRelationship()
        {
            return Hero.OneToOneConversationHero.GetRelationWithPlayer() < (int)Math.Floor(20 * OutlawModifier());
        }

        private float OutlawModifier()
        {
            if (Hero.OneToOneConversationHero.Clan.IsOutlaw)
            {
                return 1 - (MathF.Clamp(Hero.MainHero.GetSkillValue(DefaultSkills.Roguery) / 100.0f, 0, 0.75f));
            }
            else
                return 1;
        }

        private bool HasRecruits()
        {
            var troop = MBObjectManager.Instance.GetObject<CharacterObject>(GetRecruitUnitId());
            var count = 0;
            foreach (var party in Hero.MainHero.OwnedParties)
            {
                count += party.MemberRoster.GetTroopCount(troop);
            }
            return count > 0;
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
            GiveGoldAction.ApplyBetweenCharacters(Hero.MainHero, Hero.OneToOneConversationHero, 1000);
            MobileParty.MainParty.MemberRoster.AddToCounts(MBObjectManager.Instance.GetObject<CharacterObject>(GetRecruitUnitId()), 20);
            PlayerEncounter.LeaveEncounter = true;
        }

        private void LowerRelationConsequence()
        {
            ChangeRelationAction.ApplyPlayerRelation(Hero.OneToOneConversationHero, -5);
            PlayerEncounter.LeaveEncounter = true;
        }
    }
}