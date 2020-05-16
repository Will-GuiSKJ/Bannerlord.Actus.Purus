using Bannerlord.Actus.Purus.ViewModels;
using TaleWorlds.Engine.GauntletUI;

namespace Bannerlord.Actus.Purus.Layers
{
    class InventoryLayer : GauntletLayer
    {
        public InventoryLayer(int localOrder, string categoryId = "GauntletLayer") : base(localOrder, categoryId)
        {
            this.LoadMovie("ActusPurusInventory", new InventoryViewModel());
        }
    }
}
