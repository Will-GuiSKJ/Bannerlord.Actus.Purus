using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Bannerlord.Actus.Purus.Loaders.Tests
{
    [TestClass()]
    public class SettingsLoaderTests
    {
        private string solutionpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        [TestMethod()]
        public void SettingsLoaderTest()
        {
            var filepath = Path.Combine(solutionpath, "Actus.Purus", "ActusPurus", "Settings.xml");
            var loader = new SettingsLoader(filepath);

            Assert.IsTrue(loader.settings.DebugMode is bool);
            Assert.IsTrue(loader.settings.EnableMinorFactionTroopRecruitment is bool);
            Assert.IsTrue(loader.settings.EnableMinorFactionQuests is bool);
        }
    }
}