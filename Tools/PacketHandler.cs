﻿using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaBossSummonRecipes.Tools
{
    public class PacketHandler
    {
        private const byte START_INVASION = 0;
        private const byte START_SLIME_RAIN = 1;
        private const byte SPAWN_METEOR = 2;
        private const byte START_RAIN = 3;
        private const byte START_SANDSTORM = 4;

        private static ModPacket createInvasionPacket(short invasionID)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                return null;
            }

            ModPacket invasionStartPacket = ModContent.GetInstance<VanillaBossSummonRecipes>().GetPacket();
            invasionStartPacket.Write(START_INVASION);
            invasionStartPacket.Write(invasionID);

            return invasionStartPacket;
        }

        private static ModPacket createNoDataPacket(byte packetType)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                return null;
            }

            ModPacket noDataPacket = ModContent.GetInstance<VanillaBossSummonRecipes>().GetPacket();
            noDataPacket.Write(packetType);

            return noDataPacket;
        }


        private static void SendInvasionPacket(short invasionID)
        {
            ModPacket myPacket = createInvasionPacket(invasionID);
            myPacket.Send();
        }


        public static void SendSlimeRainPacket()
        {
            ModPacket myPacket = createNoDataPacket(START_SLIME_RAIN);
            myPacket.Send();
        }


        public static void SendSpawnMeteorPacket()
        {
            ModPacket myPacket = createNoDataPacket(SPAWN_METEOR);
            myPacket.Send();
        }


        public static void SendSpawnMartianInvasionPacket()
        {
            ModPacket myPacket = createInvasionPacket(InvasionID.MartianMadness);
            myPacket.Send();
        }


        public static void SendRainPacket()
        {
            ModPacket myPacket = createNoDataPacket(START_RAIN);
            myPacket.Send();
        }


        public static void SendSandStormPacket()
        {
            ModPacket myPacket = createNoDataPacket(START_SANDSTORM);
            myPacket.Send();
        }

        public static void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte packetType = reader.ReadByte();

            switch (packetType)
            {
                case START_INVASION:
                    {
                        short invasionID = reader.ReadInt16();
                        ModContent.GetInstance<VanillaBossSummonRecipes>().Logger.InfoFormat("Invasion: {0}", invasionID);
                        StartInvasionLocal(invasionID);
                        break;
                    }
                case START_SLIME_RAIN:
                    {
                        ModContent.GetInstance<VanillaBossSummonRecipes>().Logger.InfoFormat("Starting slime rain");
                        StartSlimeRainLocal();
                        break;
                    }
                case SPAWN_METEOR:
                    {
                        ModContent.GetInstance<VanillaBossSummonRecipes>().Logger.InfoFormat("Spawn meteor");
                        SpawnMeteorLocal();
                        break;
                    }
                case START_RAIN:
                    ModContent.GetInstance<VanillaBossSummonRecipes>().Logger.InfoFormat("Starting rain");
                    StartRainLocal();
                    break;
                case START_SANDSTORM:
                    ModContent.GetInstance<VanillaBossSummonRecipes>().Logger.InfoFormat("Starting sandstorm");
                    StartSandstormLocal();
                    break;
                default:
                    {
                        ModContent.GetInstance<VanillaBossSummonRecipes>().Logger.InfoFormat("Packet Type {0} not yet supported", packetType);
                        return;
                    }
            }
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }

        private static void StartInvasionLocal(short invasionID)
        {
            if (Main.invasionType != invasionID)
            {
                Main.StartInvasion(type: invasionID);
                Main.invasionType = invasionID;
            }
        }

        private static void StartMartianInvasionLocal()
        {
            StartInvasionLocal(InvasionID.MartianMadness);
        }

        public static void StartSlimeRainLocal()
        {
            if (!Main.slimeRain)
            {
                Main.StartSlimeRain(announce: true);
            }
        }

        public static void SpawnMeteorLocal()
        {
            WorldGen.dropMeteor();
        }

        public static void StartRainLocal()
        {
            if (!Main.raining)
            {
                Main.StartRain();
            }
        }

        public static void StartSandstormLocal()
        {
            if (!Sandstorm.Happening)
            {
                Sandstorm.StartSandstorm();
            }
        }
    }
}