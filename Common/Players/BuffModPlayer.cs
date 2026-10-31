using SagittariusA.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Common.Players
{
    public class BuffModPlayer : ModPlayer
    {
        public bool hasPainfulPurificationAccessory;
        public bool ancLightMinBuff;
        public bool hasHeartOfTerraria;

        public override void ResetEffects()
        {
            hasPainfulPurificationAccessory = false;
            ancLightMinBuff = false;
            hasHeartOfTerraria = false;
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hasPainfulPurificationAccessory)
            {
                target.AddBuff(ModContent.BuffType<WeakPurityBuff>(), 120);
            }

            if (hasHeartOfTerraria)
            {
                target.AddBuff(ModContent.BuffType<InfectiveLife>(), 240);
                target.AddBuff(ModContent.BuffType<ConcentratedVenom>(), 240);
            }
        }

        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (ancLightMinBuff)
            {
                if (item.DamageType == DamageClass.SummonMeleeSpeed || item.DamageType == DamageClass.Summon)
                {
                    damage += 0.15f;
                }
            }
        }
    }
}
