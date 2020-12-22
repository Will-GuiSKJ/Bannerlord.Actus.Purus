using Bannerlord.Actus.Purus.Utils;
using System;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.Actus.Purus.Behaviors
{
    class BlankCharacterCreation : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.OnQuestStartedEvent.AddNonSerializedListener(this, new Action<QuestBase>(OnQuestStarted));
        }

        private void OnQuestStarted(QuestBase quest)
        {
            if (quest.StringId == "rebuild_player_clan_storymode_quest")
            {
                Hero.MainHero.HeroDeveloper.ClearHero();

                Hero.MainHero.HeroDeveloper.UnspentAttributePoints = 20;
                Hero.MainHero.HeroDeveloper.UnspentFocusPoints = 10;

                Logger.Log("Actus Purus - Main Hero Reset");
            }
        }

        public override void SyncData(IDataStore dataStore) { }
    }
}
