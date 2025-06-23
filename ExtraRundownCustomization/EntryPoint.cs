using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExtraRundownCustomization.Patches;
using ExtraRundownCustomization.Utils;

namespace ExtraRundownCustomization
{
    [BepInPlugin("RLC.ExtraRundownCustomization.GUID", "ExtraRundownCustomization", "1.0.0")]
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
