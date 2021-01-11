using Bannerlord.Actus.Purus.Dialogs;
using Bannerlord.Actus.Purus.Utils;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace Bannerlord.Actus.Purus.Quests
{
    internal class JawwalQuestLine : QuestBase
    {
        [SaveableField(1)]
        private bool _metMerchant;

        [SaveableField(2)]
        private bool _merchantQuestAccpted;

        [SaveableField(3)]
        private Hero _metJawwal;

        public override TextObject Title => new TextObject("Beduin Trouble");

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
        }

        protected override void OnStartQuest()
        {
            AddLog(new TextObject($"Find {QuestGiver.Name} at {QuestGiver.CurrentSettlement.Name} and ask about the Jawwal problem."));
        }

        private void SetMerchantDialog()
        {
            string questOptionsToken;
            var dialogFlowStart = DialogFlow.CreateDialogFlow(DialogTokenShortcuts.mainOptions)
                .PlayerLine("I heard the Jawwal are praying upon your caravans. I may be able to help.")
                    .Condition(() => Hero.OneToOneConversationHero != null && Hero.OneToOneConversationHero == QuestGiver && !_metMerchant)
                    .Consequence(() => _metMerchant = true)
                .NpcLine("Those jackals hide behind their nomad ways so that they can pillage and plunder civilized folk!")
                .NpcLine("They have been raiding my caravans with impunity, lately. If you defeat even one of their rading parties and bring me its leader, I'll make you rich.")
                    .GetOutputToken(out questOptionsToken)
                .BeginPlayerOptions()
                    .PlayerOption("Why you? Have they targetd anyone else?")
                        .NpcLine("How would I know? All I can tell you is that I am bleeding denars because of them.")
                        .GotoDialogState(questOptionsToken)
                    .PlayerOption("Tell me more about the Jawwal.")
                        .NpcLine("Their name means Roamers, I think. What they are is simply disguised bandits.")
                        .NpcLine("They use the veil of their so called old ways to run around claiming territory and demanding tribute.")
                        .GotoDialogState(questOptionsToken)
                    .PlayerOption("Alright, consider it done.")
                        .Consequence(MerchantDialogConsequence)
                .EndPlayerOptions()
                .CloseDialog();

            var dialogFlowEnd = DialogFlow.CreateDialogFlow(DialogTokenShortcuts.mainOptions)
                .PlayerLine("About your Jawwal problem.")
                    .Condition(() => Hero.OneToOneConversationHero != null && Hero.OneToOneConversationHero == QuestGiver && _metMerchant)
                .NpcLine("I hope you are here to tell me you have one of the leaders of those Jackals with you.")
                .PlayerLine("No, not yet.")
                    .Condition(() => !hasJawwalPrisonersCondition())
                    .CloseDialog()
                .PlayerLine("I do, but it is going to cost you.")
                    .Condition(() => hasJawwalPrisonersCondition())
                    .NpcLine($"I'll pay you 1000{DialogIconShortcuts.gold} for each one you have brought me.")
                    .BeginPlayerOptions()
                        .PlayerOption("You'll have to do better than that - ADD PERSUASION FLOW HERE.")
                        .PlayerOption("Deal.")
                            .Consequence(EndQuestBySidingWithMerchantConsequence)
                            .CloseDialog()
                    .EndPlayerOptions();

            Campaign.Current.ConversationManager.AddDialogFlow(dialogFlowStart, this);
            Campaign.Current.ConversationManager.AddDialogFlow(dialogFlowEnd, this);
        }

        private void MerchantDialogConsequence()
        {
            _merchantQuestAccpted = true;
            AddLog(new TextObject($"{QuestGiver.Name} has asked you to defeat at least one of the Jawwal parties and bring the leader as a prisoner back."));
        }

        private bool hasJawwalPrisonersCondition()
        {
            var playerParties = new List<PartyBase>(Hero.MainHero.OwnedParties);
            var playerPrisoners = new List<CharacterObject>(playerParties[0].PrisonerHeroes());
            var jawwalPrisoners = playerPrisoners.FindAll(c => c.HeroObject.Clan.StringId == "jawwal");
            return jawwalPrisoners.Count > 0;
        }

        private void EndQuestBySidingWithMerchantConsequence()
        {
            var playerParties = new List<PartyBase>(Hero.MainHero.OwnedParties);
            var playerPrisoners = new List<CharacterObject>(playerParties[0].PrisonerHeroes());
            var jawwalPrisoners = playerPrisoners.FindAll(c => c.HeroObject.Clan.StringId == "jawwal");
            foreach (var prisoner in jawwalPrisoners)
            {
                //QuestGiver.HomeSettlement.
            }
        }
    }
}