using Bannerlord.Actus.Purus.Loaders;
using Bannerlord.Actus.Purus.Models;
using Bannerlord.Actus.Purus.Quests;
using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.Actus.Purus
{
    public class Start : MBSubModuleBase
    {
        Settings settings;
        public Start() : base()
        {
            settings = (new SettingsLoader()).settings;

            if (settings.DebugMode)
                Logger.debugMode = true;
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            if (!(game.GameType is StoryMode.CampaignStoryMode))
                return;

            var starter = (CampaignGameStarter)gameStarterObject;

            if (settings.EnableMinorFactionQuests)
            {
                starter.AddBehavior(new MinorFactionQuestGeneratorBehavior());
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            Logger.Log("Bannerlord Actus Purus has been loaded", true);
        }
    }
}
