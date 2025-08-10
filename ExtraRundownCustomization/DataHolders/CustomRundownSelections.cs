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
            scale = new() { x = 0.6f, y = 0.6f, z = 0.6f },

            namePos = new() { x = 0.0f, y = 39.0f, z = 0.0f },
            altTextPos = new() { x = -46.0f, y = 34.8f, z = 0.0f },
        };

        public RundownSelector Selector_R2 { get; set; } = new RundownSelector
        {
            name = "R2",
            altText = "<color=orange>ALT://",

            pos = new() { x = -241f, y = -78f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 0.8f, y = 0.8f, z = 0.8f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R3 { get; set; } = new RundownSelector
        {
            name = "R3",
            altText = "<color=orange>ALT://",

            pos = new() { x = -346f, y = 179.6f, z = 13.956f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 0.8f, y = 0.8f, z = 0.8f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R4 { get; set; } = new RundownSelector
        {
            name = "R4",
            altText = "<color=orange>ALT://",

            pos = new() { x = -109f, y = 226f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.2f, y = 1.2f, z = 1.2f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R5 { get; set; } = new RundownSelector
        {
            name = "R5",
            altText = "<color=orange>ALT://",

            pos = new() { x = 55f, y = -16f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.1f, y = 1.1f, z = 1.1f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R6 { get; set; } = new RundownSelector
        {
            name = "R6",
            altText = "<color=orange>ALT://",

            pos = new() { x = 240f, y = 235f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1.09f, y = 1.09f, z = 1.09f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };

        public RundownSelector Selector_R7 { get; set; } = new RundownSelector
        {
            name = "R7",
            altText = "<color=orange>ALT://",

            pos = new() { x = 317f, y = -104f, z = 0f },
            rot = new() { x = 0f, y = 0f, z = 0f },
            scale = new() { x = 1f, y = 1f, z = 1f },

            namePos = new() { x = 0f, y = 39f, z = 0f },
            altTextPos = new() { x = -46f, y = 34.8f, z = 0f }
        };
        public Selection_R8 Selector_R8 { get; set; } = new();
    }

    public class RundownSelector
    {
        public bool enabled { get; set; } = true; // default value for backcompat
        public string name { get; set; }
        public string altText { get; set; }

        public Vector3 pos { get; set; }
        public Vector3 rot { get; set; }
        public Vector3 scale { get; set; }

        public Vector3 namePos { get; set; }
        public Vector3 altTextPos { get; set; }
        public Vector3 textScale { get; set; } = new() { x=1, y=1, z=1 };
    }
    public class Selection_R8
    {
        public bool enabled { get; set; } = true; // default value for backcompat
        public string name { get; set; } = "R8";

        public Vector3 pos { set; get; } = new() { x = 550.0f, y = 150.0f, z = 0.0f };
        public Vector3 rot { set; get; } = new() { x = 0.0f, y = 0.0f, z = 0.0f };
        public Vector3 scale { get; set; } = new() { x = 1.25f, y = 1.2f, z = 1.25f};

        public Vector3 namePos { get; set; } = new() { x = 0f, y = 39f, z = 0.0f };
        public Vector3 textScale { get; set; } = new() { x = 1, y = 1, z = 1 };

        // implicitly be able to cast this to save on some code later
        // Gotta be careful for if any values get added to either of these, gotta make sure it gets added to the other as well
        public static implicit operator RundownSelector(Selection_R8 selection)
        {
            return new()
            {
                enabled = selection.enabled,
                name = selection.name,
                pos = selection.pos,
                rot = selection.rot,
                scale = selection.scale,
                namePos = selection.namePos,
                textScale = selection.textScale,
            };
        }
    }
}