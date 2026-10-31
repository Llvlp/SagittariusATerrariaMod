using Terraria;
using Terraria.ModLoader;

namespace SagittariusA.Content.Buffs
{
    public class OrichalcumSkinBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 14;
        }
    }
}
