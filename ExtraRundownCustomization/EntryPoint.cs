using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExtraRundownCustomization.Patches;
using ExtraRundownCustomization.Utils;
using GTFO.API;

namespace ExtraRundownCustomization
{
    [BepInDependency("com.dak.MTFO", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("Inas.LocalProgression", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("RLC.ExtraRundownCustomization", "ExtraRundownCustomization", "1.0.0")]
    internal class EntryPoint : BasePlugin
    {
        public override void Load()
        {
            GUI_Patches.Setup();
            JsonHandler.SetupJson();

            Log.LogInfo("ExtraRundownCustomisation Loaded");
        }
    }
}
