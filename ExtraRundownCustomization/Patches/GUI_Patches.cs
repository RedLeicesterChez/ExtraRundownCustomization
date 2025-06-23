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
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_SetIconStatus));
            //Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_Update));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_ExpeditionIcon_New_UpdateBorderColor));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_UpdateTierIconsWithProgression));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_RundownSelectionRevealed));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_UpdateExpeditionIconProgression));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_OnEnable));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_ResetElements));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_TryPlaceRundown));
            Harmony.CreateAndPatchAll(typeof(Patch_CM_PageRundown_New_Setup));
            Harmony.CreateAndPatchAll(typeof(Patch_PUI_Watermark_UpdateWatermark));

            Log.Info("ERC GUI_Patches Setup");
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "SetIconStatus")]
        private class Patch_CM_PageRundown_New_SetIconStatus
        {
            public static void Postfix()
            {
                RundownMenuHandlers.UpdateExpeditionIcons();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "Update")]
        private class Patch_CM_PageRundown_New_Update()
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

        [HarmonyPatch(typeof(CM_ExpeditionIcon_New), "UpdateBorderColor")]
        private class Patch_CM_ExpeditionIcon_New_SetIconStatus
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
                RundownMenuHandlers.UpdateExpeditionIcons();
            }
        }

        [HarmonyPatch(typeof(CM_PageRundown_New), "UpdateExpeditionIconProgression")]
        private class Patch_CM_PageRundown_New_UpdateExpeditionIconProgression
        {
            public static void Postfix()
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
                __instance.m_selectRundownButton.OnBtnPressCallback += (Action<int>)((id) => RundownMenuHandlers.UpdateRundownSelections());
                __instance.m_selectRundownButton.OnBtnPressCallback += (Action<int>)((id) => RundownMenuHandlers.ChangeHasSelectedRundown(false));

                RundownMenuHandlers.m_rundownInstance = __instance;
                RundownMenuHandlers.UpdateRundownSelections();

                foreach (GameObject obj in RundownMenuHandlers.rundownSelectors)
                {
                    obj.GetComponent<CM_RundownSelection>().OnBtnPressCallback += (Action<int>)((id) => RundownMenuHandlers.ChangeHasSelectedRundown(true));
                }
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
