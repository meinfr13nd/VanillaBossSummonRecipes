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

    public class SlimeBucket : ModItem
    {
        private static string NOT_IN_SKY = "This doesn't feel high enough.";

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
            // if in not in sky and not raining slime
            if (!player.ZoneSkyHeight)
            {
                SystemMessageHandler.SendMessage(player, NOT_IN_SKY);
                return false;
            }

            return !Main.slimeRain;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    PacketHandler.StartSlimeRainLocal();
                }
                else
                {
                    PacketHandler.SendSlimeRainPacket();
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.EmptyBucket, 1)
                .AddIngredient(ItemID.Gel, 100)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}