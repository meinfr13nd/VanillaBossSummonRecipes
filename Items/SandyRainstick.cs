using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using VanillaBossSummonRecipes.Tools;

namespace VanillaBossSummonRecipes.Items
{

    public class SandyRainStick : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 10;
            Item.maxStack = 20;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return !Sandstorm.Happening;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    PacketHandler.StartSandstormLocal();
                }
                else
                {
                    PacketHandler.SendSandStormPacket();
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Sand, 10)
                .AddIngredient<Items.RainStick>()
                .Register();
        }
    }
}
