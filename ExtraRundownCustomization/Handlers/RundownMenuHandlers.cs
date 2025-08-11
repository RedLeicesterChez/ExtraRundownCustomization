using CellMenu;
using ExtraRundownCustomization.DataHolders;
using ExtraRundownCustomization.Utils;
using GameData;
using Il2CppSystem;
using LocalProgression;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MTFO.API;
using GTFO.API;
using System.Linq;

namespace ExtraRundownCustomization.Handlers
{
    public class RundownMenuHandlers
    {
        public static CustomRundownSelections m_activeRundownSelectionData;
        public static RundownLayout m_activeGlobalRundownLayoutData;
        public static MiscRundownData m_activeMiscRundownData;
        public static CustomWatermark m_activeWatermarkData;

        public static CM_PageRundown_New m_rundownInstance;
        public static PUI_Watermark m_watermarkInstance;

        public static bool m_popupMovementActive = false;

        public static void UpdateAll()
        {
            UpdateRundownSelections();
            UpdateWatermark(m_watermarkInstance);
            UpdateMiscFeatures();
            if (m_rundownInstance.m_rundownIsRevealed)
            {
                UpdateExpeditionIcons();
            }
            if (m_activeMiscRundownData.EnableERCDataReload)
            {
                AddReloadButton();
            }
        }

        public static void AddReloadButton()
        {
            if (m_rundownInstance == null)
            {
                return;
            }
            //Log.Info("Adding reload button");
            m_rundownInstance.m_matchmakeAllButton.SetText("RELOAD ERC DATA");
            m_rundownInstance.m_matchmakeAllButton.OnBtnPressCallback = (Action<int>)((id) => JsonHandler.OnHotReload());
        }

        public static List<GameObject> rundownSelectors = new();

        public static void UpdateRundownSelections(bool isRepeat = false)
        {
            AddReloadButton();
            //Log.Info("Updating Rundown Selections");
            if (!m_activeRundownSelectionData.Enabled)
            {
                //Log.Info("Rundown Selection data is not enabled");
                return;
            }
            CM_PageRundown_New __instance = m_rundownInstance;

            if (__instance == null)
            {
                Log.Info("Instance is null");
                return;
            }

            UpdateMiscFeatures();

            if (m_rundownInstance.m_currentRundownData != null)
            {
                __instance.m_textRundownHeaderTop.text = "<color=white><size=300%>" + m_rundownInstance.m_currentRundownData.StorytellingData.Title;
                return;
            }

            __instance.m_textRundownHeader.text = m_activeRundownSelectionData.TextHeader;
            __instance.m_textRundownHeaderTop.text = m_activeRundownSelectionData.TextHeaderTop;

            if (__instance.m_rundownIsRevealed)
            {
                __instance.m_textRundownHeader.text = m_rundownInstance.m_currentRundownData.StorytellingData.Title;
            }

            // CM_PageRundown_New.m_rundownSelections is in the same order they're reveleaed in (1, 7, 2... 6, 8)
            // so order the active selections accordingly
            RundownSelector[] activeRundownSelections = [
                m_activeRundownSelectionData.Selector_R1,
                m_activeRundownSelectionData.Selector_R7,
                m_activeRundownSelectionData.Selector_R2,
                m_activeRundownSelectionData.Selector_R3,
                m_activeRundownSelectionData.Selector_R4,
                m_activeRundownSelectionData.Selector_R5,
                m_activeRundownSelectionData.Selector_R6,
                m_activeRundownSelectionData.Selector_R8,
            ];

            for (int i = 0; i < __instance.m_rundownSelections.Count; i++)
            {
                CM_RundownSelection selector = __instance.m_rundownSelections[i];
                RundownSelector selector_data = activeRundownSelections[i];
                
                UpdateRundownSelector(selector, selector_data);

            }

            void UpdateRundownSelector(CM_RundownSelection comp, RundownSelector data)
            {
                comp.transform.localPosition = data.pos;
                comp.transform.localRotation = Quaternion.Euler(data.rot);
                comp.transform.localScale = data.scale;

                // R7 and R8 are special cases, R7 has the text component but it's not assigned, and R8 doesn't have it at all
                if (comp.transform.GetChildCount() < 3) // only R8 has 3 children because of this situation
                {
                    if (comp.m_altText == null) // Object structure suggests that it has alt text tmp, but not assigned
                    {
                        comp.m_altText = comp.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
                        comp.m_altText.gameObject.SetActive(true);
                    }
                    comp.m_altText.text = data.altText;
                    comp.m_altText.transform.localPosition = data.altTextPos;
                }
                else // if was R8, then all of this^ would pass by
                {
                    /* To keep everything hidden properly and forever, we can't just deactivate the game object, as reentering the selector screen would show them again
                    *  Normally everything's fine, because everything that would stay shown is under sub objects
                    *  The one exception is the R8 Friends Hosting text, which if it somehow decided to show, would bypass the game objects being deactivated
                    *  so if its holder is still present, parent it to another sub object 
                    *  this doesn't break component references, so things still update fine  */
                    var friendGO = comp.transform.Find("FriendsHosting");
                    if (friendGO != null) // hasn't already been moved
                    {
                        Transform friendHolder = new GameObject("TextHolder").transform;
                        friendHolder.SetParent(comp.transform, worldPositionStays: false);
                        friendGO.SetParent(friendHolder, worldPositionStays: true);


                        /* repeat this whole process for the rundown text as well
                        *  don't want to use the SAME holder because then child count will change for the above alt text logic
                        *  also using the same if block because the idea is just to have done this exactly once
                        *  so don't run the extra transform.Find() and null check */
                        var textGO = comp.transform.Find("RundownText");
                        Transform textHolder = new GameObject("TextHolder").transform;
                        textHolder.SetParent(comp.transform, worldPositionStays: false);
                        textGO.SetParent(textHolder, worldPositionStays: true);
                    }
                }
                
                comp.m_rundownText.text = data.name;
                comp.m_rundownText.transform.localPosition = data.namePos;
                // scale the text parent so it applies to the alt and rundown text equally
                comp.m_rundownText.transform.parent.localScale = data.textScale;
                // inverse the text's rotation so it doesn't look weird
                comp.m_rundownText.transform.parent.localRotation = Quaternion.Inverse(comp.transform.localRotation);

                comp.m_originalColor = data.color;
                // Calling these functions are what will actually update the color
                if (comp.m_isHovering)
                    comp.OnHoverIn();
                else
                    comp.OnHoverOut(); // OnHoverOut is used for future proofing for liveedit

                    // Enable all objects that should be enabled (i.e they already were)
                    for (int i = 0; i < comp.transform.GetChildCount(); i++)
                    {
                        GameObject obj = comp.transform.GetChild(i).gameObject;
                    obj.SetActive(data.show);
                    }
                // remove collider so you can't still enter the screen if you click the right spot lol
                comp.m_collider.enabled = data.show;
            }
        }

        public static void UpdateExpeditionIcons()
        {
            UpdateMiscFeatures();
            if (!m_activeGlobalRundownLayoutData.Enabled)
            {
                //Log.Info("Rundown layout disabled");
                return;
            }
            if (m_rundownInstance == null)
            {
                Log.Error("m_rundownInstance is null");
                return;
            }

            m_rundownInstance.m_textRundownHeader.text = m_rundownInstance.m_currentRundownData.StorytellingData.Title;

            int index;
            void UpdateIcon(CM_ExpeditionIcon_New expIcon, ExpeditionButton data)
            {
                //Log.Info("Updating Expedition Icon");
                if (expIcon == null)
                {
                    Log.Error("expIcon was null in UpdateIcon");
                    return;
                }
                expIcon.SetShortName("<color=white>" + data.label);
                expIcon.transform.localPosition = data.buttonPos;
                if (data.changeScale)
                {
                    expIcon.transform.localScale = data.buttonScale;
                }
                //Since local prog sets the colour earlier I'm free to override it here
                //And yes my dumbass put it in the wrong thing i woke up 20 minutes ago okay
                expIcon.m_colorUnlocked = data.buttonColor;
                expIcon.m_colorStory = data.buttonColor;
                expIcon.m_colorLocked = data.buttonColor;

                // Set the hoverout alpha since the expedition icon gets reset frequently anyway
                // the hoverout color change doesn't stay long and causes a small visual bug
                expIcon.m_spriteAlphaOut = expIcon.m_spriteAlphaOver;
                expIcon.SetBorderColor(data.buttonColor);
                expIcon.m_artifactHeatText.gameObject.SetActive(data.enableHeat);
                expIcon.m_artifactHeatText.text = data.heatText;
                expIcon.m_statusText.transform.localPosition = data.statusPos;
                if (data.overrideDecryptText)
                {
                    expIcon.m_decryptErrorText.gameObject.SetActive(true);
                    expIcon.m_decryptErrorText.text = data.decryptText;
                }
                if (expIcon._Status_k__BackingField == eExpeditionIconStatus.TierLocked && expIcon.Accessibility == eExpeditionAccessibility.UnlockedByExpedition)
                {
                    expIcon.SetUnlockedByText();
                }
                expIcon.m_statusText.color = new UnityEngine.Color(1, 1, 1, 1);
                index++;

                InteropAPI.ExecuteWhenPluginExists("Inas.LocalProgression", (BepInEx.PluginInfo _) => DoLocalProgressionStuff(expIcon));

                //Log.Info("Updated Icon");
            }

            void DoLocalProgressionStuff(CM_ExpeditionIcon_New expIcon)
            {
                //local prog bs starts here
                var rundownID = LocalProgressionManager.Current.ActiveRundownID();
                var lpData = LocalProgressionManager.Current.GetExpeditionLP(rundownID, expIcon.Tier, expIcon.ExpIndex);
                UnityEngine.Color BORDER_COLOR = new(0f, 1f, 246f / 255f, 0.5f);

                //if custom local prog box exists
                if (expIcon.transform.childCount > 1)
                {
                    SpriteRenderer[] boxSprites2 = expIcon.transform.GetChild(1).GetComponentsInChildren<SpriteRenderer>();
                    foreach (var sprite in boxSprites2)
                    {
                        if (lpData.NoBoosterAllClearCount <= 0)
                        {
                            sprite.color = new UnityEngine.Color(0, 0, 0, 0);
                        }
                        else
                        {
                            sprite.color = BORDER_COLOR;
                        }
                    }
                    return;
                }

                //Make the new fuckass box and set the colour (this could be optimised but idrc)
                GameObject newBox = GameObject.Instantiate(expIcon.transform.GetChild(0).GetChild(1).gameObject, expIcon.transform);
                newBox.transform.localPosition = new UnityEngine.Vector3(-3, 0, 0);
                newBox.transform.localScale = new UnityEngine.Vector3(0.97f, 0.97f, 0.97f);
                SpriteRenderer[] boxSprites = newBox.GetComponentsInChildren<SpriteRenderer>();
                foreach (var sprite in boxSprites)
                {
                    if (lpData.NoBoosterAllClearCount <= 0)
                    {
                        sprite.color = new UnityEngine.Color(0, 0, 0, 0);
                    }
                    else
                    {
                        sprite.color = BORDER_COLOR;
                    }
                }
            }

            void UpdateRundown(IndividualRundownLayout data)
            {
                if (data == null)
                {
                    Log.Error("Data was null aborting UpdateRundown");
                    return;
                }
                if (!data.Enabled)
                {
                    //Log.Info("Data segment was disabled returning;");
                    return;
                }

                index = 0;
                if (data.Tier1 != null)
                {
                    foreach (var tier1 in data.Tier1)
                    {
                        if (m_rundownInstance.m_expIconsTier1 == null)
                        {
                            break;
                        }
                        if (m_rundownInstance.m_expIconsTier1.Count <= index)
                        {
                            break;
                        }
                        UpdateIcon(m_rundownInstance.m_expIconsTier1[index], tier1);
                    }
                }

                index = 0;
                if (data.Tier2 != null)
                {
                    foreach (var tier2 in data.Tier2)
                    {
                        if (m_rundownInstance.m_expIconsTier2 == null)
                        {
                            break;
                        }
                        if (m_rundownInstance.m_expIconsTier2.Count <= index)
                        {
                            break;
                        }
                        UpdateIcon(m_rundownInstance.m_expIconsTier2[index], tier2);
                    }
                }

                index = 0;
                if (data.Tier3 != null)
                {
                    foreach (var tier3 in data.Tier3)
                    {
                        if (m_rundownInstance.m_expIconsTier3 == null)
                        {
                            break;
                        }
                        if (m_rundownInstance.m_expIconsTier3.Count <= index)
                        {
                            break;
                        }
                        UpdateIcon(m_rundownInstance.m_expIconsTier3[index], tier3);
                    }
                }

                index = 0;
                if (data.Tier4 != null)
                {
                    foreach (var tier4 in data.Tier4)
                    {
                        if (m_rundownInstance.m_expIconsTier4 == null)
                        {
                            break;
                        }
                        if (m_rundownInstance.m_expIconsTier4.Count! <= 0)
                        {
                            break;
                        }
                        UpdateIcon(m_rundownInstance.m_expIconsTier4[index], tier4);
                    }
                }

                index = 0;
                if (data.Tier5 != null)
                {
                    foreach (var tier5 in data.Tier5)
                    {
                        if (m_rundownInstance.m_expIconsTier5 == null)
                        {
                            break;
                        }
                        if (m_rundownInstance.m_expIconsTier5.Count! <= 0)
                        {
                            break;
                        }
                        UpdateIcon(m_rundownInstance.m_expIconsTier5[index], tier5);
                    }
                }

                if (m_rundownInstance.m_guix_Tier2.gameObject.active)
                {
                    GameObject extPage = m_rundownInstance.m_guix_Ext.gameObject;
                    extPage.SetActive(data.EnableExtensionPage);
                    extPage.transform.localPosition = data.ExtensionPagePos;
                    extPage.transform.localScale = new UnityEngine.Vector3(0.85f, 0.85f, 0.85f);
                    m_rundownInstance.m_externalExpHeader.text = data.ExtensionPageText;
                }
            }

            IndividualRundownLayout[] allRundownDatas = [
                m_activeGlobalRundownLayoutData.R1,
                m_activeGlobalRundownLayoutData.R2,
                m_activeGlobalRundownLayoutData.R3,
                m_activeGlobalRundownLayoutData.R4,
                m_activeGlobalRundownLayoutData.R5,
                m_activeGlobalRundownLayoutData.R6,
                m_activeGlobalRundownLayoutData.R7,
                m_activeGlobalRundownLayoutData.R8
                ];
            var correctRundown = allRundownDatas.FirstOrDefault(rundownData =>
                rundownData.RundownDatablockID == m_rundownInstance.m_currentRundownData.persistentID
            );

            if (correctRundown != null)
                UpdateRundown(correctRundown);
        }

        public static void UpdateMiscFeatures(bool isRepeat = false)
        {
            //Log.Info("Updating Misc features");
            if (m_activeMiscRundownData == null)
            {
                Log.Error("Misc feature data was null");
                return;
            }

            if (m_rundownInstance == null)
            {
                Log.Error("rundown instance was null");
                return;
            }

            if (!m_activeMiscRundownData.Enabled)
            {
                //Log.Debug("Misc rundown features not enabled");
                return;
            }

            if (MTFOHotReloadAPI.HotReloadEnabled)
            {
                
                //Log.Info("Fixing MTFO hotreload button");
                Transform buttonMenu = m_rundownInstance.transform.GetChild(2).GetChild(3);

                for (int i = 0; i < buttonMenu.childCount; i++)
                {
                    if (buttonMenu.GetChild(i).name == "Button HotReload")
                    {
                        buttonMenu.GetChild(i).GetChild(0).gameObject.SetActive(true);
                        buttonMenu.GetChild(i).GetComponent<TextMeshPro>().enabled = true;
                        buttonMenu.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
                    }
                }
            }
            //Log.Info("MTFO Hotreload done");

            m_rundownInstance.m_buttonVanityItemDrops.transform.GetChild(0).gameObject.SetActive(m_activeMiscRundownData.EnableVanityPage);
            m_rundownInstance.m_buttonVanityItemDrops.GetComponent<BoxCollider2D>().enabled = m_activeMiscRundownData.EnableVanityPage;
            m_rundownInstance.m_buttonVanityItemDrops.GetComponent<TextMeshPro>().enabled = m_activeMiscRundownData.EnableVanityPage;
            m_rundownInstance.m_vanityItemDropsNext.transform.GetChild(0).gameObject.SetActive(m_activeMiscRundownData.EnableVanityPage);
            m_rundownInstance.m_vanityItemDropsNext.transform.GetChild(1).gameObject.SetActive(m_activeMiscRundownData.EnableVanityPage);
            //Log.Info("vanity page fixed");

            if (!m_activeMiscRundownData.EnableSectorSummary)
            {
                if (m_rundownInstance.m_tierMarkerSectorSummary == null)
                {
                    goto suddenDeath;
                }
                m_rundownInstance.m_tierMarkerSectorSummary.transform.localPosition = new UnityEngine.Vector3(90000, 0, 0);
            }
            else
            {
                if (m_rundownInstance.m_tierMarkerSectorSummary == null)
                {
                    goto suddenDeath;
                }
                m_rundownInstance.m_tierMarkerSectorSummary.transform.localPosition = m_activeMiscRundownData.SectorSummaryPosition;
                m_rundownInstance.m_tierMarkerSectorSummary.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
            suddenDeath:
            //Log.Info("Sector Summary done");

            if (m_rundownInstance.m_rundownIsRevealed)
            {
                foreach (var obj in m_rundownInstance.m_rundownSelections)
                {
                    obj.gameObject.SetActive(false);
                }
                //Log.Info("disabled rundown selectors");

                if (m_activeMiscRundownData.OverrideTierMarkerText)
                {
                    //Log.Info("Overriding tier marker text");
                    if (customTierMarker1 == null)
                    {
                        SetupRundownFeatures();
                    }
                    customTierMarker1.transform.SetSiblingIndex(m_rundownInstance.m_rundownHolder.childCount - 1);
                    customTierMarker2.transform.SetSiblingIndex(m_rundownInstance.m_rundownHolder.childCount - 1);
                    customTierMarker3.transform.SetSiblingIndex(m_rundownInstance.m_rundownHolder.childCount - 1);
                    customTierMarker4.transform.SetSiblingIndex(m_rundownInstance.m_rundownHolder.childCount - 1);
                    customTierMarker5.transform.SetSiblingIndex(m_rundownInstance.m_rundownHolder.childCount - 1);
                    CM_RundownTierMarker tierMarker1 = customTierMarker1.GetComponent<CM_RundownTierMarker>();
                    CM_RundownTierMarker tierMarker2 = customTierMarker2.GetComponent<CM_RundownTierMarker>();
                    CM_RundownTierMarker tierMarker3 = customTierMarker3.GetComponent<CM_RundownTierMarker>();
                    CM_RundownTierMarker tierMarker4 = customTierMarker4.GetComponent<CM_RundownTierMarker>();
                    CM_RundownTierMarker tierMarker5 = customTierMarker5.GetComponent<CM_RundownTierMarker>();
                    tierMarker1.m_header.text = m_activeMiscRundownData.Tier1Text;
                    tierMarker2.m_header.text = m_activeMiscRundownData.Tier2Text;
                    tierMarker3.m_header.text = m_activeMiscRundownData.Tier3Text;
                    tierMarker4.m_header.text = m_activeMiscRundownData.Tier4Text;
                    tierMarker5.m_header.text = m_activeMiscRundownData.Tier5Text;
                    customTierMarker1.transform.localPosition = new UnityEngine.Vector3(0, -205, 0);
                    customTierMarker2.transform.localPosition = new UnityEngine.Vector3(0, -435, 0);
                    customTierMarker3.transform.localPosition = new UnityEngine.Vector3(0, -665, 0);
                    customTierMarker4.transform.localPosition = new UnityEngine.Vector3(0, -895, 0);
                    customTierMarker5.transform.localPosition = new UnityEngine.Vector3(0, -1125, 0);
                    customTierMarker1.SetActive(true);
                    customTierMarker2.SetActive(true);
                    customTierMarker3.SetActive(true);
                    customTierMarker4.SetActive(true);
                    customTierMarker5.SetActive(true);

                    m_rundownInstance.m_tierMarker1.gameObject.SetActive(false);
                    m_rundownInstance.m_tierMarker2.gameObject.SetActive(false);
                    m_rundownInstance.m_tierMarker3.gameObject.SetActive(false);
                    m_rundownInstance.m_tierMarker4.gameObject.SetActive(false);
                    m_rundownInstance.m_tierMarker5.gameObject.SetActive(false);
                    //Log.Info("TierMarker override done");
                    goto killme;
                }

                m_rundownInstance.m_tierMarker1.gameObject.SetActive(m_activeMiscRundownData.EnableTierMarkers);
                m_rundownInstance.m_tierMarker1.m_header.color = new UnityEngine.Color(0.5189f, 0.5189f, 0.5189f, 0.2745f);
                m_rundownInstance.m_tierMarker2.gameObject.SetActive(m_activeMiscRundownData.EnableTierMarkers);
                m_rundownInstance.m_tierMarker3.gameObject.SetActive(m_activeMiscRundownData.EnableTierMarkers);
                m_rundownInstance.m_tierMarker4.gameObject.SetActive(m_activeMiscRundownData.EnableTierMarkers);
                m_rundownInstance.m_tierMarker5.gameObject.SetActive(m_activeMiscRundownData.EnableTierMarkers);
                //Log.Info("enabled tier markers (text not overridden)");

            killme:
                if (m_activeMiscRundownData.EnableERCDataReload)
                {
                    m_rundownInstance.m_matchmakeAllButton.gameObject.transform.localPosition = new UnityEngine.Vector3(0, 210, 0);
                    AddReloadButton();
                }
                //Log.Info("Added ERC data reload button");

                m_rundownInstance.transform.GetChild(2).GetChild(4).GetChild(18).gameObject.SetActive(false);
                m_rundownInstance.m_rundownIntelButton.gameObject.SetActive(m_activeMiscRundownData.EnableIntelButton);
                m_rundownInstance.m_rundownIntelButton.transform.localPosition = m_activeMiscRundownData.IntelButtonPosition;
                //Log.Info("Overridden intel button");
            }

            m_rundownInstance.m_matchmakeAllButton.transform.GetChild(0).gameObject.SetActive(m_activeMiscRundownData.EnableMatchmakingButton);
            m_rundownInstance.m_matchmakeAllButton.GetComponent<BoxCollider2D>().enabled = m_activeMiscRundownData.EnableMatchmakingButton;
            m_rundownInstance.m_matchmakeAllButton.GetComponent<TextMeshPro>().enabled = m_activeMiscRundownData.EnableMatchmakingButton;
            //Log.Info("Overriden matchmakAll button");

            if (m_activeMiscRundownData.EnableERCDataReload)
            {
                m_rundownInstance.m_matchmakeAllButton.transform.GetChild(0).gameObject.SetActive(true);
                m_rundownInstance.m_matchmakeAllButton.GetComponent<BoxCollider2D>().enabled = true;
                m_rundownInstance.m_matchmakeAllButton.GetComponent<TextMeshPro>().enabled = true;
                AddReloadButton();
            }
            //Log.Info("made ERC data reload button again?");
            m_rundownInstance.m_discordButton.transform.GetChild(0).gameObject.SetActive(m_activeMiscRundownData.EnableButtonDiscord);
            m_rundownInstance.m_discordButton.GetComponent<BoxCollider2D>().enabled = m_activeMiscRundownData.EnableButtonDiscord;
            m_rundownInstance.m_discordButton.GetComponent<TextMeshPro>().enabled = m_activeMiscRundownData.EnableButtonDiscord;
            m_rundownInstance.m_creditsButton.transform.GetChild(0).gameObject.SetActive(m_activeMiscRundownData.EnableButtonCredits);
            m_rundownInstance.m_creditsButton.GetComponent<BoxCollider2D>().enabled = m_activeMiscRundownData.EnableButtonCredits;
            m_rundownInstance.m_creditsButton.GetComponent<TextMeshPro>().enabled = m_activeMiscRundownData.EnableButtonCredits;
            m_rundownInstance.m_gifButton.transform.GetChild(0).gameObject.SetActive(m_activeMiscRundownData.EnableDOWGif);
            m_rundownInstance.m_tutorialButton.transform.GetChild(0).gameObject.SetActive(m_activeMiscRundownData.EnableTutorialButton);
            m_rundownInstance.m_tutorialButton.GetComponent<BoxCollider2D>().enabled = m_activeMiscRundownData.EnableTutorialButton;
        }

        public static void UpdateWatermark(PUI_Watermark __instance)
        {
            if (m_activeWatermarkData.Enabled)
            {
                __instance.m_watermarkText.text = m_activeWatermarkData.Text;
            }
        }

        private static GameObject customTierMarker1;
        private static GameObject customTierMarker2;
        private static GameObject customTierMarker3;
        private static GameObject customTierMarker4;
        private static GameObject customTierMarker5;

        public static void SetupRundownFeatures()
        {
            customTierMarker1 = GameObject.Instantiate(m_rundownInstance.m_tierMarkerPrefab, m_rundownInstance.m_rundownHolder);
            customTierMarker2 = GameObject.Instantiate(m_rundownInstance.m_tierMarkerPrefab, m_rundownInstance.m_rundownHolder);
            customTierMarker3 = GameObject.Instantiate(m_rundownInstance.m_tierMarkerPrefab, m_rundownInstance.m_rundownHolder);
            customTierMarker4 = GameObject.Instantiate(m_rundownInstance.m_tierMarkerPrefab, m_rundownInstance.m_rundownHolder);
            customTierMarker5 = GameObject.Instantiate(m_rundownInstance.m_tierMarkerPrefab, m_rundownInstance.m_rundownHolder);
            customTierMarker1.SetActive(false);
            customTierMarker2.SetActive(false);
            customTierMarker3.SetActive(false);
            customTierMarker4.SetActive(false);
            customTierMarker5.SetActive(false);
        }

        public static void LazyUpdate() //Not so lazy update :(
        {
            if (m_popupMovementActive)
            {
                foreach (CM_ExpeditionIcon_New icon in m_rundownInstance.m_expIconsAll)
                {
                    icon.m_collider.enabled = false;
                }
            }
            else
            {
                foreach (CM_ExpeditionIcon_New icon in m_rundownInstance.m_expIconsAll)
                {
                    icon.m_collider.enabled = true;
                }
            }
        }
    }
}
