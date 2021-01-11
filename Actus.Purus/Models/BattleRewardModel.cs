using Bannerlord.Actus.Purus.Utils;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace Bannerlord.Actus.Purus.Models
{
    internal class BattleRewardModel : DefaultBattleRewardModel
    {
        public override EquipmentElement GetLootedItemFromTroop(CharacterObject character, float targetValue)
        {
            var troopEquimentSet = character.AllEquipments.GetRandomElement<Equipment>();
            var reward = new EquipmentElement();
            var rewardChest = new List<EquipmentElement>();
            var equipmentIndexList = ShuffleEquipmentIndexes();
            var settings = ModSettings.Settings.EquipmentBattleReward;

            var rnd = new Random();
            foreach (var index in equipmentIndexList)
            {
                var equipment = troopEquimentSet.GetEquipmentFromSlot(index);
                if (equipment.Item != null && !equipment.Item.NotMerchandise && rnd.NextDouble() < settings.IndividualItemRewardChance)
                {
                    rewardChest.Add(equipment);
                }
            }

            var commonItemValueThreshold = GetRandomThreshold(settings.CommonItemValueThreshold);
            var uncommonItemValueThreshold = GetRandomThreshold(settings.UncommonItemValueThreshold, settings.CommonItemValueThreshold);
            var rareItemValueThreshold = GetRandomThreshold(settings.RareItemValueThreshold, settings.UncommonItemValueThreshold);
            foreach (var item in rewardChest)
            {
                if (item.ItemValue <= commonItemValueThreshold && rnd.NextDouble() < 0.5)
                {
                    reward = item;
                    break;
                }
                else if (item.ItemValue > settings.CommonItemValueThreshold && item.ItemValue <= uncommonItemValueThreshold && rnd.NextDouble() < 0.1)
                {
                    reward = item;
                    break;
                }
                else if (item.ItemValue > settings.UncommonItemValueThreshold && item.ItemValue <= rareItemValueThreshold && rnd.NextDouble() < 0.01)
                {
                    reward = item;
                    break;
                }
            }

            return reward;
        }

        private List<EquipmentIndex> ShuffleEquipmentIndexes()
        {
            var list = new List<EquipmentIndex>()
            {
                EquipmentIndex.Weapon0,
                EquipmentIndex.Weapon1,
                EquipmentIndex.Weapon2,
                EquipmentIndex.Weapon3,
                EquipmentIndex.Weapon4,
                EquipmentIndex.Head,
                EquipmentIndex.Cape,
                EquipmentIndex.Body,
                EquipmentIndex.Gloves,
                EquipmentIndex.Leg,
                EquipmentIndex.Horse,
                EquipmentIndex.HorseHarness
            };

            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        private int GetRandomThreshold(int maxValue, int minValue = 0)
        {
            var rnd = new Random();
            return (int)Math.Floor(Math.Abs(rnd.NextDouble() - rnd.NextDouble()) * (1 + maxValue - minValue) + minValue);
        }
    }
}

//https://gamedev.stackexchange.com/questions/116832/random-number-in-a-range-biased-toward-the-low-end-of-the-range