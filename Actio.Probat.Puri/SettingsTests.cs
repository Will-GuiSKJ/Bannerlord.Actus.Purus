using Bannerlord.Actus.Purus.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Bannerlord.Actio.Probat.Puri
{
    [TestClass()]
    public class SettingsTests
    {
        private string solutionpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private Settings settings;

        [TestInitialize]
        public void Initialize()
        {
            var path = Path.Combine(solutionpath, "Actus.Purus", "ActusPurus", "Settings.xml");
            StreamReader streamReader;
            using (streamReader = new StreamReader(path))
            {
                var xmlReader = XmlReader.Create(streamReader);
                var serializer = new XmlSerializer(typeof(Settings));
                settings = (Settings)serializer.Deserialize(xmlReader);
            }
        }

        [TestMethod()]
        public void MainSettings()
        {
        }

        [TestMethod()]
        public void CharacterPresetsSettings()
        {
            Assert.IsTrue(settings.CharacterPresets.MalePresets.Length >= 0);
            Assert.IsTrue(settings.CharacterPresets.FemalePresets.Length >= 0);

            var bodyPropertiy = new BodyProperties() { age = 21, build = 0.5f, version = 4, weight = 0.5f, key = "HelloWorld" };
            Assert.AreEqual("<BodyProperties version=\"4\" age=\"21\" weight=\"0.5\" build=\"0.5\"  key=\"HelloWorld\" />", bodyPropertiy.ToString());
        }

        [TestMethod()]
        public void PassiveXPSettings()
        {
        }
    }
}