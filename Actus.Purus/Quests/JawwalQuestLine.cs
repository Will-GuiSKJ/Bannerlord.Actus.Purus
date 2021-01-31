using Bannerlord.Actus.Purus.Dialogs;
using Bannerlord.Actus.Purus.Utils;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;
using QuestDialogs = Bannerlord.Actus.Purus.Dialogs.Quests.JawwalQuestLineDialogs;
using System.Linq;
using TaleWorlds.CampaignSystem.Actions;

namespace Bannerlord.Actus.Purus.Quests
{
    internal class JawwalQuestLine : QuestBase
    {
        [SaveableField(1)]
        private bool _metMerchant;

        [SaveableField(2)]
        private bool _merchantQuestAccepted;

        [SaveableField(3)]
        private bool _metJawwal;

        [SaveableField(4)]
        private bool _sidedWithJawwal;

        public override TextObject Title => QuestDialogs.Title.message;

        public override bool IsRemainingTimeHidden => false;

        public JawwalQuestLine(Hero questGiver) : base("actus.purus.jawwal_quest_line", questGiver, CampaignTime.DaysFromNow(30), 0)
        {
            SetDialogs();
        }

        protected override void InitializeQuestOnGameLoad()
        {
            SetDialogs();
            Logger.Log($"Actus Purus: JawwalQuestLine loaded with _metMerchant({_metMerchant})");
        }

        protected override void SetDialogs()
        {
            SetMerchantDialog();
            SetJawwalDialog();
        }

        protected override void OnStartQuest()
        {
            var log = QuestDialogs.QuestStartedLog.message;
            log.SetTextVariable("QuestGiverName", QuestGiver.Name);
            log.SetTextVariable("SettlementName", QuestGiver.CurrentSettlement.Name);
            AddLog(log);
        }

        protected override void OnTimedOut()
        {
            var log = QuestDialogs.QuestTimedOutLog.message;
            log.SetTextVariable("QuestGiverName", QuestGiver.Name);
            log.SetTextVariable("IsMale", QuestGiver.IsFemale ? 0 : 1);
            AddLog(log);
        }

        private void SetMerchantDialog()
        {
            string questOptionsToken;
            var dialogFlowStart = DialogFlow.CreateDialogFlow(DialogTokenShortcuts.mainOptions)
                .PlayerLine(QuestDialogs.PlayerAsksMerchantForQuest.message)
                    .Condition(() => Hero.OneToOneConversationHero != null && Hero.OneToOneConversationHero == QuestGiver && !_metMerchant)
                    .Consequence(() => _metMerchant = true)
                .NpcLine(QuestDialogs.MerchantInitialResponse1.message)
                .NpcLine(QuestDialogs.MerchantInitialResponse2.message)
                    .GetOutputToken(out questOptionsToken)
                .BeginPlayerOptions()
                    .PlayerOption(QuestDialogs.PlayerQuestInformationOption1.message)
                        .NpcLine(QuestDialogs.MerchantQuestInformationOption1Response.message)
                        .GotoDialogState(questOptionsToken)
                    .PlayerOption(QuestDialogs.PlayerQuestInformationOption2.message)
                        .NpcLine(QuestDialogs.MerchantQuestInformationOption2Response1.message)
                        .NpcLine(QuestDialogs.MerchantQuestInformationOption2Response2.message)
                        .GotoDialogState(questOptionsToken)
                    .PlayerOption(QuestDialogs.PlayerAcceptQuest.message)
                        .Consequence(MerchantDialogConsequence)
                .EndPlayerOptions()
                .CloseDialog();

            var dialogFlowEnd = DialogFlow.CreateDialogFlow(DialogTokenShortcuts.mainOptions)
                .PlayerLine(QuestDialogs.PlayerReturnsToMerchant.message)
                    .Condition(() => Hero.OneToOneConversationHero != null && Hero.OneToOneConversationHero == QuestGiver && _metMerchant)
                .NpcLine(QuestDialogs.MerchantQueryOnCompletion.message)
                .PlayerLine(QuestDialogs.PlayerNotCompletedResponse.message)
                    .Condition(() => !hasJawwalPrisonersCondition())
                    .CloseDialog()
                .PlayerLine(QuestDialogs.PlayerReadyToSideWithMerchant.message)
                    .Condition(() => hasJawwalPrisonersCondition())
                    .NpcLine(QuestDialogs.MerchantInitialOffer.message)
                    .BeginPlayerOptions()
                        .PlayerOption("You'll have to do better than that - ADD PERSUASION FLOW HERE.")
                            .ClickableCondition(ClickableConditionTest)
                        .PlayerOption(QuestDialogs.PlayerAcceptedOffer.message)
                            .Consequence(EndQuestBySidingWithMerchantConsequence)
                            .CloseDialog()
                    .EndPlayerOptions();

            Campaign.Current.ConversationManager.AddDialogFlow(dialogFlowStart, this);
            Campaign.Current.ConversationManager.AddDialogFlow(dialogFlowEnd, this);
        }

        private void MerchantDialogConsequence()
        {
            _merchantQuestAccepted = true;
            var log = QuestDialogs.QuestAcceptedLog.message;
            log.SetTextVariable("QuestGiverName", QuestGiver.Name);
            AddLog(log);
        }

        private bool hasJawwalPrisonersCondition()
        {
            return GetJawwalPrisoners().Count > 0;
        }

        private bool ClickableConditionTest(out TextObject explanation)
        {
            explanation = new TextObject("Testing clickable condition");
            return false;
        }

        private void EndQuestBySidingWithMerchantConsequence()
        {
            var garrisonParty = QuestGiver.CurrentSettlement.Town.GarrisonParty;
            var jawwalPrisoners = GetJawwalPrisoners();
            var reward = 0;
            foreach (var prisoner in jawwalPrisoners)
            {
                garrisonParty.AddPrisoner(prisoner, 1);
                EnterSettlementAction.ApplyForPrisoner(prisoner.HeroObject, QuestGiver.CurrentSettlement);
                CampaignEvents.Instance.OnPlayerDonatedHeroPrisoner(prisoner.HeroObject, QuestGiver.CurrentSettlement);
                reward += 1000;
            }

            Hero.MainHero.ChangeHeroGold(reward);
            ChangeRelationAction.ApplyPlayerRelation(QuestGiver, 50);
            CompleteQuestWithSuccess();
        }

        private List<CharacterObject> GetJawwalPrisoners()
        {
            var playerParties = new List<PartyBase>(Hero.MainHero.OwnedParties);
            var playerPrisoners = new List<CharacterObject>(playerParties[0].PrisonerHeroes());
            var jawwalPrisoners = playerPrisoners.FindAll(c => c.HeroObject.Clan.StringId == "jawwal");
            return jawwalPrisoners;
        }

        private void SetJawwalDialog()
        {
            QuestDialogs.PlayerMeetsJawwal.message.SetTextVariable("SettlementName", QuestGiver.CurrentSettlement.Name);
            QuestDialogs.JawwalMeetingResponse.message.SetTextVariable("QuestGiverName", QuestGiver.Name);

            var dialogFlowStart = DialogFlow.CreateDialogFlow(DialogTokenShortcuts.mainOptions)
                .PlayerLine(QuestDialogs.PlayerMeetsJawwal.message)
                    .Condition(() => Hero.OneToOneConversationHero != null && _merchantQuestAccepted && !_metJawwal && GetAllJawwalHeroes().Contains(Hero.OneToOneConversationHero.CharacterObject))
                    .Consequence(() => _metJawwal = true)
                .NpcLine(QuestDialogs.JawwalMeetingResponse.message)
                .BeginPlayerOptions()
                    .PlayerOption(QuestDialogs.PlayerAttacksJawwal.message)
                        .CloseDialog()
                .EndPlayerOptions();

            var dialogFlowEnd = DialogFlow.CreateDialogFlow(DialogTokenShortcuts.mainOptions);

            Campaign.Current.ConversationManager.AddDialogFlow(dialogFlowStart, this);
            Campaign.Current.ConversationManager.AddDialogFlow(dialogFlowEnd, this);
        }

        private List<CharacterObject> GetAllJawwalHeroes()
        {
            var jawwalHeroes = new List<CharacterObject>(CharacterObject.All.Where(c => c.IsHero && c.HeroObject?.Clan?.StringId == "jawwal"));
            return jawwalHeroes;
        }
    }
}