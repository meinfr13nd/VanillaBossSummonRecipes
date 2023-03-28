using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaBossSummonRecipes.Recipes
{
    public class RecipesForVanillaSummons : ModSystem
    {

        public override void AddRecipes()
        {
            // queen slime summons
            Recipe.Create(ItemID.QueenSlimeCrystal)
                .AddIngredient(ItemID.PinkGel, 20)
                .AddIngredient(ItemID.Bone, 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            // golem summon
            Recipe.Create(ItemID.LihzahrdPowerCell)
                .AddIngredient(ItemID.Torch, 10)
                .AddIngredient(ItemID.LunarTabletFragment, 5)
                .AddTile(TileID.AdamantiteForge)
                .Register();


            // truffle worm
            Recipe.Create(ItemID.TruffleWorm)
                .AddIngredient(ItemID.GlowingMushroom, 50)
                .AddIngredient(ItemID.EnchantedNightcrawler, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}