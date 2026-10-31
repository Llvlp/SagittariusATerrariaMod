using Terraria;
using Terraria.ID;
using SagittariusA.Common.Utils;
using Terraria.ModLoader;

namespace SagittariusA.Content.Buffs
{
    public class FlamingPurity : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;

            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.Sagittarius().flamingPurity = true;
        }
    }
}
