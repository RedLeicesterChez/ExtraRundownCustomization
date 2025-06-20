using CellMenu;
using ExtraRundownCustomization.Handlers;
using ExtraRundownCustomization.Utils;
using HarmonyLib;
using System;
using UnityEngine;

namespace ExtraRundownCustomization.Patches
{
    public class GUI_Patches
    {
        public static void Setup()
        {
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_UpdateExpeditionIconProgression));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_OnEnable));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_ResetElements));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_TryPlaceRundown));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_Setup));
            Harmony.CreateAndPatchAll(typeof(Patch_PUI_Watermark_UpdateWatermark));
            Log.Info("ERC GUI_Patches Setup");
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "UpdateExpeditionIconProgression")]
        private class Patch_CM_PageRundown_New_UpdateExpeditionIconProgression
        {
            public static void Postfix(CM_PageRundown_New __instance)
            {
                RundownMenuHandlers.UpdateExpeditionIcons();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "ResetRundownSelection")]
        private class Patch_CM_PageRundown_New_ResetRundownSelection
        {
            public static void Postfix()
            {
                RundownMenuHandlers.UpdateRundownSelections();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "OnEnable")]
        private class Patch_CM_PageRundown_New_OnEnable
        {
            public static void Postfix()
            {
                RundownMenuHandlers.UpdateRundownSelections();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "ResetElements")]
        private class Patch_CM_PageRundown_New_ResetElements
        {
            public static void Postfix(CM_PageRundown_New __instance)
            {
                RundownMenuHandlers.UpdateRundownSelections();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "TryPlaceRundown")]
        private class Patch_CM_PageRundown_New_TryPlaceRundown
        {
            public static void Postfix(CM_PageRundown_New __instance)
            {
                RundownMenuHandlers.UpdateRundownSelections();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "Setup")]
        private class Patch_CM_PageRundown_New_Setup
        {
            public static void Postfix(CM_PageRundown_New __instance)
            {
                __instance.m_selectRundownButton.m_onBtnPress.AddListener((UnityEngine.Events.UnityAction)RundownMenuHandlers.UpdateRundownSelections);
                //__instance.m_selectRundownButton.m_onBtnPress.AddListener((UnityEngine.Events.UnityAction)RundownMenuHandlers.SetSelectedRundownFalse);
                RundownMenuHandlers.m_rundownInstance = __instance;
                RundownMenuHandlers.UpdateRundownSelections();
            }
        }

        [HarmonyPatch(typeof(PUI_Watermark), "UpdateWatermark")]
        private class Patch_PUI_Watermark_UpdateWatermark
        {
            public static void Postfix(PUI_Watermark __instance)
            {
                RundownMenuHandlers.UpdateWatermark(__instance);
                RundownMenuHandlers.m_watermarkInstance = __instance;
            }
        }
    }
}
