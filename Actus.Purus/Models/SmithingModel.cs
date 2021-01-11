using Bannerlord.Actus.Purus.Utils;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace Bannerlord.Actus.Purus.Models
{
    internal class SmithingModel : DefaultSmithingModel
    {
        public override int GetPartResearchGainForSmeltingItem(ItemObject item, Hero hero)
        {
            return (int)Math.Ceiling(base.GetPartResearchGainForSmeltingItem(item, hero) * ModSettings.Settings.CraftingConfig.PartResearchXPGainMultiplier);
        }

        public override int GetPartResearchGainForSmithingItem(ItemObject item, Hero hero)
        {
            return (int)Math.Ceiling(base.GetPartResearchGainForSmithingItem(item, hero) * ModSettings.Settings.CraftingConfig.PartResearchXPGainMultiplier);
        }

        public override int GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero)
        {
            return (int)Math.Floor(base.GetEnergyCostForRefining(ref refineFormula, hero) * ModSettings.Settings.CraftingConfig.StaminaCostMultiplier);
        }

        public override int GetEnergyCostForSmelting(ItemObject item, Hero hero)
        {
            return (int)Math.Floor(base.GetEnergyCostForSmelting(item, hero) * ModSettings.Settings.CraftingConfig.StaminaCostMultiplier);
        }

        public override int GetEnergyCostForSmithing(ItemObject item, Hero hero)
        {
            return (int)Math.Floor(base.GetEnergyCostForSmithing(item, hero) * ModSettings.Settings.CraftingConfig.StaminaCostMultiplier);
        }
    }
}