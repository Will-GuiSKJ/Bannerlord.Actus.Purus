﻿using Bannerlord.Actus.Purus.CustomEvents;
using Bannerlord.Actus.Purus.Screens;
using Bannerlord.Actus.Purus.Utils;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;

namespace Bannerlord.Actus.Purus.Behaviors
{
    public class CharacterGenPresetBehavior : CampaignBehaviorBase
    {
        private GauntletLayer _layer;

        public override void RegisterEvents()
        {
            if (ModSettings.Settings.EnableCharacterGenPresets)
            {
                Game.Current.EventManager.RegisterEvent(new Action<FaceGenVMCustomEventOn>(AddLayer));
                Game.Current.EventManager.RegisterEvent(new Action<FaceGenVMCustomEventOff>(RemoveLayer));
            }
        }

        private void AddLayer(FaceGenVMCustomEventOn customEvent)
        {
            _layer = new CharacterGenPresetLayer(10);
            ScreenManager.TopScreen.AddLayer(_layer);
        }

        private void RemoveLayer(FaceGenVMCustomEventOff customEvent)
        {
            if (_layer != null)
            {
                ScreenManager.TopScreen?.RemoveLayer(_layer);
                _layer = null;
            }
        }

        public override void SyncData(IDataStore dataStore) { }
    }
}