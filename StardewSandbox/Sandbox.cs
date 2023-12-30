using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Sandbox : Mod
    {
        StardewValley.Object currentObject = null;
        bool shouldDrawTooltip = false;

        public override void Entry(IModHelper helper)
        {
            helper.Events.Player.Warped += OnWarpedHandler;
        }

        private void OnWarpedHandler(object sender, WarpedEventArgs args)
        {

        }

    }
}
