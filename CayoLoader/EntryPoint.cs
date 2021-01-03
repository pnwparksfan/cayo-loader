using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Rage.Attributes.Plugin("Cayo Perico Loader", Description = "Loads Cayo Perico seamlessly", Author = "PNWParksFan", ShouldTickInPauseMenu = true, PrefersSingleInstance = true)]

namespace CayoLoader
{
    using Rage;
    using Rage.Native;

    internal static class EntryPoint
    {
        private static void Main()
        {
            Game.LogTrivial("Loaded Cayo Perico Loader");
            GameFiber.Hibernate();
        }
    }
}
