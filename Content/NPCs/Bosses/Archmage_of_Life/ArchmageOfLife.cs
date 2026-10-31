using Microsoft.Xna.Framework;
using SagittariusA.Common.Systems;
using SagittariusA.Content.Buffs;
using SagittariusA.Content.Projectiles;
using System;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SagittariusA.Content.NPCs.Bosses.Archmage_of_Life
{
    public class ArchmageOfLife : ModNPC
    {
        public override string Texture => "SagittariusA/Content/NPCs/Bosses/Archmage_of_Life/ArchmageOfLife";
        private const int timerMax = 90;
        public ref float timer => ref NPC.localAI[0];

        public Vector2 FirstStageDestination
        {
            get => new Vector2(NPC.ai[1], NPC.ai[2]);
            set
            {
                NPC.ai[1] = value.X;
                NPC.ai[2] = value.Y;
            }
        }

        public Vector2 LastFirstStageDestination { get; set; } = Vector2.Zero;

        public override void SetDefaults()
        {
            NPC.width = 138;
            NPC.height = 196;

            NPC.damage = 0;
            NPC.defense = 90;
            NPC.lifeMax = 675_000;
            NPC.HitSound = SoundID.NPCHit1;

            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = false;
            NPC.noTileCollide = true;

            NPC.value = Item.buyPrice(gold: 15);
            NPC.SpawnWithHigherTime(600);
            NPC.boss = true;
            NPC.npcSlots = 20f;

            NPC.aiStyle = -1;
        }

        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            Player plr = Main.player[NPC.target];

            if (plr.dead)
            {
                NPC.velocity.Y -= 0.04f;

                NPC.EncourageDespawn(10);
                return;
            }

            performFirstStage(plr);
        }

        private void performFirstStage(Player plr)
        {
            timer++;
            if (timer > timerMax)
            {
                timer = 0;
            }

            float dist = 200;

            if (timer == 0)
            {
                Vector2 fromPlayer = NPC.Center - plr.Center;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    float angle = fromPlayer.ToRotation();
                    float twelfth = MathHelper.Pi / 6;

                    angle += MathHelper.Pi + Main.rand.NextFloat(-twelfth, twelfth);
                    if (angle > MathHelper.TwoPi)
                    {
                        angle -= MathHelper.TwoPi;
                    }
                    else if (angle < 0)
                    {
                        angle += MathHelper.TwoPi;
                    }

                    Vector2 relativeDestination = angle.ToRotationVector2() * dist;

                    FirstStageDestination = plr.Center + relativeDestination;
                    NPC.netUpdate = true;
                }
            } else if (timer == 40)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 toPlr = (plr.Center - NPC.Center).SafeNormalize(Vector2.UnitY);
                    Vector2 prpndclr = new Vector2(-toPlr.Y, toPlr.X);
                    float startOff = -(60 * 90f) / 2f;

                    for (int i = 0; i < 60; i++)
                    {
                        Vector2 spawnPos = NPC.Center + prpndclr * (startOff + (i * 90f));

                        Projectile.NewProjectile(
                            NPC.GetSource_FromThis(),
                            spawnPos,
                            toPlr * 15,
                            ModContent.ProjectileType<ToxicLifeShot>(),
                            90,
                            4
                        );
                    }
                }
            }

            Vector2 toDestination = FirstStageDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(dist, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 30;

            if (FirstStageDestination != LastFirstStageDestination)
            {
                NPC.TargetClosest();

                if (Main.netMode != NetmodeID.Server)
                {
                    NPC.position += NPC.netOffset;
                    Dust.QuickDustLine(NPC.Center + toDestinationNormalized * NPC.width, FirstStageDestination, toDestination.Length() / 20f, Color.Yellow);

                    NPC.position -= NPC.netOffset;
                }
            }

            LastFirstStageDestination = FirstStageDestination;
        }

        public override void OnKill()
        {
            if (!(DownedBossSystem.ArchmageOfLifeDowned))
            {
                ModContent.GetInstance<OreSystems>().BlessWorldWithArchite();
            }

            NPC.SetEventFlagCleared(ref DownedBossSystem.ArchmageOfLifeDowned, -1);
        }

        public override void SetStaticDefaults()
        {
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<InfectiveLife>()] = true;
        }
    }
}
