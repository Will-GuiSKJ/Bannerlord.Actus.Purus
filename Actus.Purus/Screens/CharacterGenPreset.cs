using Bannerlord.Actus.Purus.CustomEvents;
using Bannerlord.Actus.Purus.Utils;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Screens
{
    internal class CharacterGenPresetLayer : GauntletLayer
    {
        public CharacterGenPresetLayer(int localOrder) : base(localOrder)
        {
            var viewModel = new CharacterGenPresetViewModel();
            LoadMovie("CharacterGenPreset", viewModel);
        }
    }

    internal class CharacterGenPresetViewModel : ViewModel
    {
        private int _presetIndex = 0;
        private bool _isFemale = false;

        private HintViewModel _presetHint = new HintViewModel("Cycle through body presets");

        [DataSourceProperty]
        public HintViewModel PresetHint
        {
            get => _presetHint;
            set
            {
                if (value == _presetHint)
                    return;
                _presetHint = value;
                OnPropertyChangedWithValue(value, nameof(_presetHint));
            }
        }

        public CharacterGenPresetViewModel() : base()
        {
            Game.Current.EventManager.RegisterEvent(new Action<FaceGenVMCustomEventGenderChanged>(
                (FaceGenVMCustomEventGenderChanged customEvent) =>
                {
                    var oldIsFemale = _isFemale;
                    _isFemale = customEvent.Gender == 1;
                    if (_isFemale != oldIsFemale)
                    {
                        _presetIndex = 0;
                        TogglePresets();
                    }
                }
            ));
        }

        public void TogglePresets()
        {
            var previousPresetIndex = _presetIndex;
            var gender = _isFemale ? "Female" : "Male";
            Utils.Logger.Log($"{gender} Preset {_presetIndex}", true);

            string presetBodyProperties;
            if (_isFemale)
            {
                presetBodyProperties = ModSettings.Settings.CharacterPresets.FemalePresets[_presetIndex].ToString();
                _presetIndex++;
                if (_presetIndex > ModSettings.Settings.CharacterPresets.FemalePresets.Length - 1)
                    _presetIndex = 0;
            }
            else
            {
                presetBodyProperties = ModSettings.Settings.CharacterPresets.MalePresets[_presetIndex].ToString();
                _presetIndex++;
                if (_presetIndex > ModSettings.Settings.CharacterPresets.MalePresets.Length - 1)
                    _presetIndex = 0;
            }

            TaleWorlds.Core.BodyProperties bodyProperties;

            if (TaleWorlds.Core.BodyProperties.FromString(presetBodyProperties, out bodyProperties))
            {
                CharacterObject.PlayerCharacter.UpdatePlayerCharacterBodyProperties(bodyProperties, _isFemale);
                Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventUpdate());
            }
            else
                Utils.Logger.Log($"Actus Purus: Failed to generate BodyProperties for preset {previousPresetIndex}");
        }

        public override void RefreshValues()
        {
            base.RefreshValues();
            Utils.Logger.Log("CharacterGenPresetViewModel RefreshValues");
        }
    }
}