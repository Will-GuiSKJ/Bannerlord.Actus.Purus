using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetMaxWorkshopCountForPlayer))]
    class InitialWorkshopCountPatch
    {
        static void Postfix(ref int __result)
        {
            if (ModSettings.Settings.InitialWorkshopCount.Enabled)
                __result = ModSettings.Settings.InitialWorkshopCount.Value + Clan.PlayerClan.Tier;
        }
    }
}