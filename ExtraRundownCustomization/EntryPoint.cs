using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExtraRundownCustomization.Handlers;
using ExtraRundownCustomization.Patches;
using ExtraRundownCustomization.Utils;

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

            var lpGUID = "Inas.LocalProgression";
            //This was here to make localprog optional but i can't be bothered to do that anymore
            if (IL2CPPChainloader.Instance.Plugins.TryGetValue(lpGUID, out var info))
            {
                Log.LogInfo("LocalProgression detected");
                RundownMenuHandlers.m_hasLocalProg = true;
            }

            Log.LogInfo("ExtraRundownCustomisation Loaded");
        }
    }
}
