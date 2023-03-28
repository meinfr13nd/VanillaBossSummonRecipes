using System.IO;
using Terraria.ModLoader;
using VanillaBossSummonRecipes.Tools;

namespace VanillaBossSummonRecipes
{

    public class VanillaBossSummonRecipes : Mod
    {
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            PacketHandler.HandlePacket(reader, whoAmI);
        }
    }
}