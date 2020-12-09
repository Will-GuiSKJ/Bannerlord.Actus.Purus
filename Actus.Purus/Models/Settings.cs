using System;

namespace Bannerlord.Actus.Purus.Models
{
    [Serializable()]
    public class Settings
    {
        public bool DebugMode { get; set; }
        public bool EnableMinorFactionTroopRecruitment { get; set; }
        public bool EnableMinorFactionQuests { get; set; }
    }
}
