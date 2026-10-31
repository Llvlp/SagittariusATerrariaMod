using SagittariusA.Content.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Accessories
{
    public class AncientLightSoul : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;

            Item.width = 24;
            Item.height = 24;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 2;
            player.GetDamage(DamageClass.Summon) += 0.15f;
            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.2f;
            player.AddBuff(ModContent.BuffType<AncientLightMinionBuff>(), 2);
        }
    }
}
