using SagittariusA.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Armor.ArchyonArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class ArchyonMask : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.rare = ModContent.RarityType<SapphireRarity>();
            Item.defense = 23;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ArchyonShirt>() && legs.type == ModContent.ItemType<ArchyonLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.lifeRegen += 5;
            player.GetDamage(DamageClass.Summon) += 0.6f;
            player.GetDamage(DamageClass.SummonMeleeSpeed) += 0.4f;
            player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.2f;
            player.maxMinions += 8;
            player.maxTurrets += 2;
        }
    }
}
