using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VanillaBossSummonRecipes.Tools
{
    public class SystemMessageHandler
    {
        public static void SendMessage(Player player, string message)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(message, 50, 125, 255);
                }
                else
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), new Color(50, 125, 255));
                }
            }
        }
    }
}