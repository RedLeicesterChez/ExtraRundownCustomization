namespace ExtraRundownCustomization.DataHolders
{
    public class MiscRundownData
    {
        public bool Enabled { get; set; } = false;
        public bool EnableTutorialButton { get; set; } = true;
        public bool EnableMatchmakingButton { get; set; } = true;
        public bool EnableButtonAboutTheRundown { get; set; } = true;
        public bool EnableButtonDiscord { get; set; } = true;
        public bool EnableButtonCredits { get; set; } = true;
        public bool EnableDOWGif { get; set; } = false;
        public bool EnableVanityPage { get; set; } = true;
        public bool EnableIntelButton { get; set; } = true;
        public Vector3 IntelButtonPosition { get; set; } = new() { x = 0.0f, y = 20.0f, z = -70.0f };
        public bool EnableSectorSummary { get; set; } = true;
        public Vector3 SectorSummaryPosition { get; set; } = new() { x = 0.0f, y = 0.0f, z = 0.0f, };
        public bool EnableTierMarkers { get; set; } = false;
        public bool OverrideTierMarkerText { get; set; } = false;
        public string Tier1Text { get; set; } = "Tier A";
        public string Tier2Text { get; set; } = "Tier B";
        public string Tier3Text { get; set; } = "Tier C";
        public string Tier4Text { get; set; } = "Tier D";
        public string Tier5Text { get; set; } = "Tier E";
    }
}
