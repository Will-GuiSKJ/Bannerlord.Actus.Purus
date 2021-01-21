using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TaleWorlds.Library;

namespace Bannerlord.Actus.Purus.Utils
{
    internal static class ModSettings
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
        [NonSerialized()]
        public bool DebugMode = false;

        public CharacterPresets CharacterPresets { get; set; }
        public bool EnableBlankCharacterCreation { get; set; }
        public bool EnableMinorFactionTroopRecruitment { get; set; }

        [NonSerialized()]
        public bool EnableMinorFactionQuests = false;

        public SimpleConfig InitialCompanionCount { get; set; }
        public SimpleConfig InitialPartyCount { get; set; }
        public SimpleConfig InitialWorkshopCount { get; set; }
        public SimpleConfig LogarithmicAICombatDifficulty { get; set; }
        public CombatDamageMultiplier CombatDamageMultiplier { get; set; }
        public CraftingConfig CraftingConfig { get; set; }
        public GarrisonRecruitment GarrisonRecruitment { get; set; }
        public EquipmentBattleReward EquipmentBattleReward { get; set; }
        public PassiveXPSettings PassiveXPSettings { get; set; }
    }

    [Serializable()]
    public class SimpleConfig
    {
        public bool Enabled { get; set; }
        public float Value { get; set; }
    }

    [Serializable()]
    public class CharacterPresets
    {
        public bool Enabled { get; set; }
        public BodyProperties[] FemalePresets { get; set; }
        public BodyProperties[] MalePresets { get; set; }
    }

    [Serializable()]
    public class BodyProperties
    {
        [XmlAttribute]
        public int version { get; set; }

        [XmlAttribute]
        public float age { get; set; }

        [XmlAttribute]
        public float weight { get; set; }

        [XmlAttribute]
        public float build { get; set; }

        [XmlAttribute]
        public string key { get; set; }

        public override string ToString()
        {
            return $"<BodyProperties version='{version}' age='{age}' weight='{weight}' build='{build}' key='{key}' />";
        }
    }

    [Serializable()]
    public class CombatDamageMultiplier
    {
        public bool Enabled { get; set; }
        public float PlayerDealtDamageMultiplier { get; set; }
        public float AIDealtDamageMultiplier { get; set; }
    }

    [Serializable()]
    public class CraftingConfig
    {
        public bool Enabled { get; set; }
        public float StaminaCostMultiplier { get; set; }
        public float PartResearchXPGainMultiplier { get; set; }
        public int HourlySettlementStaminaRecoveryRate { get; set; }
        public int HourlyMovingStaminaRecoveryRate { get; set; }
    }

    [Serializable()]
    public class GarrisonRecruitment
    {
        public bool EnabledForPlayer { get; set; }
        public bool EnabledForAI { get; set; }
        public float DailyNumberOfRecruits { get; set; }
        public float ChanceToSpawnNobleTroop { get; set; }
        public float RatioOfOwnerCultureTroops { get; set; }
    }

    [Serializable()]
    public class EquipmentBattleReward
    {
        public bool Enabled { get; set; }
        public float IndividualItemRewardChance { get; set; }
        public int CommonItemValueThreshold { get; set; }
        public int UncommonItemValueThreshold { get; set; }
        public int RareItemValueThreshold { get; set; }
    }

    [Serializable()]
    public class PassiveXPSettings
    {
        public bool Enabled { get; set; }
        public bool GivePassiveXPOnlyToSkillsWithFocusPoints { get; set; }
        public bool GivePassiveXPToClanMembersAsWell { get; set; }
        public int PassiveXPSkillLevelCap { get; set; }
        public float PassiveOneHandedXP { get; set; }
        public float PassiveTwoHandedXP { get; set; }
        public float PassivePolearmXP { get; set; }
        public float PassiveBowXP { get; set; }
        public float PassiveCrossbowXP { get; set; }
        public float PassiveThrowingXP { get; set; }
        public float PassiveRidingXP { get; set; }
        public float PassiveAthleticsXP { get; set; }
        public float PassiveCraftingXP { get; set; }
        public float PassiveScoutingXP { get; set; }
        public float PassiveTacticsXP { get; set; }
        public float PassiveRogueryXP { get; set; }
        public float PassiveCharmXP { get; set; }
        public float PassiveLeadershipXP { get; set; }
        public float PassiveTradeXP { get; set; }
        public float PassiveStewardXP { get; set; }
        public float PassiveMedicineXP { get; set; }
        public float PassiveEngineeringXP { get; set; }
    }
}