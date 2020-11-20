using Bannerlord.Actus.Purus.Loaders;
using Bannerlord.Actus.Purus.Models;
using Bannerlord.Actus.Purus.Quests;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.Actus.Purus
{
    public class Start : MBSubModuleBase
    {
        Settings settings;
        public Start() : base()
        {
            settings = (new SettingsLoader()).settings;
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            if (!(game.GameType is StoryMode.CampaignStoryMode))
                return;

            var starter = (CampaignGameStarter)gameStarterObject;
            starter.AddBehavior(new ExampleBehavior());
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            InformationManager.DisplayMessage(new InformationMessage("Bannerlord Actus Purus has been loaded", Color.ConvertStringToColor("#00FFD700")));
        }
    }
}
