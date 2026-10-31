using Microsoft.Xna.Framework;
using SagittariusA.Content.Tiles;
using System.Collections.Generic;
using System.Threading;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace SagittariusA.Common.Systems
{
    public class OreSystems : ModSystem
    {
        public void BlessWorldWithArchite()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(_ =>
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("Your world has been blessed with Archite!!!", 89, 122, 92);
                } else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(
                        NetworkText.FromLiteral("Your world has been blessed with Archite!!!"),
                        new Color(89, 122, 92)
                    );
                }

                int splotches = (int)(310 * (Main.maxTilesX / 4200f));
                int highestY = (int)MathHelper.Lerp((float)Main.rockLayer, Main.UnderworldLayer, 0.5f);
                for (int iteration = 0; iteration < splotches; iteration++)
                {
                    int i = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                    int j = WorldGen.genRand.Next(highestY, Main.UnderworldLayer);

                    WorldGen.OreRunner(i, j, WorldGen.genRand.Next(10, 18), WorldGen.genRand.Next(10, 18), (ushort)ModContent.TileType<ArchiteOreTile>());
                }
            });
        }
    }
}
