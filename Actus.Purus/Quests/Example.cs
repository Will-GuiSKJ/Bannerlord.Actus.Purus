using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Bannerlord.Actus.Purus.Quests
{
    public class ExampleBehavior : CampaignBehaviorBase
    {
        private string selectedOption;

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {

            starter.AddPlayerLine("test1_0", "tavernkeeper_talk", "test_query1", "I am testing dialog entries, do you have any advice?", new ConversationSentence.OnConditionDelegate(IsTavernKeeperCondition), null, 120);
            starter.AddDialogLine("test1_1", "test_query1", "test_response1", "Oh, that is a tough one, my friend. This system was not created to be easy...", null, null);
            starter.AddDialogLine("test1_2", "test_response1", "test_response2", "But I'll try to help if I can, what topic do you want to cover?", null, null);

            starter.AddPlayerLine("test2_0", "test_response2", "start", "Let's talk about how to handle a simple selection", null, new ConversationSentence.OnConsequenceDelegate(SimpleChoiceConsequence));
            starter.AddPlayerLine("test3_0", "test_response2", "test_query3", "How do you handle repeatable entries?", null, null);

            starter.AddDialogLine("test3_1", "test_query3", "test_response3", "Sure, pick away", null, new ConversationSentence.OnConsequenceDelegate(SetupRepeatableItemsConsequence));
            starter.AddRepeatablePlayerLine("test4_0", "test_response3", "test_query4", "{OPTION}", new ConversationSentence.OnConditionDelegate(GenerateOptionValueCondition), new ConversationSentence.OnConsequenceDelegate(HandleOptionSelectedConsequence));
            starter.AddPlayerLine("test5_1", "test_response3", "tavernkeeper_talk", "None of the above...", null, null);

            starter.AddDialogLine("test4_1", "test_query4", "test_response4", "Ah, I see you chose {OPTION}...\n*The Barkeep finishes cleaning a mug and gives you a wink*", new ConversationSentence.OnConditionDelegate(GenerateSavedOptionValueCondition), null);
            starter.AddDialogLine("test4_2", "test_response4", "test_response5", "I bet that keeping track of all those Ids, inputTokens and outputTokens is starting be a real pain now.", null, null);
            starter.AddPlayerLine("test5_0", "test_response5", "test_query5", "*Flustered, you respond*\nI don't want to talk about.", null, null);

            starter.AddDialogLine("test_end", "test_query5", "close_window", "Very well, come back to me when your head stops hurting", null, null);

            starter.AddPlayerLine("test6_0", "test_response2", "test_query6", "I would like to start an examplary quest", null, null);
            starter.AddDialogLine("test6_1", "test_query6", "close_window", "And so an exiting quest has started", null, new ConversationSentence.OnConsequenceDelegate(StartExampleQuestConsequence));
        }

        private bool IsTavernKeeperCondition() => CharacterObject.OneToOneConversationCharacter.Occupation == Occupation.Tavernkeeper;

        private void SimpleChoiceConsequence()
        {
            InformationManager.DisplayMessage(new InformationMessage("You have selected something simple"));
        }

        private void SetupRepeatableItemsConsequence()
        {
            List<string> itemTypes = new List<string>()
            {
                "Option A",
                "Option B",
                "Option C"
            };
            ConversationSentence.ObjectsToRepeatOver = itemTypes;
        }

        private bool GenerateOptionValueCondition()
        {
            var option = ConversationSentence.SelectedRepeatObject as string;
            //ConversationSentence.SelectedRepeatLine.SetTextVariable("OPTION", "Test");
            //MBTextManager.SetTextVariable("OPTION", option);
            Campaign.Current.ConversationManager.SetDialogLineVariable("OPTION", new TextObject(option));
            return true;
        }

        private void HandleOptionSelectedConsequence()
        {
            selectedOption = ConversationSentence.LastSelectedRepeatObject as string;
        }

        private bool GenerateSavedOptionValueCondition()
        {
            MBTextManager.SetTextVariable("OPTION", selectedOption);
            return true;
        }

        private void StartExampleQuestConsequence()
        {
            new ExampleQuest($"ExampleQuest_{CampaignTime.Now}", Hero.MainHero, CampaignTime.DaysFromNow(3)).StartQuest();
        }

        public override void SyncData(IDataStore dataStore)
        {
            throw new NotImplementedException();
        }
        public class ExampleBehaviorTypeDefiner : SaveableCampaignBehaviorTypeDefiner
        {
            private static int saveId = "FoS_ExampleQuest".GetHashCode();

            public ExampleBehaviorTypeDefiner() : base(saveId) { }

            protected override void DefineClassTypes()
            {
                AddClassDefinition(typeof(ExampleQuest), saveId);
            }
        }

        internal class ExampleQuest : QuestBase
        {
            public override TextObject Title => new TextObject("Example Quest");

            public override bool IsRemainingTimeHidden => false;

            public ExampleQuest(string questId, Hero questGiver, CampaignTime duration) : base(questId, questGiver, duration, 0)
            {
                SetQuest();
            }

            protected override void InitializeQuestOnGameLoad()
            {
                SetQuest();
            }

            private void SetQuest()
            {
                SetDialogs();
                SetListeners();
            }

            protected override void SetDialogs()
            {
                //throw new NotImplementedException();
            }

            private void SetListeners()
            {
                CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, OnDailyTick);
            }

            private void OnDailyTick()
            {
                AddLog(new TextObject("Another day has passed"));
            }
        }
    }
}
