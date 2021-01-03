using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayoLoader
{
    using Rage;
    using Rage.Native;
    using Rage.Attributes;

    internal static class DevCommands
    {
        [ConsoleCommand]
        private static void SetIslandSLOD(bool enable) => MapFunctions.ToggleIPLs(LodList.SLODsIsland, enable);

        [ConsoleCommand]
        private static void SetMainMapSLOD(bool enable) => MapFunctions.ToggleIPLs(LodList.SLODsMain, enable);

        [ConsoleCommand]
        private static void ToggleIsland(bool enable) => MapFunctions.ToggleIslandMap(enable);

        [ConsoleCommand]
        private static void ToggleCulling(bool enable) => MapFunctions.SetCullbox("HeistIsland", enable);

        [ConsoleCommand]
        private static void EnableMP() => MapFunctions.EnableMP();

        [ConsoleCommand]
        private static void SetIslandWater(bool enable) => MapFunctions.IsIslandWaterEnabled = enable;

        [ConsoleCommand]
        private static void SetIslandPaths(bool enable) => MapFunctions.IsIslandTrafficEnabled = enable;

        [ConsoleCommand]
        private static void EnableIslandAndMainMap()
        {
            MapFunctions.EnableMP();
            GameFiber.Yield();
            MapFunctions.ToggleIslandMap(true);
            GameFiber.Sleep(2000);
            MapFunctions.DisableIslandCullbox();
        }

        private static Blip mapBoundsBlip;
        private static GameFiber minimapFiber;
        [ConsoleCommand]
        private static void EnableIslandMinimap(bool enable)
        {
            bool running = minimapFiber?.IsAlive == true;
            
            if (running && !enable) minimapFiber.Abort();
            
            if(!running && enable)
            {
                if(!mapBoundsBlip)
                {
                    mapBoundsBlip = new Blip(new Vector3(7000, -7000, 0));
                    mapBoundsBlip.Scale = 0;
                    mapBoundsBlip.Alpha = 1;
                }

                minimapFiber = GameFiber.ExecuteNewWhile(() => 
                {
                    NativeFunction.Natives.SET_RADAR_AS_INTERIOR_THIS_FRAME(Game.GetHashKey("h4_fake_islandx"), 4700.0f, -5145.0f, 0, 0);
                    NativeFunction.Natives.SET_RADAR_AS_EXTERIOR_THIS_FRAME();
                }, () => true);
            }
        }
    }
}
