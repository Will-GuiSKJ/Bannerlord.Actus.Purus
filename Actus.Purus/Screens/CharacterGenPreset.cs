using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Screens
{
    public class CharacterGenPresetLayer : GauntletLayer
    {
        public CharacterGenPresetLayer(int localOrder) : base(localOrder)
        {
            var viewModel = new CharacterGenPresetViewModel();
            LoadMovie("CharacterGenPreset", viewModel);
        }
    }

    class CharacterGenPresetViewModel : ViewModel
    {
        [DataSourceProperty]
        public string PresetHint { get => "Click to toggle through the body presets"; }

        public void TogglePresets()
        {
            Utils.Logger.Log("TogglePresets");
        }

        public void ExecuteBeginHint()
        {
            Utils.Logger.Log("ExecuteBeginHint");
        }

        public override void RefreshValues()
        {
            base.RefreshValues();

            Utils.Logger.Log("RefreshValues");
        }
    }
}
