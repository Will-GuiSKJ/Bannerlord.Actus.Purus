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
            var rewardChest = new List<WeigthedItem>();

            var accumulatedChestValue = 0;
            var equipmentIndexList = ShuffleEquipmentIndexes();
            foreach (var index in equipmentIndexList)
            {
                var equipment = troopEquimentSet.GetEquipmentFromSlot(index);
                if (equipment.Item != null && !equipment.Item.NotMerchandise)
                {
                    var itemValue = equipment.ItemValue;
                    accumulatedChestValue += itemValue;
                    rewardChest.Add(new WeigthedItem(equipment, accumulatedChestValue));
                }
            }

            var rnd = new Random();
            var valueTarget = rnd.NextDouble() * accumulatedChestValue;
            foreach (var weigthedItem in rewardChest)
            {
                if (weigthedItem.cumulativeWeight >= valueTarget && DropCheck(weigthedItem.item.ItemValue))
                    return weigthedItem.item;
            }

            return new EquipmentElement();
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

        private bool DropCheck(int itemValue)
        {
            var cleanedItemValue = itemValue <= 0 ? 1 : itemValue;
            var chance = (float)cleanedItemValue / ModSettings.Settings.EquipmentBattleReward.ItemValueThreshold;
            if (chance > 1)
                chance = 1;

            var rnd = new Random();
            return rnd.NextDouble() >= chance;
        }

        internal class WeigthedItem
        {
            public int cumulativeWeight;
            public EquipmentElement item;

            public WeigthedItem(EquipmentElement _item, int _weight)
            {
                item = _item;
                cumulativeWeight = _weight;
            }
        }
    }
}
