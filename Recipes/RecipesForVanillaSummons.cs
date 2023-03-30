using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VanillaBossSummonRecipes.Recipes
{
    public class RecipesForVanillaSummons : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup torches = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Torch)}",
                ItemID.BlueTorch,
                ItemID.BoneTorch,
                ItemID.CoralTorch,
                ItemID.CorruptTorch,
                ItemID.CrimsonTorch,
                ItemID.CursedTorch,
                ItemID.DemonTorch,
                ItemID.DesertTorch,
                ItemID.GreenTorch,
                ItemID.HallowedTorch,
                ItemID.IceTorch,
                ItemID.IchorTorch,
                ItemID.JungleTorch,
                ItemID.OrangeTorch,
                ItemID.PinkTorch,
                ItemID.PurpleTorch,
                ItemID.RainbowTorch,
                ItemID.RedTorch,
                ItemID.Torch,
                ItemID.UltrabrightTorch,
                ItemID.WhiteTorch,
                ItemID.YellowTorch);
            RecipeGroup.RegisterGroup(nameof(ItemID.Torch), torches);
        }

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
                .AddRecipeGroup(nameof(ItemID.Torch), 10)
                .AddIngredient(ItemID.LunarTabletFragment, 5)
                .AddTile(TileID.AdamantiteForge)
                .Register();


            // truffle worm (duke fishron summon)
            Recipe.Create(ItemID.TruffleWorm)
                .AddIngredient(ItemID.GlowingMushroom, 50)
                .AddIngredient(ItemID.EnchantedNightcrawler, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();


            //  Prismatic Lacewing (Empress of Light summon)
            Recipe.Create(ItemID.EmpressButterfly)
                .AddIngredient(ItemID.PixieDust, 50)
                .AddRecipeGroup(RecipeGroupID.Butterflies, 1)
                .Register();
        }
    }
}