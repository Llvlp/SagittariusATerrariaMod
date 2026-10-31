using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace SagittariusA.Content.Projectiles
{
    public class ToxicLifeShot : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 16;
            Projectile.width = 24;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
        }
    }
}
