using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(CraftingCampaignBehavior))]
    class CraftingRecoveryRatePatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("HourlyTick")]
        static bool HourlyTickPrefix(CraftingCampaignBehavior __instance)
        {
            if (ModSettings.Settings.CraftingConfig.Enabled)
            {
                var instanceType = __instance.GetType();
                var craftingRecords = instanceType.GetField("_heroCraftingRecords", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance);
                var heroKeyCollection = craftingRecords.GetType().GetProperty("Keys", BindingFlags.Instance | BindingFlags.Public).GetValue(craftingRecords);
                var heroKeyCount = (int)heroKeyCollection.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public).GetValue(heroKeyCollection);
                var heroKeyArray = new Hero[heroKeyCount];
                heroKeyCollection.GetType().GetMethod("CopyTo", BindingFlags.Instance | BindingFlags.Public).Invoke(heroKeyCollection, new object[] { heroKeyArray, 0 });

                foreach (var heroKey in heroKeyArray)
                {
                    var tryGetValueParams = new object[] { heroKey, null };
                    var tryGetValueResult = craftingRecords.GetType().GetMethod("TryGetValue", BindingFlags.Instance | BindingFlags.Public).Invoke(craftingRecords, tryGetValueParams);
                    if ((bool)tryGetValueResult)
                    {
                        var heroCraftingRecord = tryGetValueParams[1];
                        var craftingStaminaField = heroCraftingRecord.GetType().GetField("CraftingStamina", BindingFlags.Instance | BindingFlags.Public);
                        var craftingStamina = (int)craftingStaminaField.GetValue(heroCraftingRecord);
                        if (craftingStamina < 100)
                        {
                            int recoveryRate;
                            if (heroKey.PartyBelongedTo?.CurrentSettlement != null)
                                recoveryRate = ModSettings.Settings.CraftingConfig.HourlySettlementStaminaRecoveryRate;
                            else
                                recoveryRate = ModSettings.Settings.CraftingConfig.HourlyMovingStaminaRecoveryRate;

                            craftingStaminaField.SetValue(heroCraftingRecord, Math.Min(100, craftingStamina + recoveryRate));
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
