using BepInEx;
using BepInEx.Unity.IL2CPP;
using ExtraRundownCustomization.Handlers;
using ExtraRundownCustomization.Patches;
using ExtraRundownCustomization.Utils;
using GTFO.API;
using HarmonyLib;
using UnityEngine;

namespace ExtraRundownCustomization
{
    [BepInDependency("com.dak.MTFO", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("Inas.LocalProgression", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInPlugin("RLC.ExtraRundownCustomization", "ExtraRundownCustomization", "1.0.4")]
    internal class EntryPoint : BasePlugin
    {
        private static Harmony _Harmony;
        public override void Load()
        {
            _Harmony = new Harmony("RLC.ExtraRundownCustomization");
            Configurations.LoadConfig(Config);
            GUI_Patches.Setup(_Harmony);
            JsonHandler.SetupJson();
            //AssetAPI.OnAssetBundlesLoaded += OnAssetsLoaded;
            Log.LogInfo("ExtraRundownCustomisation Loaded");
        }

        private static void OnAssetsLoaded()
        {
            /*RundownMenuHandlers.RundownSelectorPrefabs =
            [
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R1.prefab"),
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R2.prefab"),
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R3.prefab"),
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R4.prefab"),
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R5.prefab"),
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R6.prefab"),
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R7.prefab"),
                AssetAPI.GetLoadedAsset<GameObject>("Assets/Bundles/ExtraRundownCustomisation/Rundown_Surface_SelectionALT_R8.prefab"),
            ];*/
        }
    }
}
