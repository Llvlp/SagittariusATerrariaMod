using SagittariusA.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Armor.ArchyonArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ArchyonLeggings : ModItem
    {
        public static float MoveSpeedBonus = 20f;

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.rare = ModContent.RarityType<SapphireRarity>();
            Item.defense = 34;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += MoveSpeedBonus / 100f;
        }
    }
}
