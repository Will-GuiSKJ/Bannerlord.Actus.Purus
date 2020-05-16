using Bannerlord.Actus.Purus.ViewModels;
using TaleWorlds.Engine.GauntletUI;

namespace Bannerlord.Actus.Purus.Layers
{
    class InventoryLayer : GauntletLayer
    {
        InventoryViewModel viewModel;

        public InventoryLayer(int localOrder, string categoryId = "GauntletLayer") : base(localOrder, categoryId)
        {
            viewModel = new InventoryViewModel();
            this.LoadMovie("ActusPurusInventory", viewModel);
        }
    }
}
