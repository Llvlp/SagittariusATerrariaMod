using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SagittariusA.Content.Rarities
{
    public class AscendantSapphireRarity : ModRarity
    {

        Color startColor = new Color(8, 37, 103);
        Color endColor = new Color(10, 8, 103);
        float t = (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 4f) + 1f) * 0.5f;

        public override Color RarityColor => Color.Lerp(startColor, endColor, t);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<SapphireRarity>();
            }

            return Type;
        }
    }
}
