using MTFO.API;
using System.IO;
using ExtraRundownCustomization.DataHolders;
using System.Text.Json;
using System.Text.Encodings.Web;
using ExtraRundownCustomization.Handlers;

namespace ExtraRundownCustomization.Utils
{
    public class JsonHandler
    {
        private static string ERC_CustomPath;
        public static void SetupJson()
        {
            if (!MTFOPathAPI.HasCustomPath)
            {
                Log.Error("MTFO Custom path does not exist please ensure one exists before continuing");
                return;
            }

            ERC_CustomPath = Path.Combine(MTFOPathAPI.CustomPath, "ExtraRundownCustomisation");

            if (!Directory.Exists(ERC_CustomPath))
            {
                Directory.CreateDirectory(ERC_CustomPath);
            }

            Log.Info("ERC Custom path loaded");

            MTFOHotReloadAPI.OnHotReload += OnHotReload;

            LoadJson();
        }

        private static void LoadJson(bool isHotReload = false)
        {
            Log.Info("Loading Json Data");

            //Rundown Selection loading
            string customRundownSelectionsPath = Path.Combine(ERC_CustomPath + "/rundownSelectors.json");
            if (!File.Exists(customRundownSelectionsPath))
            {
                CustomRundownSelections json = new();
                var jsonData = JsonSerializer.Serialize(json, _setting);
                File.WriteAllText(customRundownSelectionsPath, jsonData);
            }
            var codedRundownSelectionJson = File.ReadAllText(customRundownSelectionsPath);
            CustomRundownSelections rundownSelectionDecoded = JsonSerializer.Deserialize<CustomRundownSelections>(codedRundownSelectionJson, _setting);
            RundownMenuHandlers.m_activeRundownSelectionData = rundownSelectionDecoded;

            //Rundown Layout loading
            string customRundownLayoutPath = Path.Combine(ERC_CustomPath + "/rundownLayouts.json");
            if (!File.Exists(customRundownLayoutPath))
            {
                RundownLayout json = new();
                var jsonData = JsonSerializer.Serialize(json, _setting);
                File.WriteAllText(customRundownLayoutPath, jsonData);
            }
            var codedRundownLayoutJson = File.ReadAllText(customRundownLayoutPath);
            RundownLayout rundownLayoutDecoded = JsonSerializer.Deserialize<RundownLayout>(codedRundownLayoutJson, _setting);
            RundownMenuHandlers.m_activeGlobalRundownLayoutData = rundownLayoutDecoded;

            //ExtraRundownDataLoading
            string miscRundownFeaturePath = Path.Combine(ERC_CustomPath + "/miscFeatures.json");
            if (!File.Exists(miscRundownFeaturePath))
            {
                MiscRundownData json = new();
                var jsonData = JsonSerializer.Serialize(json, _setting);
                File.WriteAllText(miscRundownFeaturePath, jsonData);
            }
            var codedExtraRundownJson = File.ReadAllText(miscRundownFeaturePath);
            MiscRundownData miscRundownDataDecoded = JsonSerializer.Deserialize<MiscRundownData>(codedExtraRundownJson, _setting);
            RundownMenuHandlers.m_activeMiscRundownData = miscRundownDataDecoded;

            //Watermark loading
            string customWatermarkPath = Path.Combine(ERC_CustomPath + "/watermark.json");
            if (!File.Exists(customWatermarkPath))
            {
                CustomWatermark json = new();
                var jsonData = JsonSerializer.Serialize(json, _setting);
                File.WriteAllText(customWatermarkPath, jsonData);
            }
            var codedWatermarkJson = File.ReadAllText(customWatermarkPath);
            CustomWatermark customWatermarkDecoded = JsonSerializer.Deserialize<CustomWatermark>(codedWatermarkJson, _setting);
            RundownMenuHandlers.m_activeWatermarkData = customWatermarkDecoded;

            Log.Info("Json data Loaded");

            if (isHotReload)
            {
                RundownMenuHandlers.UpdateAll();
            }
        }

        public static void OnHotReload()
        {
            Log.Info("Reloading json");
            LoadJson(true);
        }

        private static readonly JsonSerializerOptions _setting = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            IgnoreReadOnlyProperties = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
    }
}
