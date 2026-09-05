using ExtraRundownCustomization.Handlers;
using GameData;
using HarmonyLib;
using Globals;

namespace ExtraRundownCustomization.Patches;

public class GlobalPatches
{
    public static void Setup(Harmony harmony)
    {
        //harmony.PatchAll(typeof(Patch_StartMainGame_Start));
    }

    [HarmonyPatch(typeof(StartMainGame), "Start")]
    private class Patch_StartMainGame_Start
    {
        public static void prefix(StartMainGame __instance)
        {
            GameSetupDataBlock block = GameDataBlockBase<GameSetupDataBlock>.GetBlock(1u);
            Global.StartupScreenKeyToLoad = block.StartupScreenToLoad;
            if (block.RundownIdsToLoad.Count > 8)
            {
                //RundownMenuHandlers.RundownIDsToLoad = block.RundownIdsToLoad.ToArray();
            }
            return;
        }
    }
}