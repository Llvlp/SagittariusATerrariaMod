using SagittariusA.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Content.Items.Consumables
{
    public class LifeJuice : ModItem
    {
        public int maxJuice = 20;
        public int healthPerJuice = 10;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeCrystal);
        }

        public override bool CanUseItem(Player player)
        {
            return (player.ConsumedLifeCrystals == Player.LifeCrystalMax) && 
                (player.ConsumedLifeFruit == Player.LifeFruitMax);
        }

        public override bool? UseItem(Player player)
        {
            var modPlr = player.GetModPlayer<StatModPlayer>();
            if (modPlr.LifeJuiceUsed >= maxJuice)
            {
                return null;
            }

            modPlr.LifeJuiceUsed++;
            player.Heal(healthPerJuice);

            return true;
        }
    }
}
