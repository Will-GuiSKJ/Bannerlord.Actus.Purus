using Bannerlord.Actus.Purus.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace Bannerlord.Actus.Purus.Behaviors
{
    internal class PassiveXPBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.AfterDailyTickEvent.AddNonSerializedListener(this, OnDailyTick);
        }

        private void OnDailyTick()
        {
            AwardPassiveXP(Hero.MainHero);

            if (ModSettings.Settings.PassiveXPSettings.GivePassiveXPToClanMembersAsWell)
            {
                foreach (Hero hero in Hero.MainHero.Clan.Heroes)
                {
                    if (hero.IsAlive && !hero.IsChild && hero.StringId != Hero.MainHero.StringId)
                        AwardPassiveXP(hero);
                }
            }
        }

        private bool ShouldAddXP(Hero hero, SkillObject skill)
        {
            var hasFocusPoints = hero.HeroDeveloper.GetFocus(skill) > 0 || !ModSettings.Settings.PassiveXPSettings.GivePassiveXPOnlyToSkillsWithFocusPoints;
            var hasLearningRate = hero.HeroDeveloper.GetFocusFactor(skill) > 0;
            var isBelowCap = hero.GetSkillValue(skill) < ModSettings.Settings.PassiveXPSettings.PassiveXPSkillLevelCap;
            return hasFocusPoints && hasLearningRate && isBelowCap;
        }

        private void AwardPassiveXP(Hero hero)
        {
            if (ShouldAddXP(hero, DefaultSkills.OneHanded))
                hero.AddSkillXp(DefaultSkills.OneHanded, ModSettings.Settings.PassiveXPSettings.PassiveOneHandedXP * hero.GetSkillValue(DefaultSkills.OneHanded) / 3);

            if (ShouldAddXP(hero, DefaultSkills.TwoHanded))
                hero.AddSkillXp(DefaultSkills.TwoHanded, ModSettings.Settings.PassiveXPSettings.PassiveTwoHandedXP * hero.GetSkillValue(DefaultSkills.TwoHanded) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Polearm))
                hero.AddSkillXp(DefaultSkills.Polearm, ModSettings.Settings.PassiveXPSettings.PassivePolearmXP * hero.GetSkillValue(DefaultSkills.Polearm) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Bow))
                hero.AddSkillXp(DefaultSkills.Bow, ModSettings.Settings.PassiveXPSettings.PassiveBowXP * hero.GetSkillValue(DefaultSkills.Bow) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Crossbow))
                hero.AddSkillXp(DefaultSkills.Crossbow, ModSettings.Settings.PassiveXPSettings.PassiveCrossbowXP * hero.GetSkillValue(DefaultSkills.Crossbow) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Throwing))
                hero.AddSkillXp(DefaultSkills.Throwing, ModSettings.Settings.PassiveXPSettings.PassiveThrowingXP * hero.GetSkillValue(DefaultSkills.Throwing) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Riding))
                hero.AddSkillXp(DefaultSkills.Riding, ModSettings.Settings.PassiveXPSettings.PassiveRidingXP * hero.GetSkillValue(DefaultSkills.Riding) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Athletics))
                hero.AddSkillXp(DefaultSkills.Athletics, ModSettings.Settings.PassiveXPSettings.PassiveAthleticsXP * hero.GetSkillValue(DefaultSkills.Athletics) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Crafting))
                hero.AddSkillXp(DefaultSkills.Crafting, ModSettings.Settings.PassiveXPSettings.PassiveCraftingXP * hero.GetSkillValue(DefaultSkills.Crafting) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Scouting))
                hero.AddSkillXp(DefaultSkills.Scouting, ModSettings.Settings.PassiveXPSettings.PassiveScoutingXP * hero.GetSkillValue(DefaultSkills.Scouting) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Tactics))
                hero.AddSkillXp(DefaultSkills.Tactics, ModSettings.Settings.PassiveXPSettings.PassiveTacticsXP * hero.GetSkillValue(DefaultSkills.Tactics) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Roguery))
                hero.AddSkillXp(DefaultSkills.Roguery, ModSettings.Settings.PassiveXPSettings.PassiveRogueryXP * hero.GetSkillValue(DefaultSkills.Roguery) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Charm))
                hero.AddSkillXp(DefaultSkills.Charm, ModSettings.Settings.PassiveXPSettings.PassiveCharmXP * hero.GetSkillValue(DefaultSkills.Charm) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Leadership))
                hero.AddSkillXp(DefaultSkills.Leadership, ModSettings.Settings.PassiveXPSettings.PassiveLeadershipXP * hero.GetSkillValue(DefaultSkills.Leadership) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Trade))
                hero.AddSkillXp(DefaultSkills.Trade, ModSettings.Settings.PassiveXPSettings.PassiveTradeXP * hero.GetSkillValue(DefaultSkills.Trade) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Steward))
                hero.AddSkillXp(DefaultSkills.Steward, ModSettings.Settings.PassiveXPSettings.PassiveStewardXP * hero.GetSkillValue(DefaultSkills.Steward) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Medicine))
                hero.AddSkillXp(DefaultSkills.Medicine, ModSettings.Settings.PassiveXPSettings.PassiveMedicineXP * hero.GetSkillValue(DefaultSkills.Medicine) / 3);

            if (ShouldAddXP(hero, DefaultSkills.Engineering))
                hero.AddSkillXp(DefaultSkills.Engineering, ModSettings.Settings.PassiveXPSettings.PassiveEngineeringXP * hero.GetSkillValue(DefaultSkills.Engineering) / 3);
        }

        public override void SyncData(IDataStore dataStore)
        {
        }
    }
}