using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

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
                }
                /*if (tutorialContextChangedEvent.NewContext == TutorialContexts.InventoryScreen)
                {
                    if (ScreenManager.TopScreen is InventoryGauntletScreen)
                    {
                        _inventoryScreen = ScreenManager.TopScreen as InventoryGauntletScreen;
                        Inventory = _inventoryScreen.GetField("_dataSource") as SPInventoryVM;

                        this._mainLayer = new MainLayer(1000, "GauntletLayer");
                        _inventoryScreen.AddLayer(this._mainLayer);
                        this._mainLayer.InputRestrictions.SetInputRestrictions(true, InputUsageMask.All);

                        _filterLayer = new FilterLayer(1001, "GauntletLayer");
                        _inventoryScreen.AddLayer(this._filterLayer);
                        this._filterLayer.InputRestrictions.SetInputRestrictions(true, InputUsageMask.All);
                    }
                }*/
            }
            catch (MBException e)
            {
                InformationManager.DisplayMessage(new InformationMessage(e.Message));
            }
        }

        public override void SyncData(IDataStore dataStore) { }
    }
}
