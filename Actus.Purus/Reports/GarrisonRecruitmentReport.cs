using System.Collections.Generic;
using System.IO;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Reports
{
    internal static class GarrisonRecruitmentReport
    {
        private static List<string> lines = new List<string>() { "Date,Year,Settlement Name,Settlement Culture,Owner Name,Owner Culture,Troop Added,Count" };

        public static void AddEntry(Settlement settlement, CharacterObject troop, int count)
        {
            lines.Add($"{CampaignTime.Now},{settlement.Name},{settlement.Culture.Name},{settlement.OwnerClan.Name},{settlement.OwnerClan.Culture.Name},{troop.Name},{count}");
        }

        public static void WriteReport()
        {
            if (lines.Count > 1)
            {
                var filepath = Path.Combine(BasePath.Name, "Modules", "ActusPurus", "GarrisonRecruitmentReport.csv");
                File.WriteAllLines(filepath, lines);
            }
        }
    }
}