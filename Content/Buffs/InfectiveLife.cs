using SagittariusA.Common.Utils;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SagittariusA.Content.Buffs
{
    public class InfectiveLife : ModBuff
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
            npc.Sagittarius().infLife = true;
        }
    }
}
