using Terraria;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Accessories
{
    public class AncientDarkSoul : ModItem
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
            player.GetAttackSpeed(DamageClass.Summon) += 0.15f;
            player.GetDamage(DamageClass.SummonMeleeSpeed) += 0.2f;
        }
    }
}
