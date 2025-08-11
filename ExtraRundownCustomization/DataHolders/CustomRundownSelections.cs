using System.Text.Json.Serialization;

namespace ExtraRundownCustomization.DataHolders
{
    [System.Serializable]
    public class CustomRundownSelections
    {
        public bool Enabled { get; set; } = false;
        public string TextHeader { get; set; } = "SELECT RUNDOWN";
        public string TextHeaderTop { get; set; } = "<color=red>CLCTR MULTITHREAD PROCESSOR ACTIVATED";

        public RundownSelector Selector_R1 { get; set; } = new RundownSelector
        {
            name = "R1",
            altText = "<color=orange>ALT://",

            pos = new() { x = -476.0f, y = 45.0f, z = 0.0f },
            rot = new() { x = 0.0f, y = 0.0f, z = 0.0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0.0f, y = 39.0f, z = 0.0f },
            altTextPos = new() { x = -46.0f, y = 34.8f, z = 0.0f },
        };

        public RundownSelector Selector_R2 { get; set; } = new RundownSelector
        {
            name = "R2",
            altText = "<color=orange>ALT://",

            pos = new() { x = -241f, y = -78f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R3 { get; set; } = new RundownSelector
        {
            name = "R3",
            altText = "<color=orange>ALT://",

            pos = new() { x = -346f, y = 179.6f, z = 13.956f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R4 { get; set; } = new RundownSelector
        {
            name = "R4",
            altText = "<color=orange>ALT://",

            pos = new() { x = -109f, y = 226f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R5 { get; set; } = new RundownSelector
        {
            name = "R5",
            altText = "<color=orange>ALT://",

            pos = new() { x = 55f, y = -16f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R6 { get; set; } = new RundownSelector
        {
            name = "R6",
            altText = "<color=orange>ALT://",

            pos = new() { x = 240f, y = 235f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R7 { get; set; } = new RundownSelector
        {
            name = "R7",
            altText = "",

            pos = new() { x = 317f, y = -104f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };
        public RundownSelector_R8 Selector_R8 { get; set; } = new RundownSelector_R8
        {
            name = "R8",

            pos = new() { x = 550.0f, y = 150.0f, z = 0.0f },
            rot = new() { x = 0.0f, y = 0.0f, z = 0.0f },
            scale = new() { x = 1.0f, y = 1.0f, z = 1.0f },

            namePos = new() { x = 0f, y = 134f, z = 0.0f }
        };
    }

    public class RundownSelector
    {
        public bool show { get; set; } = true; // default value for backcompat
        public bool enabled { get; set; } = true;
        public string name { get; set; }
        public virtual string altText { get; set; }

        public Vector3 pos { get; set; }
        public Vector3 rot { get; set; }
        public Vector3 scale { get; set; }

        public Vector3 namePos { get; set; }
        public virtual Vector3 altTextPos { get; set; }
        public Vector3 textScale { get; set; } = new() { x = 1, y = 1, z = 1 };
        public Color color { get; set; } = new() { r = 1, g = 1, b = 1, a = 0.7843f };
    }
    public class RundownSelector_R8 : RundownSelector
    {
        [JsonIgnore]
        public override string altText { get; set; }
        [JsonIgnore]
        public override Vector3 altTextPos { get; set; }
    }
}