using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaBossSummonRecipes
{
	public class VanillaBossSummonRecipes : Mod
	{

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.QueenSlimeCrystal, 1);
            recipe.AddIngredient(ItemID.PinkGel, 20);
            recipe.AddIngredient(ItemID.PlatinumCrown, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ItemID.QueenSlimeCrystal, 1);
            recipe.AddIngredient(ItemID.PinkGel, 20);
            recipe.AddIngredient(ItemID.GoldCrown, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}