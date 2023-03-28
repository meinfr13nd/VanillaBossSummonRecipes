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

    public class OrphanedAlien : ModItem
    {
        private static string NOT_PROGRESSED_ENOUGH = "This little one seems too scared of something in the jungle to move";

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It seems like this little one just wants to go home");
        }

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
            // After Golem is defeated and if the current invasian isn't martian madness
            if (!NPC.downedGolemBoss)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(NOT_PROGRESSED_ENOUGH, 50, 125, 255);
                }
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(NOT_PROGRESSED_ENOUGH), new Color(50, 125, 255));
                }
                return false;
            }

            return Main.invasionType != InvasionID.MartianMadness;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    PacketHandler.StartInvasionLocal(InvasionID.MartianMadness);
                }
                else
                {
                    PacketHandler.SendInvasionPacket(InvasionID.MartianMadness);
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GlowingMushroom, 50)
                .AddIngredient(ItemID.Torch, 10)
                .AddIngredient(ItemID.MeteoriteBar, 5)
                .AddTile(TileID.Autohammer)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.MartianConduitPlating, 10)
                .AddIngredient(ItemID.GlowingMushroom, 1)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.Autohammer)
                .Register();

        }
    }
}