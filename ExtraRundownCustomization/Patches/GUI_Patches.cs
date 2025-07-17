using CellMenu;
using ExtraRundownCustomization.Handlers;
using ExtraRundownCustomization.Utils;
using HarmonyLib;
using System;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using UnityEngine;

namespace ExtraRundownCustomization.Patches
{
    public class GUI_Patches
    {
        public static void Setup(Harmony harmony)
        {
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_Update));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_ResetRundownSelection));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_UpdateHeaderText));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_SetIconStatus));
            harmony.PatchAll(typeof(Patch_CM_ExpeditionIcon_New_UpdateBorderColor));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_UpdateTierIconsWithProgression));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_RundownSelectionRevealed));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_OnEnable));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_ResetElements));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_TryPlaceRundown));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_PlaceRundown));
            harmony.PatchAll(typeof(Patch_CM_PageRundown_New_Setup));
            harmony.PatchAll(typeof(Patch_PUI_Watermark_UpdateWatermark));

            Log.Info("ERC GUI_Patches Setup");
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "Update")]
        private class Patch_CM_PageRundown_New_Update
        {
            public static void Postfix(CM_PageRundown_New __instance)
            {
                if (__instance.m_currentRundownData == null)
                {
                    __instance.m_textRundownHeaderTop.text = RundownMenuHandlers.m_activeRundownSelectionData.TextHeaderTop;
                }
                if (__instance.m_buttonConnect.gameObject.active)
                {
                    __instance.m_textRundownHeaderTop.gameObject.SetActive(true);
                }
                if (__instance.m_popupMovement.transform.GetChild(0).gameObject.active)
                {
                    RundownMenuHandlers.m_popupMovementActive = true;
                }
                else
                {
                    RundownMenuHandlers.m_popupMovementActive = false;
                }
                RundownMenuHandlers.LazyUpdate(); //not so lazy update :(
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

        [HarmonyPatch(typeof(CM_PageRundown_New), "UpdateHeaderText")]
        private class Patch_CM_PageRundown_New_UpdateHeaderText
        {
            public static void Postfix()
            {
                RundownMenuHandlers.UpdateRundownSelections();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "SetIconStatus")]
        private class Patch_CM_PageRundown_New_SetIconStatus
        {
            public static void Postfix()
            {
                RundownMenuHandlers.UpdateExpeditionIcons();
            }
        }

        [HarmonyPatch(typeof(CM_ExpeditionIcon_New), "UpdateBorderColor")]
        private class Patch_CM_ExpeditionIcon_New_UpdateBorderColor
        {
            public static void Postfix()
            {
                RundownMenuHandlers.UpdateExpeditionIcons();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "UpdateTierIconsWithProgression")]
        private class Patch_CM_PageRundown_New_UpdateTierIconsWithProgression
        {
            public static void Postfix()
            {
                RundownMenuHandlers.UpdateExpeditionIcons();
            }
        }
        
        [HarmonyPatch(typeof(CM_PageRundown_New), "RundownSelectionRevealed")]
        private class Patch_CM_PageRundown_New_RundownSelectionRevealed
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
        [HarmonyPatch(typeof(CM_PageRundown_New), "PlaceRundown")]
        private class Patch_CM_PageRundown_New_PlaceRundown
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
                __instance.m_selectRundownButton.OnBtnPressCallback += (Action<int>)((id) => RundownMenuHandlers.UpdateRundownSelections());

                RundownMenuHandlers.m_rundownInstance = __instance;
                RundownMenuHandlers.UpdateRundownSelections();
                RundownMenuHandlers.SetupRundownFeatures();
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
