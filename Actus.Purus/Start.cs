using Bannerlord.Actus.Purus.Behaviors;
using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.Actus.Purus
{
    public class Start : MBSubModuleBase
    {
        public Start() : base()
        {
            if (ModSettings.Settings.DebugMode)
                Logger.debugMode = true;
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            if (!(game.GameType is StoryMode.CampaignStoryMode))
                return;

            var harmony = new Harmony("bannerlord.modding.actus.purus");
            harmony.PatchAll();

            var starter = (CampaignGameStarter)gameStarterObject;

            if (ModSettings.Settings.CharacterPresets.Enabled)
            {
                starter.AddBehavior(new CharacterGenPresetBehavior());
            }

            if (ModSettings.Settings.EnableBlankCharacterCreation)
            {
                starter.AddBehavior(new BlankCharacterCreationBehavior());
            }

            if (ModSettings.Settings.EnableMinorFactionTroopRecruitment)
            {
                starter.AddBehavior(new MinorFactionTroopRecruitmentBehavior());
            }

            if (ModSettings.Settings.EnableMinorFactionQuests)
            {
                starter.AddBehavior(new MinorFactionQuestGeneratorBehavior());
            }

            if (ModSettings.Settings.InitialPartyCount.Enabled)
            {
                starter.AddModel(new Models.ClanTierModel());
            }

            if (ModSettings.Settings.InitialWorkshopCount.Enabled)
            {
                starter.AddModel(new Models.WorkshopModel());
            }

            if (ModSettings.Settings.CraftingConfig.Enabled)
            {
                starter.AddModel(new Models.SmithingModel());
            }

            if (ModSettings.Settings.GarrisonRecruitment.EnabledForAI || ModSettings.Settings.GarrisonRecruitment.EnabledForPlayer)
            {
                starter.AddBehavior(new GarrisonRecruitmentBehavior());
            }

            if (ModSettings.Settings.EquipmentBattleReward.Enabled)
            {
                starter.AddModel(new Models.BattleRewardModel());
            }

            if (ModSettings.Settings.PassiveXPSettings.Enabled)
            {
                starter.AddBehavior(new PassiveXPBehavior());
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            Logger.Log("Bannerlord Actus Purus has been loaded", true);
        }
    }
}
