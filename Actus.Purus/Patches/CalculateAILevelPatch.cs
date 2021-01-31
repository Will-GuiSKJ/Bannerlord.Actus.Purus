using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(AgentStatCalculateModel))]
    internal class CalculateAILevelPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("CalculateAILevel")]
        private static bool CalculateAILevelPrefix(AgentStatCalculateModel __instance, ref float __result, int relevantSkillLevel)
        {
            if (ModSettings.Settings.LogarithmicAICombatDifficulty.Enabled && relevantSkillLevel > 1)
            {
                var instanceType = __instance.GetType();
                var difficultyModifier = (float)instanceType.GetMethod("GetDifficultyModifier", BindingFlags.Instance | BindingFlags.Public).Invoke(__instance, null);
                var level = (float)Math.Pow(Math.Log(relevantSkillLevel, 350), 2) * difficultyModifier;
                __result = level < 0 ? 0f : level > 1 ? 1f : level;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}