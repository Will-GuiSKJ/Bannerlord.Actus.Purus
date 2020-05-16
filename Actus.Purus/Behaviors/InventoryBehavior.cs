﻿using Bannerlord.Actus.Purus.Layers;
using SandBox.GauntletUI;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;

namespace Bannerlord.Actus.Purus.Behaviors
{
    class InventoryBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            Game.Current.EventManager.RegisterEvent(new Action<TutorialContextChangedEvent>(AddNewInventoryLayer));
        }

        private void AddNewInventoryLayer(TutorialContextChangedEvent tutorialContextChangedEvent)
        {
            try
            {
                if (tutorialContextChangedEvent.NewContext == TutorialContexts.InventoryScreen)
                {
                    InformationManager.DisplayMessage(new InformationMessage("Inventory Opened"));

                    if (ScreenManager.TopScreen is InventoryGauntletScreen)
                    {
                        var screen = ScreenManager.TopScreen as InventoryGauntletScreen;
                        var layer = new InventoryLayer(1000);
                        screen.AddLayer(layer);
                    }
                }
            }
            catch (MBException e)
            {
                InformationManager.DisplayMessage(new InformationMessage(e.Message));
            }
        }

        public override void SyncData(IDataStore dataStore) { }
    }
}