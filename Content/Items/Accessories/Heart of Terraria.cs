using SagittariusA.Content.Rarities;
using Terraria;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Accessories
{
    public class Heart_of_Terraria : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;

            Item.width = 24;
            Item.height = 24;
            Item.rare = ModContent.RarityType<SapphireRarity>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 1.4f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.6f;
            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.6f;
            player.GetCritChance(DamageClass.Generic) += 16f;
            player.lifeRegen += 20;
        }
    }
}
