using Bannerlord.Actus.Purus.Dialogs.RogueryBandit;
using Bannerlord.Actus.Purus.Utils;
using Helpers;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Core;
using static TaleWorlds.CampaignSystem.ConversationSentence;

namespace Bannerlord.Actus.Purus.Behaviors
{
    internal class BanditInteractionBehavior : CampaignBehaviorBase
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
            MobileParty.MainParty.MemberRoster.AddToCounts(Hero.MainHero.Clan.BasicTroop, 15);
            Hero.MainHero.SetSkillValue(DefaultSkills.Roguery, 80);

            starter.AddPlayerLine(BanditRecruitStart.Id, BanditRecruitStart.entry, BanditRecruitStart.next, BanditRecruitStart.message, BanditInteractionEntryCondition, null);
            starter.AddPlayerLine(BanditRecruitOffer.Id, BanditRecruitOffer.entry, BanditRecruitOffer.next, BanditRecruitOffer.message, null, null);
            starter.AddDialogLine(BanditRecruitQuestion.Id, BanditRecruitQuestion.entry, BanditRecruitQuestion.next, BanditRecruitQuestion.message, null, null);
            starter.AddPlayerLine(BanditRecruitAnswer.Id, BanditRecruitAnswer.entry, BanditRecruitAnswer.next, BanditRecruitAnswer.message, null, null);

            starter.AddDialogLine(BanditRecruitOfferBestResponse.Id, BanditRecruitOfferBestResponse.entry, BanditRecruitOfferBestResponse.next, BanditRecruitOfferBestResponse.message, TotalAssimilationCheck, new OnConsequenceDelegate(BanditInteractionPositiveConsequence));
            starter.AddDialogLine(BanditRecruitOfferOKResponse.Id, BanditRecruitOfferOKResponse.entry, BanditRecruitOfferOKResponse.next, BanditRecruitOfferOKResponse.message, PartialAssimilationCheck, new OnConsequenceDelegate(BanditInteractionPositiveConsequence));
        }

        private bool BanditInteractionEntryCondition()
        {
            var strengthCheck = PartyBaseHelper.DoesSurrenderIsLogicalForParty(MobileParty.ConversationParty, MobileParty.MainParty, 0.5f);
            var rogueCheck = Hero.MainHero.GetSkillValue(DefaultSkills.Roguery) > 50;
            return strengthCheck && rogueCheck;
        }

        private bool TotalAssimilationCheck()
        {
            var assimilationRatio = AssimilationRation();
            return assimilationRatio > 0.9;
        }

        private bool PartialAssimilationCheck() => !TotalAssimilationCheck();

        private void BanditInteractionPositiveConsequence()
        {
            var banditParty = MobileParty.ConversationParty;
            var partyToLoot = new PartyBase(banditParty);
            var assimilationRatio = AssimilationRation();
            var maxUnits = (int)Math.Ceiling(banditParty.Party.NumberOfAllMembers * assimilationRatio);
            var assimilatedUnits = 0;
            Logger.Log($"Bandits: {assimilationRatio} {maxUnits}");

            for (var i = 0; i < banditParty.MemberRoster.Count; i++)
            {
                var member = banditParty.MemberRoster.GetCharacterAtIndex(i);
                if (!member.IsHero)
                {
                    var memberUnitCount = banditParty.MemberRoster.GetElementNumber(i);
                    var numberOfUnitsToAdd = Math.Min(memberUnitCount, maxUnits - assimilatedUnits);

                    partyToLoot.AddMember(member, numberOfUnitsToAdd);
                    banditParty.MemberRoster.RemoveTroop(member, numberOfUnitsToAdd);

                    assimilatedUnits += numberOfUnitsToAdd;
                }
            }
            for (var i = 0; i < banditParty.PrisonRoster.Count; i++)
            {
                var prisoner = banditParty.PrisonRoster.GetCharacterAtIndex(i);
                if (!prisoner.IsHero)
                    partyToLoot.AddMember(prisoner, banditParty.PrisonRoster.GetElementNumber(i));
            }

            PartyScreenManager.OpenScreenAsLoot(partyToLoot);
            PlayerEncounter.LeaveEncounter = true;

            if (banditParty.Party.NumberOfAllMembers <= 0)
            {
                DestroyPartyAction.Apply(MobileParty.MainParty.Party, banditParty);
            }
        }

        private float AssimilationRation()
        {
            var powerRatio = (float)Math.Min(1, MobileParty.ConversationParty.Party.TotalStrength / MobileParty.MainParty.Party.TotalStrength + 0.5);
            var skillRatio = (float)Math.Min(1, Hero.MainHero.GetSkillValue(DefaultSkills.Roguery) / 200);
            var assimilationRatio = powerRatio * skillRatio;
            return assimilationRatio;
        }
    }
}