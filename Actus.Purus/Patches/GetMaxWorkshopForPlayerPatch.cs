using Bannerlord.Actus.Purus.Utils;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace Bannerlord.Actus.Purus.Patches
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetMaxWorkshopCountForPlayer))]
    class GetMaxWorkshopForPlayerPatch
    {
        static void Postfix(ref int __result)
        {
            __result = ModSettings.Settings.InitialWorkshopCount + Clan.PlayerClan.Tier;
        }
    }
}