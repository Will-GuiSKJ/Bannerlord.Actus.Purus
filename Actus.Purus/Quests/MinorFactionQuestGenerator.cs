using Bannerlord.Actus.Purus.Dialogs.MinorFactionQuestStarter;
using Bannerlord.Actus.Purus.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace Bannerlord.Actus.Purus.Quests
{
    class MinorFactionQuestGeneratorBehavior : CampaignBehaviorBase
    {
        Hero questGiver;

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
        }

        public override void SyncData(IDataStore dataStore) { }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            Logger.Log("ActusPurus: Minor Faction Generator activated");
            starter.AddPlayerLine(TavernWorkQuery.Id, TavernWorkQuery.entry, TavernWorkQuery.next, TavernWorkQuery.message, null, null);
            starter.AddDialogLine(TavernWorkResponse.Id, TavernWorkResponse.entry, TavernWorkResponse.next, TavernWorkResponse.message, new ConversationSentence.OnConditionDelegate(NoQuestCheck), null);

            // Jawwal Questline
            starter.AddDialogLine(TavernWorkJawwalResponse1.Id, TavernWorkJawwalResponse1.entry, TavernWorkJawwalResponse1.next, TavernWorkJawwalResponse1.message, new ConversationSentence.OnConditionDelegate(JawwalCheck), null);
            starter.AddDialogLine(TavernWorkJawwalResponse2.Id, TavernWorkJawwalResponse2.entry, TavernWorkJawwalResponse2.next, TavernWorkJawwalResponse2.message, new ConversationSentence.OnConditionDelegate(JawwalResponse2Setup), new ConversationSentence.OnConsequenceDelegate(JawwalResponse2Consequence));
        }

        private bool NoQuestCheck()
        {
            return !JawwalCheck();
        }

        private bool JawwalCheck()
        {
            /*
             * town_ES1: Danustica
             * town_ES2: Vostrum
             * town_A2: Huns Fulq
             * town_A4: Razih
             */
            var correctTownCheck = (new List<string>() { "town_ES1", "town_ES2", "town_A2", "town_A4" }).Contains(Hero.MainHero.CurrentSettlement.StringId);
            var noDuplicateQuest = Campaign.Current.QuestManager.Quests.Any(q => q.GetType() == typeof(JawwalQuestLine)) == false;
            return correctTownCheck && noDuplicateQuest;
        }

        private bool JawwalResponse2Setup()
        {
            var townMerchants = new List<Hero>(Hero.MainHero.CurrentSettlement.Notables).FindAll(h => h.CharacterObject.Occupation == Occupation.Merchant);
            var pickedMerchantIndex = (new Random()).Next(0, townMerchants.Count);
            questGiver = townMerchants[pickedMerchantIndex];
            MBTextManager.SetTextVariable("MERCHANT", questGiver.Name);
            MBTextManager.SetTextVariable("GENDER_PRONOUN", questGiver.IsFemale ? "she" : "he");
            return true;
        }

        private void JawwalResponse2Consequence()
        {
            (new JawwalQuestLine(questGiver)).StartQuest();
        }
    }
}
