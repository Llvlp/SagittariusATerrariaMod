using SagittariusA.Content.NPCs.Bosses.Archmage_of_Life;
using Terraria;
using Terraria.ModLoader;

namespace SagittariusA.Content.NPCs
{
    public class SagittariusGlobalNPC : GlobalNPC
    {
        public bool cosmicRad;
        public bool weakPurity;
        public bool cripple;
        public bool infLife;
        public bool conPoison;
        public bool flamingPurity;
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            cosmicRad = false;
            weakPurity = false;
            cripple = false;
            infLife = false;
            conPoison = false;
            flamingPurity = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (cosmicRad)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 800;
            }

            if (weakPurity)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                if (npc.type == ModContent.NPCType<ArchmageOfLife>())
                {
                    npc.lifeRegen -= 22;
                } else
                {
                    npc.lifeRegen -= 45;
                }
            }

            if (infLife)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 400;
                npc.velocity *= 0.6f;
            }

            if (conPoison)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 350;
                npc.velocity *= 0.4f;
                npc.damage = (int)(npc.damage * 0.9);
            }

            if (flamingPurity)
            { 
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= (1600 + (npc.lifeMax / 5000));
            }
        }

        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (weakPurity)
            {
                modifiers.Defense.Flat -= 10;
            }

            if (cripple)
            {
                modifiers.Defense.Flat -= (int)(npc.defense * 0.15);
                modifiers.SourceDamage += 0.5f;
            }

            if (infLife)
            {
                modifiers.Defense.Flat -= (int)(npc.defense * 0.25);
            }

            if (flamingPurity)
            {
                modifiers.Defense.Flat -= ((int)(npc.defense * 0.25) + 15);
            }
        }
    }
}
