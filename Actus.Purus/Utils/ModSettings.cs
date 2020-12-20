using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Utils
{
    public static class ModSettings
    {
        private static Settings _settings;

        public static Settings Settings
        {
            get
            {
                if (_settings == null)
                    LoadSettings();

                return _settings;
            }
        }

        private static void LoadSettings()
        {
            StreamReader streamReader;
            string path = Path.Combine(BasePath.Name, "Modules", "ActusPurus", "Settings.xml");
            using (streamReader = new StreamReader(path))
            {
                var xmlReader = XmlReader.Create(streamReader);
                var serializer = new XmlSerializer(typeof(Settings));
                _settings = (Settings)serializer.Deserialize(xmlReader);
            }
        }
    }


    [Serializable()]
    public class Settings
    {
        public bool DebugMode { get; set; }
        public bool EnableCharacterGenPresets { get; set; }
        public bool EnableMinorFactionTroopRecruitment { get; set; }
        public bool EnableMinorFactionQuests { get; set; }
        public int InitialPartyCount { get; set; }
        public int InitialWorkshopCount { get; set; }
    }
}
