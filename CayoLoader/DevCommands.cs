using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayoLoader
{
    using Rage;
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
    }
}
