using BepInEx.Configuration;

namespace ExtraRundownCustomization.Utils
{
    internal static class Configurations
    {
        public static void LoadConfig(ConfigFile configFile)
        {
            _enableLiveEdit = configFile.Bind("LiveEdit", "LiveEditEnable", true, "Enables or disabled LiveEdit");
        }

        internal static ConfigEntry<bool> _enableLiveEdit;
    }
}
