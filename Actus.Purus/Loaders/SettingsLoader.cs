using Bannerlord.Actus.Purus.Models;
using System.IO;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Loaders
{
    public class SettingsLoader : XmlLoader<Settings>
    {
        private string settingsPath = Path.Combine(BasePath.Name, "Modules", "ActusPurus", "ModuleData", "Settings.xml");
        public Settings settings;

        public SettingsLoader()
        {
            settings = Load(settingsPath);
        }

        public SettingsLoader(string alternatePath)
        {
            settingsPath = alternatePath;
            settings = Load(settingsPath);
        }
    }
}
