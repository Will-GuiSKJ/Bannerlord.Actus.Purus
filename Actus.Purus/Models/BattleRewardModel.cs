using Bannerlord.Actus.Purus.Utils;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace Bannerlord.Actus.Purus.Models
{
    class BattleRewardModel : DefaultBattleRewardModel
    {
        public override EquipmentElement GetLootedItemFromTroop(CharacterObject character, float targetValue)
        {
            var troopEquimentSet = character.AllEquipments.GetRandomElement<Equipment>();
            var reward = new EquipmentElement();
            var rewardChest = new List<EquipmentElement>();
            var equipmentIndexList = ShuffleEquipmentIndexes();

            foreach (var index in equipmentIndexList)
            {
                var equipment = troopEquimentSet.GetEquipmentFromSlot(index);
                if (equipment.Item != null && !equipment.Item.NotMerchandise)
                {
                    rewardChest.Add(equipment);
                }
            }

            var normalItemValueThreshold = GetRandomThreshold(ModSettings.Settings.EquipmentBattleReward.ItemValueThreshold);
            var rareItemValueThreshold = GetRandomThreshold(500000);
            foreach (var item in rewardChest)
            {
                if (item.ItemValue >= normalItemValueThreshold)
                {
                    if (item.ItemValue > ModSettings.Settings.EquipmentBattleReward.ItemValueThreshold && item.ItemValue > rareItemValueThreshold)
                        continue;

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

        private int GetRandomThreshold(int maxValue)
        {
            var rnd = new Random();
            return (int)Math.Floor(Math.Abs(rnd.NextDouble() - rnd.NextDouble()) * (1 + maxValue));
        }
    }
}

//https://gamedev.stackexchange.com/questions/116832/random-number-in-a-range-biased-toward-the-low-end-of-the-range