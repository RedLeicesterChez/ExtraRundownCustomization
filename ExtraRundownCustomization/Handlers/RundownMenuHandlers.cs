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

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R1.posX, m_activeRundownSelectionData.Selector_R1.posY, m_activeRundownSelectionData.Selector_R1.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R1.rotX, m_activeRundownSelectionData.Selector_R1.rotY, m_activeRundownSelectionData.Selector_R1.rotZ));
                        obj.transform.GetChild(1).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R1.scaleX, m_activeRundownSelectionData.Selector_R1.scaleY, m_activeRundownSelectionData.Selector_R1.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R1.name;
                        comp.m_altText.text = m_activeRundownSelectionData.Selector_R1.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R1.namePosX, m_activeRundownSelectionData.Selector_R1.namePosY, m_activeRundownSelectionData.Selector_R1.namePosZ);
                        comp.m_altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R1.altTextPosX, m_activeRundownSelectionData.Selector_R1.altTextPosY, m_activeRundownSelectionData.Selector_R1.altTextPosZ);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R2":
                    {
                        Log.Info("Updating R2");

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R2.posX, m_activeRundownSelectionData.Selector_R2.posY, m_activeRundownSelectionData.Selector_R2.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R2.rotX, m_activeRundownSelectionData.Selector_R2.rotY, m_activeRundownSelectionData.Selector_R2.rotZ));
                        obj.transform.GetChild(0).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R2.scaleX, m_activeRundownSelectionData.Selector_R2.scaleY, m_activeRundownSelectionData.Selector_R2.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R2.name;
                        comp.m_altText.text = m_activeRundownSelectionData.Selector_R2.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R2.namePosX, m_activeRundownSelectionData.Selector_R2.namePosY, m_activeRundownSelectionData.Selector_R2.namePosZ);
                        comp.m_altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R2.altTextPosX, m_activeRundownSelectionData.Selector_R2.altTextPosY, m_activeRundownSelectionData.Selector_R2.altTextPosZ);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R3":
                    {
                        Log.Info("Updating R3");

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R3.posX, m_activeRundownSelectionData.Selector_R3.posY, m_activeRundownSelectionData.Selector_R3.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R3.rotX, m_activeRundownSelectionData.Selector_R3.rotY, m_activeRundownSelectionData.Selector_R3.rotZ));
                        obj.transform.GetChild(0).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R3.scaleX, m_activeRundownSelectionData.Selector_R3.scaleY, m_activeRundownSelectionData.Selector_R3.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R3.name;
                        comp.m_altText.text = m_activeRundownSelectionData.Selector_R3.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R3.namePosX, m_activeRundownSelectionData.Selector_R3.namePosY, m_activeRundownSelectionData.Selector_R3.namePosZ);
                        comp.m_altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R3.altTextPosX, m_activeRundownSelectionData.Selector_R3.altTextPosY, m_activeRundownSelectionData.Selector_R3.altTextPosZ);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R4":
                    {
                        Log.Info("Updating R4");

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R4.posX, m_activeRundownSelectionData.Selector_R4.posY, m_activeRundownSelectionData.Selector_R4.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R4.rotX, m_activeRundownSelectionData.Selector_R4.rotY, m_activeRundownSelectionData.Selector_R4.rotZ));
                        obj.transform.GetChild(0).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R4.scaleX, m_activeRundownSelectionData.Selector_R4.scaleY, m_activeRundownSelectionData.Selector_R4.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R4.name;
                        comp.m_altText.text = m_activeRundownSelectionData.Selector_R4.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R4.namePosX, m_activeRundownSelectionData.Selector_R4.namePosY, m_activeRundownSelectionData.Selector_R4.namePosZ);
                        comp.m_altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R4.altTextPosX, m_activeRundownSelectionData.Selector_R4.altTextPosY, m_activeRundownSelectionData.Selector_R4.altTextPosZ);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R5":
                    {
                        Log.Info("Updating R5");

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R5.posX, m_activeRundownSelectionData.Selector_R5.posY, m_activeRundownSelectionData.Selector_R5.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R5.rotX, m_activeRundownSelectionData.Selector_R5.rotY, m_activeRundownSelectionData.Selector_R5.rotZ));
                        obj.transform.GetChild(0).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R5.scaleX, m_activeRundownSelectionData.Selector_R5.scaleY, m_activeRundownSelectionData.Selector_R5.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R5.name;
                        comp.m_altText.text = m_activeRundownSelectionData.Selector_R5.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R5.namePosX, m_activeRundownSelectionData.Selector_R5.namePosY, m_activeRundownSelectionData.Selector_R5.namePosZ);
                        comp.m_altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R5.altTextPosX, m_activeRundownSelectionData.Selector_R5.altTextPosY, m_activeRundownSelectionData.Selector_R5.altTextPosZ);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R6":
                    {
                        Log.Info("Updating R6");

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R6.posX, m_activeRundownSelectionData.Selector_R6.posY, m_activeRundownSelectionData.Selector_R6.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R6.rotX, m_activeRundownSelectionData.Selector_R6.rotY, m_activeRundownSelectionData.Selector_R6.rotZ));
                        obj.transform.GetChild(0).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R6.scaleX, m_activeRundownSelectionData.Selector_R6.scaleY, m_activeRundownSelectionData.Selector_R6.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R6.name;
                        comp.m_altText.text = m_activeRundownSelectionData.Selector_R6.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R6.namePosX, m_activeRundownSelectionData.Selector_R6.namePosY, m_activeRundownSelectionData.Selector_R6.namePosZ);
                        comp.m_altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R6.altTextPosX, m_activeRundownSelectionData.Selector_R6.altTextPosY, m_activeRundownSelectionData.Selector_R6.altTextPosZ);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R7":
                    {
                        Log.Info("Updating R7");

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.posX, m_activeRundownSelectionData.Selector_R7.posY, m_activeRundownSelectionData.Selector_R7.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.rotX, m_activeRundownSelectionData.Selector_R7.rotY, m_activeRundownSelectionData.Selector_R7.rotZ));
                        obj.transform.GetChild(1).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.scaleX, m_activeRundownSelectionData.Selector_R7.scaleY, m_activeRundownSelectionData.Selector_R7.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        TextMeshPro altText = obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R7.name;
                        altText.text = m_activeRundownSelectionData.Selector_R7.altText;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.namePosX, m_activeRundownSelectionData.Selector_R7.namePosY, m_activeRundownSelectionData.Selector_R7.namePosZ);
                        altText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R7.altTextPosX, m_activeRundownSelectionData.Selector_R7.altTextPosY, m_activeRundownSelectionData.Selector_R7.altTextPosZ);
                        altText.gameObject.SetActive(true);
                    }
                    break;

                    case "Rundown_Surface_SelectionALT_R8":
                    {
                        Log.Info("Updating R8");

                        obj.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.posX, m_activeRundownSelectionData.Selector_R8.posY, m_activeRundownSelectionData.Selector_R8.posZ);
                        obj.transform.localRotation = Quaternion.Euler(new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.rotX, m_activeRundownSelectionData.Selector_R8.rotY, m_activeRundownSelectionData.Selector_R8.rotZ));
                        obj.transform.GetChild(2).localScale = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.scaleX, m_activeRundownSelectionData.Selector_R8.scaleY, m_activeRundownSelectionData.Selector_R8.scaleZ);

                        var comp = obj.GetComponent<CM_RundownSelection>();
                        comp.m_rundownText.text = m_activeRundownSelectionData.Selector_R8.name;
                        comp.m_rundownText.transform.localPosition = new UnityEngine.Vector3(m_activeRundownSelectionData.Selector_R8.namePosX, m_activeRundownSelectionData.Selector_R8.namePosY, m_activeRundownSelectionData.Selector_R8.namePosZ);
                    }
                    break;
                }
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
