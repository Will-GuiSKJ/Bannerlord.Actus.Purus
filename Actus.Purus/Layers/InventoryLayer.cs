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
            LoadMovie("ActusPurusInventory", viewModel);
            viewModel.RefreshValues();
        }

        protected override void OnLateUpdate(float dt)
        {
            base.OnLateUpdate(dt);

            if (TaleWorlds.InputSystem.Input.IsKeyReleased(TaleWorlds.InputSystem.InputKey.LeftMouseButton))
            {
                viewModel.RefreshValues();
            }
        }
    }
}
