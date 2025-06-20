using CellMenu;
using ExtraRundownCustomization.DataHolders;
using ExtraRundownCustomization.Utils;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ExtraRundownCustomization.Handlers
{
    public class RundownMenuHandlers
    {
        public static CustomRundownSelections m_activeRundownSelectionData;
        public static CustomWatermark m_activeWatermarkData;
        public static RundownLayout m_globalRundownLayout;

        public static CM_PageRundown_New m_rundownInstance;
        public static PUI_Watermark m_watermarkInstance;
        public static void UpdateAll()
        {
            UpdateRundownSelections();
            UpdateWatermark(m_watermarkInstance);
        }

        private static List<GameObject> rundownSelectors = new();

        public static void UpdateRundownSelections()
        {
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

            rundownSelectors.Clear();
            for (int i = 0; i < 8; i++)
            {
                rundownSelectors.Add(__instance.m_rundownHolder.GetChild(16).GetChild(i).gameObject);
                Log.Info("Adding GO to the list GO name: " + __instance.m_rundownHolder.GetChild(16).GetChild(i).gameObject.name);
            }

            __instance.m_textRundownHeader.text = m_activeRundownSelectionData.TextHeader;
            __instance.m_textRundownHeaderTop.text = m_activeRundownSelectionData.TextHeaderTop;

            Log.Info("Before foreach loop");
            foreach (GameObject obj in rundownSelectors)
            {
                Log.Info("in foreach loop go name: " + obj.name);
                switch (obj.name)
                {
                    case "Rundown_Surface_SelectionALT_R1":
                    {
                        Log.Info("Updating R1");
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R1);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R2":
                    {
                        Log.Info("Updating R2");
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R2);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R3":
                    {
                        Log.Info("Updating R3");
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R3);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R4":
                    {
                        Log.Info("Updating R4");
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R4);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R5":
                    {
                        Log.Info("Updating R5");
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R5);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R6":
                    {
                        Log.Info("Updating R6");
                        UpdateRundownSelector(obj, m_activeRundownSelectionData.Selector_R6);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R7":
                    {
                        Log.Info("Updating R7");

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
                        Log.Info("Updating R8");

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

        public static void UpdateWatermark(PUI_Watermark __instance)
        {
            if (m_activeWatermarkData.Enabled)
            {
                __instance.m_watermarkText.text = m_activeWatermarkData.Text;
            }
        }
    }
}
