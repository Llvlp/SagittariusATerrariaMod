using System;
using Terraria.ModLoader;

namespace SagittariusA.Common.Systems
{
    public class BiomeSystem : ModSystem
    {
        public int shatteredBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            shatteredBlockCount = 0;
        }
    }
}
