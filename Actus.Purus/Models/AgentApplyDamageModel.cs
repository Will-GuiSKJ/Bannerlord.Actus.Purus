using Bannerlord.Actus.Purus.Utils;
using SandBox;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.Actus.Purus.Models
{
    internal class AgentApplyDamageModel : SandboxAgentApplyDamageModel
    {
        public override float CalculateDamage(ref AttackInformation attackInformation, ref AttackCollisionData collisionData, in MissionWeapon weapon, float baseDamage, out float bonusFromSkills)
        {
            var multiplier = ModSettings.Settings.CombatDamageMultiplier.AIDealtDamageMultiplier;

            if (attackInformation.AttackerAgentCharacter != null && attackInformation.AttackerAgentCharacter.IsPlayerCharacter)
                multiplier = ModSettings.Settings.CombatDamageMultiplier.PlayerDealtDamageMultiplier;

            return multiplier * base.CalculateDamage(ref attackInformation, ref collisionData, weapon, baseDamage, out bonusFromSkills);
        }
    }
}