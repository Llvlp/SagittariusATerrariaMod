using SagittariusA.Content.Buffs;
using SagittariusA.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Armor.ArchyonArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class ArchyonShirt : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.rare = ModContent.RarityType<SapphireRarity>();
            Item.defense = 34;
        }

        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[ModContent.BuffType<InfectiveLife>()] = true;
            player.buffImmune[ModContent.BuffType<ConcentratedVenom>()] = true;
        }
    }
}
