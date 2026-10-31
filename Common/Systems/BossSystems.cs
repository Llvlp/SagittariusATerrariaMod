using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SagittariusA.Common.Systems
{
    public class DownedBossSystem : ModSystem
    {
        public static bool ArchmageOfLifeDowned = false;

        public override void ClearWorld()
        {
            ArchmageOfLifeDowned = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (ArchmageOfLifeDowned)
            {
                tag["ArchmageOfLifeDowned"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            ArchmageOfLifeDowned = tag.ContainsKey("ArchmageOfLifeDowned");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(ArchmageOfLifeDowned);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out ArchmageOfLifeDowned);
        }
    }
}
