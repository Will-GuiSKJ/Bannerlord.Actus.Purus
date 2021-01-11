using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace Bannerlord.Actus.Purus.Models
{
    public class WorkshopModel : DefaultWorkshopModel
    {
        public override int GetMaxWorkshopCountForPlayer()
        {
            return ModSettings.Settings.InitialWorkshopCount.Value + Clan.PlayerClan.Tier;
        }
    }
}