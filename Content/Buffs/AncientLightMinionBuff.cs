using SagittariusA.Content.Projectiles.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace SagittariusA.Content.Buffs
{
    public class AncientLightMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<AncientLightMinion>()] > 0)
                player.buffTime[buffIndex] = 18000;
            else
                if (player.whoAmI == Main.myPlayer)
                    Projectile.NewProjectile(
                        player.GetSource_Buff(buffIndex),
                        player.Center,
                        Microsoft.Xna.Framework.Vector2.Zero,
                        ModContent.ProjectileType<AncientLightMinion>(),
                        Damage: 42,
                        KnockBack: 6f
                    );
        }
    }
}
