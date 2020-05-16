using Bannerlord.Actus.Purus.Models;
using System.IO;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Loaders
{
    public class SettingsLoader : XmlLoader<Settings>
    {
        public Settings settings;

        public SettingsLoader()
        {
            settings = Load(Path.Combine(BasePath.Name, "Modules", "ActusPurus", "ModuleData", "Settings.xml"));
        }

        public SettingsLoader(string alternatePath)
        {
            settings = Load(alternatePath);
        }
    }
}
