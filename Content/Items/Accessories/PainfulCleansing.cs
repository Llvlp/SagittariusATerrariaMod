using SagittariusA.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Accessories
{
    public class PainfulCleansing : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;

            Item.width = 24;
            Item.height = 24;

            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.SummonMeleeSpeed) += 0.25f;
            player.GetDamage(DamageClass.Summon) += 0.2f;
            player.GetModPlayer<BuffModPlayer>().hasPainfulPurificationAccessory = true;
        }
    }
}
