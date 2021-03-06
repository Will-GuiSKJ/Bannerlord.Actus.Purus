﻿using Bannerlord.Actus.Purus.CustomEvents;
using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(FaceGenVM))]
    internal class CharacterPresetsPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(MethodType.Constructor, new Type[] { typeof(BodyGenerator), typeof(IFaceGeneratorHandler), typeof(Action<float>), typeof(Action), typeof(TextObject), typeof(TextObject), typeof(int), typeof(int), typeof(int), typeof(Action<int>), typeof(bool), typeof(bool), typeof(IFaceGeneratorCustomFilter) })]
        private static void ConstructorPostfix(FaceGenVM __instance)
        {
            var filter = __instance.GetType().GetField("_filter", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance);

            if (filter == null)
            {
                Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOn());

                Game.Current.EventManager.RegisterEvent(new Action<FaceGenVMCustomEventUpdate>(
                    (FaceGenVMCustomEventUpdate customEvent) =>
                    {
                        var bodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
                        var method = __instance.GetType().GetMethod("SetBodyProperties", BindingFlags.Public | BindingFlags.Instance);
                        method.Invoke(__instance, new object[] { bodyProperties, true, -1, true });
                    }
                ));
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("SelectedGender", MethodType.Setter)]
        private static void SelectedGenderPostfix(int value)
        {
            Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventGenderChanged(value));
        }

        [HarmonyPostfix]
        [HarmonyPatch("ExecuteCancel")]
        private static void ExecuteCancelPostfix()
        {
            Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOff());
        }

        [HarmonyPostfix]
        [HarmonyPatch("ExecuteDone")]
        private static void ExecuteDonePostfix()
        {
            Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOff());
        }
    }
}