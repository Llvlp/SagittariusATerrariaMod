using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SagittariusA.Common.Players
{
    public class StatModPlayer : ModPlayer
    {
        public int LifeJuiceUsed = 0;
        public int vitalShardUsed = 0;
        public int LifePerLifeJuice = 10;

        public override void NaturalLifeRegen(ref float regen)
        {
            regen *= (1f + vitalShardUsed * 0.1f);
        }

        public override void ModifyMaxStats(out StatModifier health, out StatModifier mana)
        {
            base.ModifyMaxStats(out health, out mana);
            health.Flat += LifeJuiceUsed * LifePerLifeJuice;
        }

        public override void SaveData(TagCompound tag)
        {
            tag["LifeJuiceUsed"] = LifeJuiceUsed;
            tag["vitalShardUsed"] = vitalShardUsed;
        }

        public override void LoadData(TagCompound tag)
        {
            LifeJuiceUsed = tag.GetInt("LifeJuiceUsed");
            vitalShardUsed = tag.GetInt("vitalShardUsed");
        }
    }
}