using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VanillaBossSummonRecipes.Tools;

namespace VanillaBossSummonRecipes.Items
{

    public class RainStick : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 10;
            Item.maxStack = 20;
            Item.value = 10;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.raining;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    PacketHandler.StartRainLocal();
                }
                else
                {
                    Main.StartRain();
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.BluePaint, 1)
                .AddIngredient(ItemID.DeepPinkPaint, 1)
                .AddIngredient(ItemID.DeepSkyBluePaint, 1)
                .AddIngredient(ItemID.VioletPaint, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
