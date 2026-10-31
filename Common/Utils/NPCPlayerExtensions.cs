using SagittariusA.Common.Players;
using SagittariusA.Content.NPCs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SagittariusA.Common.Utils
{
    public static class NPCPlayerExtensions
    {
        public static SagittariusGlobalNPC Sagittarius(this NPC npc) => npc.GetGlobalNPC<SagittariusGlobalNPC>();
        public static BuffModPlayer Sagittarius(this Player player) => player.GetModPlayer<BuffModPlayer>();
    }
}
