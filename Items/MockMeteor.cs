using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VanillaBossSummonRecipes;
using VanillaBossSummonRecipes.Tools;


namespace VanillaBossSummonRecipes.Items
{

    public class MockMeteor : ModItem
    {
        private static string NOT_IN_SKY = "This doesn't feel high enough to be convincing.";
        private static string CTHULU_FORCE = "An evil force seems to be watching the skys.";

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            // if eye/brain of Cthulu is defeated and the player is in the sky
            if (!NPC.downedBoss2 && !NPC.downedBoss1)
            {
                SystemMessageHandler.SendMessage(player, CTHULU_FORCE);
                return false;
            }

            if (!player.ZoneSkyHeight)
            {
                SystemMessageHandler.SendMessage(player, NOT_IN_SKY);
                return false;
            }

            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    PacketHandler.SpawnMeteorLocal();
                }
                else
                {
                    PacketHandler.SendSpawnMeteorPacket();
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(nameof(ItemID.Torch), 100)
                .AddIngredient(ItemID.StoneBlock, 100)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}