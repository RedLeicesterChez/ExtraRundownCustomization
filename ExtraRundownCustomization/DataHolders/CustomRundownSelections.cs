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

            posX = -476.0f,
            posY = 45.0f,
            posZ = 0.0f,

            rotX = 0.0f,
            rotY = 0.0f,
            rotZ = 0.0f,

            scaleX = 0.6f,
            scaleY = 0.6f,
            scaleZ = 0.6f,

            namePosX = 0.0f,
            namePosY = 39.0f,
            namePosZ = 0.0f,

            altTextPosX = -46.0f,
            altTextPosY = 34.8f,
            altTextPosZ = 0.0f
        };

        public RundownSelector Selector_R2 { get; set; } = new RundownSelector()
        {
            name = "R2",
            altText = "<color=orange>ALT://",

            posX = -241f,
            posY = -78f,
            posZ = 0f,

            rotX = 0f,
            rotY = 0f,
            rotZ = 0f,

            scaleX = 0.8f,
            scaleY = 0.8f,
            scaleZ = 0.8f,

            namePosX = 0f,
            namePosY = 39f,
            namePosZ = 0f,

            altTextPosX = -46f,
            altTextPosY = 34.8f,
            altTextPosZ = 0f
        };

        public RundownSelector Selector_R3 { get; set; } = new RundownSelector
        {
            name = "R3",
            altText = "<color=orange>ALT://",

            posX = -346f,
            posY = 179.6f,
            posZ = 13.956f,

            rotX = 0f,
            rotY = 0f,
            rotZ = 0f,

            scaleX = 0.8f,
            scaleY = 0.8f,
            scaleZ = 0.8f,

            namePosX = 0f,
            namePosY = 39f,
            namePosZ = 0f,

            altTextPosX = -46f,
            altTextPosY = 34.8f,
            altTextPosZ = 0f
        };

        public RundownSelector Selector_R4 { get; set; } = new RundownSelector
        {
            name = "R4",
            altText = "<color=orange>ALT://",

            posX = -109f,
            posY = 226f,
            posZ = 0f,

            rotX = 0f,
            rotY = 0f,
            rotZ = 0f,

            scaleX = 1.2f,
            scaleY = 1.2f,
            scaleZ = 1.2f,

            namePosX = 0f,
            namePosY = 39f,
            namePosZ = 0f,

            altTextPosX = -46f,
            altTextPosY = 34.8f,
            altTextPosZ = 0f
        };

        public RundownSelector Selector_R5 { get; set; } = new RundownSelector
        {
            name = "R5",
            altText = "<color=orange>ALT://",

            posX = 55f,
            posY = -16f,
            posZ = 0f,

            rotX = 0f,
            rotY = 0f,
            rotZ = 0f,

            scaleX = 1.1f,
            scaleY = 1.1f,
            scaleZ = 1.1f,

            namePosX = 0f,
            namePosY = 39f,
            namePosZ = 0f,

            altTextPosX = -46f,
            altTextPosY = 34.8f,
            altTextPosZ = 0f
        };

        public RundownSelector Selector_R6 { get; set; } = new RundownSelector
        {
            name = "R6",
            altText = "<color=orange>ALT://",

            posX = 240f,
            posY = 235f,
            posZ = 0f,

            rotX = 0f,
            rotY = 0f,
            rotZ = 0f,

            scaleX = 1.09f,
            scaleY = 1.09f,
            scaleZ = 1.09f,

            namePosX = 0f,
            namePosY = 39f,
            namePosZ = 0f,

            altTextPosX = -46f,
            altTextPosY = 34.8f,
            altTextPosZ = 0f
        };

        public RundownSelector Selector_R7 { get; set; } = new RundownSelector
        {
            name = "R7",
            altText = "<color=orange>ALT://",

            posX = 317f,
            posY = -104f,
            posZ = 0f,

            rotX = 0f,
            rotY = 0f,
            rotZ = 0f,

            scaleX = 1f,
            scaleY = 1f,
            scaleZ = 1f,

            namePosX = 0f,
            namePosY = 39f,
            namePosZ = 0f,

            altTextPosX = -46f,
            altTextPosY = 34.8f,
            altTextPosZ = 0f
        };
        public Selection_R8 Selector_R8 { get; set; } = new();
    }

    public class RundownSelector
    {
        public string name { get; set; }
        public string altText { get; set; }


        public float posX { get; set; }
        public float posY { get; set; }
        public float posZ { get; set; }

        public float rotX { get; set; }
        public float rotY { get; set; }
        public float rotZ { get; set; }

        public float scaleX { get; set; }
        public float scaleY { get; set; }
        public float scaleZ { get; set; }

        public float namePosX { get; set; }
        public float namePosY { get; set; }
        public float namePosZ { get; set; }

        public float altTextPosX { get; set; }
        public float altTextPosY { get; set; }
        public float altTextPosZ { get; set; }
    }
    public class Selection_R8
    {
        public string name { get; set; } = "R8";

        public float posX { get; set; } = 550f;
        public float posY { get; set; } = 150f;
        public float posZ { get; set; } = 0f;

        public float rotX { get; set; } = 0f;
        public float rotY { get; set; } = 0f;
        public float rotZ { get; set; } = 0f;

        public float scaleX { get; set; } = 1.25f;
        public float scaleY { get; set; } = 1.2f;
        public float scaleZ { get; set; } = 1.25f;

        public float namePosX { get; set; } = 0f;
        public float namePosY { get; set; } = 39f;
        public float namePosZ { get; set; } = 0f;
    }
}