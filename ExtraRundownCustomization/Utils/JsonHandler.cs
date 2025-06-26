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
            string rundownSelectorsPath = Path.Combine(ERC_CustomPath + "/rundownSelectors.json");
            RundownMenuHandlers.m_activeRundownSelectionData = DeserializeJsonAndCreateIfNotReal(rundownSelectorsPath, new CustomRundownSelections());

            string rundownLayoutPath = Path.Combine(ERC_CustomPath + "/rundownLayouts.json");
            RundownMenuHandlers.m_activeGlobalRundownLayoutData = DeserializeJsonAndCreateIfNotReal(rundownLayoutPath, new RundownLayout());

            string miscRundownDataPath = Path.Combine(ERC_CustomPath + "/miscFeatures.json");
            RundownMenuHandlers.m_activeMiscRundownData = DeserializeJsonAndCreateIfNotReal(miscRundownDataPath, new MiscRundownData());

            string watermarkPath = Path.Combine(ERC_CustomPath + "/watermark.json");
            RundownMenuHandlers.m_activeWatermarkData = DeserializeJsonAndCreateIfNotReal(watermarkPath, new CustomWatermark());

            Log.Info("Json data Loaded");

            if (isHotReload)
            {
                RundownMenuHandlers.UpdateAll();
            }
        }

        private static T DeserializeJsonAndCreateIfNotReal<T>(string jsonPath, T data)
        {
            if (!File.Exists(jsonPath))
            {
                var jsonData = JsonSerializer.Serialize(data, _setting);
                File.WriteAllText(jsonPath, jsonData);
            }
            string codedJson = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<T>(codedJson, _setting);
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
