using Bannerlord.Actus.Purus.CustomEvents;
using Bannerlord.Actus.Purus.Screens;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Behaviors
{
    internal class CharacterGenPresetBehavior : CampaignBehaviorBase
    {
        private GauntletLayer _layer;

        public override void RegisterEvents()
        {
            Game.Current.EventManager.RegisterEvent(new Action<FaceGenVMCustomEventOn>(AddLayer));
            Game.Current.EventManager.RegisterEvent(new Action<FaceGenVMCustomEventOff>(RemoveLayer));
        }

        private void AddLayer(FaceGenVMCustomEventOn customEvent)
        {
            _layer = new CharacterGenPresetLayer(10);
            ScreenManager.TopScreen.AddLayer(_layer);
            _layer.InputRestrictions.SetInputRestrictions(true, InputUsageMask.MouseButtons);
        }

        private void RemoveLayer(FaceGenVMCustomEventOff customEvent)
        {
            if (_layer != null)
            {
                ScreenManager.TopScreen?.RemoveLayer(_layer);
                _layer = null;
            }
        }

        public override void SyncData(IDataStore dataStore)
        {
        }
    }
}