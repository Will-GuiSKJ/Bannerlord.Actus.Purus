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

            if (ModSettings.Settings.EnableMinorFactionTroopRecruitment)
            {
                starter.AddBehavior(new MinorFactionTroopRecruitmentBehavior());
            }

            if (ModSettings.Settings.EnableCharacterGenPresets)
            {
                starter.AddBehavior(new CharacterGenPresetBehavior());
            }

            if (ModSettings.Settings.EnableMinorFactionQuests)
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
