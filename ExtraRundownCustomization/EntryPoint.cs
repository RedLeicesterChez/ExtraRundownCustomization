using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExtraRundownCustomization.Patches;
using ExtraRundownCustomization.Utils;
using GTFO.API;
using HarmonyLib;

namespace ExtraRundownCustomization
{
    [BepInDependency("com.dak.MTFO", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("Inas.LocalProgression", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInPlugin("RLC.ExtraRundownCustomization", "ExtraRundownCustomization", "1.0.0")]
    internal class EntryPoint : BasePlugin
    {
        private static Harmony _Harmony;
        public override void Load()
        {
            _Harmony = new Harmony($"{VersionInfo.RootNamespace}.Harmony");
            GUI_Patches.Setup(_Harmony);
            JsonHandler.SetupJson();

            Log.LogInfo("ExtraRundownCustomisation Loaded");
        }
    }
}
