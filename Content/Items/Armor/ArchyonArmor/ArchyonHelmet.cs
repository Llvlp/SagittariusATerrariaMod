using SagittariusA.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Armor.ArchyonArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class ArchyonHelmet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.rare = ModContent.RarityType<SapphireRarity>();
            Item.defense = 44;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ArchyonShirt>() && legs.type == ModContent.ItemType<ArchyonLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.lifeRegen += 5;
            player.GetDamage(DamageClass.Melee) += 0.6f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
        }
    }
}
