using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayoLoader
{
    using Rage;
    using Rage.Native;

    internal static class MapFunctions
    {
        public static void RequestIPL(string IPL) => NativeFunction.Natives.REQUEST_IPL(IPL);

        public static void RemoveIPL(string IPL) => NativeFunction.Natives.REMOVE_IPL(IPL);

        public static void ToggleIPL(string IPL, bool enabled) 
        {
            if (enabled) RequestIPL(IPL);
            else RemoveIPL(IPL);
        }

        public static bool IsIPLActive(string IPL) => NativeFunction.Natives.IS_IPL_ACTIVE<bool>(IPL);

        public static void ToggleIPLs(IEnumerable<string> IPLs, bool enabled)
        {
            foreach (string ipl in IPLs)
            {
                ToggleIPL(ipl, enabled);
            }
        }

        public static void ToggleIslandMap(bool enabled) => NativeFunction.Natives.x9A9D1BA639675CF1("HeistIsland", enabled);

        public static void EnableMP() => NativeFunction.Natives.x0888C3502DBBEEF5(); // ON_ENTER_MP

        public static void SetCullbox(string name, bool enabled) => NativeFunction.Natives.xAF12610C644A35C9(name, enabled);

        public static void DisableIslandCullbox() => SetCullbox("HeistIsland", false);

        public static bool IsIslandTrafficEnabled
        {
            get => World.IsPathNodeIdValid(154);
            set => NativeFunction.Natives.xF74B1FFA4A15FBEA(value);
        }

        public static bool IsIslandWaterEnabled
        {
            get => NativeFunction.Natives.xF741BD853611592D<bool>();
            set => NativeFunction.Natives.x7E3F55ED251B76D3(value);
        }
    }
}
