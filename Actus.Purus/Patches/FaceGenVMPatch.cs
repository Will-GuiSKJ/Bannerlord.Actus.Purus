using Bannerlord.Actus.Purus.CustomEvents;
using HarmonyLib;
using System;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(FaceGenVM))]
    class FaceGenVMPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(MethodType.Constructor, new Type[] { typeof(BodyGenerator), typeof(IFaceGeneratorHandler), typeof(Action<float>), typeof(Action), typeof(TextObject), typeof(TextObject), typeof(int), typeof(int), typeof(int), typeof(Action<int>), typeof(bool), typeof(bool), typeof(IFaceGeneratorCustomFilter) })]
        static void ConstructorPostfix()
        {
            Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOn());
        }

        [HarmonyPostfix]
        [HarmonyPatch("OnTabClicked")]
        static void OnTabClickedPostfix(int index)
        {
            if (index == 0)
                Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOn());
            else
                Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOff());
        }

        [HarmonyPostfix]
        [HarmonyPatch("ExecuteCancel")]
        static void ExecuteCancelPostfix()
        {
            Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOff());
        }

        [HarmonyPostfix]
        [HarmonyPatch("ExecuteDone")]
        static void ExecuteDonePostfix()
        {
            Game.Current.EventManager.TriggerEvent(new FaceGenVMCustomEventOff());
        }
    }
}
