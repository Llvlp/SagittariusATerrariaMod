using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SagittariusA.Content.Rarities
{
    public class SapphireRarity : ModRarity
    {
        public override Color RarityColor => new Color(8, 37, 103);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset > 0)
            {
                return ModContent.RarityType<AscendantSapphireRarity>();
            }

            return Type;
        }
    }
}
