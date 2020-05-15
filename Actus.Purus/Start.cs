using Bannerlord.Actus.Purus.Behaviors;
using Bannerlord.Actus.Purus.Loaders;
using Bannerlord.Actus.Purus.Models;
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
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            try
            {
                base.OnGameStart(game, gameStarterObject);
                if (game.GameType is Campaign)
                {
                    CampaignGameStarter campaignStarter = (CampaignGameStarter)gameStarterObject;

                    if (settings.EnableEquipmentManagement)
                    {
                        campaignStarter.AddBehavior(new InventoryBehavior());
                    }
                }
                InformationManager.DisplayMessage(new InformationMessage("Actus Purus Loaded"));
            }
            catch (MBException e)
            {
                InformationManager.DisplayMessage(new InformationMessage("SubModule " + e.Message));
            }
        }
    }
}
