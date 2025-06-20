using CellMenu;
using ExtraRundownCustomization.DataHolders;
using ExtraRundownCustomization.Utils;
using Il2CppSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ExtraRundownCustomization.Handlers
{
    public class RundownMenuHandlers
    {
        public static CustomRundownSelections m_activeRundownSelectionData;
        public static RundownLayout m_activeGlobalRundownLayoutData;
        public static CustomWatermark m_activeWatermarkData;

        public static CM_PageRundown_New m_rundownInstance;
        public static PUI_Watermark m_watermarkInstance;
        public static void UpdateAll()
        {
            UpdateRundownSelections();
            UpdateWatermark(m_watermarkInstance);
            UpdateExpeditionIcons();
            AddReloadButton();
        }

        public static void AddReloadButton()
        {
            CM_PageRundown_New __instance = RundownMenuHandlers.m_rundownInstance;
            __instance.m_matchmakeAllButton.SetText("RELOAD ERC DATA");
            __instance.m_matchmakeAllButton.OnBtnPressCallback = (Action<int>)((id) => JsonHandler.OnHotReload()); ;
        }

        private static List<GameObject> rundownSelectors = new();

        public static bool HasSelectedRundown = false;

        public static void SetSelectedRundownFalse()
        {
            HasSelectedRundown = false;
        }

        public static void UpdateRundownSelections()
        {
            AddReloadButton();
            Log.Info("Updating Rundown Selections");
            if (!m_activeRundownSelectionData.Enabled)
            {
                Log.Info("Rundown Selection data is not enabled");
                return;
            }
            CM_PageRundown_New __instance = m_rundownInstance;

            if (__instance == null)
            {
                Log.Info("Instance is null");
                return;
            }

            if (HasSelectedRundown)
            {
                //return;
            }

            rundownSelectors.Clear();
            for (int i = 0; i < 8; i++)
            {
                rundownSelectors.Add(__instance.m_rundownHolder.GetChild(16).GetChild(i).gameObject);
                //Log.Info("Adding GO to the list GO name: " + __instance.m_rundownHolder.GetChild(16).GetChild(i).gameObject.name);
            }

            __instance.m_textRundownHeader.text = m_activeRundownSelectionData.TextHeader;
            __instance.m_textRundownHeaderTop.text = m_activeRundownSelectionData.TextHeaderTop;

            foreach (GameObject obj in rundownSelectors)
            {
                //Log.Info("in foreach loop go name: " + obj.name);
                switch (obj.name)
                {
                    case "Rundown_Surface_SelectionALT_R1":
                    {
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R1);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R2":
                    {
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R2);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R3":
                    {
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R3);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R4":
                    {
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R4);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R5":
                    {
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R5);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R6":
                    {
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R6);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R7":
                    {

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.pos.x, m_activeRundownSelectionData.Selector_R7.pos.y, m_activeRundownSelectionData.Selector_R7.pos.z);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.rot.x, m_activeRundownSelectionData.Selector_R7.rot.y, m_activeRundownSelectionData.Selector_R7.rot.z));
                        obj.transform.localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.scale.x, m_activeRundownSelectionData.Selector_R7.scale.y, m_activeRundownSelectionData.Selector_R7.scale.z);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        TextMeshPro altText = obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R7.name;
                        altText.text = m_activeRundownSelectionData.Selector_R7.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.namePos.x, m_activeRundownSelectionData.Selector_R7.namePos.y, m_activeRundownSelectionData.Selector_R7.namePos.z);
                        altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.altTextPos.x, m_activeRundownSelectionData.Selector_R7.altTextPos.y, m_activeRundownSelectionData.Selector_R7.altTextPos.z);
                        altText.gameObject.SetActive(true);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R8":
                    {

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.pos.x, m_activeRundownSelectionData.Selector_R8.pos.y, m_activeRundownSelectionData.Selector_R8.pos.z);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.rot.x, m_activeRundownSelectionData.Selector_R8.rot.y, m_activeRundownSelectionData.Selector_R8.rot.z));
                        obj.transform.localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.scale.x, m_activeRundownSelectionData.Selector_R8.scale.y, m_activeRundownSelectionData.Selector_R8.scale.z);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R8.name;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.namePos.x, m_activeRundownSelectionData.Selector_R8.namePos.y, m_activeRundownSelectionData.Selector_R8.namePos.z);
                    }
                    break;
                }
            }
        }

        private static void UpdateRundownSelector(GameObject obj, RundownSelector data)
        {
            obj.transform.localPosition = new UnityEngine.Vector3(data.pos.x, data.pos.y, data.pos.z);
            obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(data.rot.x, data.rot.y, data.rot.z));
            obj.transform.localScale = new UnityEngine.Vector3(data.scale.x, data.scale.y, data.scale.z);

            var comp = obj.GetComponent<CM_RundownSelection>();
            comp.m_rundownText.text = data.name;
            comp.m_altText.text = data.altText;
            comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(data.namePos.x, data.namePos.y, data.namePos.z);
            comp.m_altText.transform.localPosition = new UnityEngine.Vector3(data.altTextPos.x, data.altTextPos.y, data.altTextPos.z);
        }

        private static void HideRundownSelectors(GameObject obj)
        {
            obj.transform.localScale = new UnityEngine.Vector3(0, 0, 0);
        }

        public static void UpdateExpeditionIcons()
        {
            if (!m_activeGlobalRundownLayoutData.Enabled)
            {
                Log.Info("Rundown layout update disabled");
                return;
            }
            if (m_rundownInstance == null)
            {
                Log.Info("Instance is null");
                return;
            }

            int index = 0;

            void UpdateIcon(CM_ExpeditionIcon_New expIcon, ExpeditionButton data)
            {
                //Log.Info("Updating Icon GO Name: " + expIcon.gameObject.name);
                if (expIcon == null)
                {
                    Log.Error("expIcon was null in UpdateIcon");
                    return;
                }
                expIcon.ShortName = data.label;
                expIcon.transform.localPosition = new UnityEngine.Vector3(data.buttonPos.x, data.buttonPos.y, data.buttonPos.z);
                expIcon.transform.localScale = new UnityEngine.Vector3(data.buttonScale.x, data.buttonScale.y, data.buttonScale.z);
                expIcon.m_colorUnlocked = new UnityEngine.Color(data.buttonColor.r, data.buttonColor.g, data.buttonColor.b, data.buttonColor.a);
                expIcon.m_colorStory = new UnityEngine.Color(data.buttonColor.r, data.buttonColor.g, data.buttonColor.b, data.buttonColor.a);
                expIcon.m_colorLocked = new UnityEngine.Color(data.buttonColor.r, data.buttonColor.g, data.buttonColor.b, data.buttonColor.a * 0.66f);
                expIcon.m_artifactHeatText.gameObject.SetActive(data.enableHeat);
                expIcon.m_artifactHeatText.text = data.heatText;
                expIcon.m_statusText.transform.localPosition = new UnityEngine.Vector3(data.statusPos.x, data.statusPos.y, data.statusPos.z);
                if (data.overrideDecryptText)
                {
                    expIcon.m_decryptErrorText.gameObject.SetActive(true);
                    expIcon.m_decryptErrorText.text = data.decryptText;
                }
                index++;
                //Log.Info("Updated Icon");
            }

            void UpdateRundown(IndividualRundownLayout data)
            {
                if (!data.Enabled)
                {
                    Log.Info("Data segment was disabled returning;");
                    return;
                }

                //Log.Info("Updating Rundown");
                index = 0;
                if (data.Tier1 != null)
                {
                    foreach (var tier1 in data.Tier1)
                    {
                        if (m_rundownInstance.m_expIconsTier1 == null || m_rundownInstance.m_expIconsTier1.Count < 1) break;
                        UpdateIcon(m_rundownInstance.m_expIconsTier1[index], tier1);
                    }
                }

                index = 0;
                if (data.Tier2 != null)
                {
                    foreach (var tier2 in data.Tier2)
                    {
                        if (m_rundownInstance.m_expIconsTier2 == null || m_rundownInstance.m_expIconsTier2.Count < 1) break;
                        UpdateIcon(m_rundownInstance.m_expIconsTier2[index], tier2);
                    }
                }

                index = 0;
                if (data.Tier3 != null)
                {
                    foreach (var tier3 in data.Tier3)
                    {
                        if (m_rundownInstance.m_expIconsTier3 == null || m_rundownInstance.m_expIconsTier3.Count < 1) break;
                        UpdateIcon(m_rundownInstance.m_expIconsTier3[index], tier3);
                    }
                }

                index = 0;
                if (data.Tier4 != null)
                {
                    foreach (var tier4 in data.Tier4)
                    {
                        if (m_rundownInstance.m_expIconsTier4 == null || m_rundownInstance.m_expIconsTier4.Count < 1) break;
                        UpdateIcon(m_rundownInstance.m_expIconsTier4[index], tier4);
                    }
                }

                index = 0;
                if (data.Tier5 != null)
                {
                    foreach (var tier5 in data.Tier5)
                    {
                        if (m_rundownInstance.m_expIconsTier5 == null || m_rundownInstance.m_expIconsTier5.Count < 1) break;
                        UpdateIcon(m_rundownInstance.m_expIconsTier5[index], tier5);
                    }
                }
            }

            //Can't use a fucking switch :angry:
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R1.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R1);
            }
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R2.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R2);
            }
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R3.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R3);
            }
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R4.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R4);
            }
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R5.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R5);
            }
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R6.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R6);
            }
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R7.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R7);
            }
            if (m_rundownInstance.m_currentRundownData.persistentID == m_activeGlobalRundownLayoutData.R8.RundownDatablockID)
            {
                UpdateRundown(m_activeGlobalRundownLayoutData.R8);
            }
        }

        public static void UpdateWatermark(PUI_Watermark __instance)
        {
            if (m_activeWatermarkData.Enabled)
            {
                __instance.m_watermarkText.text = m_activeWatermarkData.Text;
            }
        }
    }
}
