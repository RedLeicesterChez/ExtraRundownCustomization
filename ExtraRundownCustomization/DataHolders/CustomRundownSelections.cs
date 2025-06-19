namespace ExtraRundownCustomization.DataHolders
{
    [System.Serializable]
    public class CustomRundownSelections
    {
        public bool Enabled { get; set; } = false;
        public string TextHeader { get; set; } = "SELECT RUNDOWN";
        public string TextHeaderTop { get; set; } = "<color=red>CLCTR MULTITHREAD PROCESSOR ACTIVATED";
        public Selection_R1 Selector_R1 { get; set; }
        public Selection_R2 Selector_R2 { get; set; }
        public Selection_R3 Selector_R3 { get; set; }
        public Selection_R4 Selector_R4 { get; set; }
        public Selection_R5 Selector_R5 { get; set; }
        public Selection_R6 Selector_R6 { get; set; }
        public Selection_R7 Selector_R7 { get; set; }
        public Selection_R8 Selector_R8 { get; set; }

        public void InitializeDefaults()
        {
            Selector_R1 = new();
            Selector_R2 = new();
            Selector_R3 = new();
            Selector_R4 = new();
            Selector_R5 = new();
            Selector_R6 = new();
            Selector_R7 = new();
            Selector_R8 = new();
        }
    }

    public class Selection_R1
    {
        public string name { get; set; } = "R1";
        public string altText { get; set; } = "<color=orange>ALT://";


        public float posX { get; set; } = -476.0f;
        public float posY { get; set; } = 45.0f;
        public float posZ { get; set; } = 0.0f;

        public float rotX { get; set; } = 0.0f;
        public float rotY { get; set; } = 0.0f;
        public float rotZ { get; set; } = 0.0f;

        public float scaleX { get; set; } = 0.6f;
        public float scaleY { get; set; } = 0.6f;
        public float scaleZ { get; set; } = 0.6f;

        public float namePosX { get; set; } = 0.0f;
        public float namePosY { get; set; } = 39.0f;
        public float namePosZ { get; set; } = 0.0f;

        public float altTextPosX { get; set; } = -46.0f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0.0f;
    }

    public class Selection_R2
    {
        public string name { get; set; } = "R2";
        public string altText { get; set; } = "<color=orange>ALT://";

        public float posX { get; set; } = -241f;
        public float posY { get; set; } = -78f;
        public float posZ { get; set; } = 0f;

        public float rotX { get; set; } = 0f;
        public float rotY { get; set; } = 0f;
        public float rotZ { get; set; } = 0f;

        public float scaleX { get; set; } = 0.8f;
        public float scaleY { get; set; } = 0.8f;
        public float scaleZ { get; set; } = 0.8f;

        public float namePosX { get; set; } = 0f;
        public float namePosY { get; set; } = 39f;
        public float namePosZ { get; set; } = 0f;

        public float altTextPosX { get; set; } = -46f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0f;
    }

    public class Selection_R3
    {
        public string name { get; set; } = "R3";
        public string altText { get; set; } = "<color=orange>ALT://";

        public float posX { get; set; } = -346f;
        public float posY { get; set; } = 179.6f;
        public float posZ { get; set; } = 13.956f;

        public float rotX { get; set; } = 0f;
        public float rotY { get; set; } = 0f;
        public float rotZ { get; set; } = 0f;

        public float scaleX { get; set; } = 0.8f;
        public float scaleY { get; set; } = 0.8f;
        public float scaleZ { get; set; } = 0.8f;

        public float namePosX { get; set; } = 0f;
        public float namePosY { get; set; } = 39f;
        public float namePosZ { get; set; } = 0f;

        public float altTextPosX { get; set; } = -46f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0f;
    }

    public class Selection_R4
    {
        public string name { get; set; } = "R4";
        public string altText { get; set; } = "<color=orange>ALT://";

        public float posX { get; set; } = -109f;
        public float posY { get; set; } = 226f;
        public float posZ { get; set; } = 0f;

        public float rotX { get; set; } = 0f;
        public float rotY { get; set; } = 0f;
        public float rotZ { get; set; } = 0f;

        public float scaleX { get; set; } = 1.2f;
        public float scaleY { get; set; } = 1.2f;
        public float scaleZ { get; set; } = 1.2f;

        public float namePosX { get; set; } = 0f;
        public float namePosY { get; set; } = 39f;
        public float namePosZ { get; set; } = 0f;

        public float altTextPosX { get; set; } = -46f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0f;
    }

    public class Selection_R5
    {
        public string name { get; set; } = "R5";
        public string altText { get; set; } = "<color=orange>ALT://";

        public float posX { get; set; } = 55f;
        public float posY { get; set; } = -16f;
        public float posZ { get; set; } = 0f;

        public float rotX { get; set; } = 0f;
        public float rotY { get; set; } = 0f;
        public float rotZ { get; set; } = 0f;

        public float scaleX { get; set; } = 1.1f;
        public float scaleY { get; set; } = 1.1f;
        public float scaleZ { get; set; } = 1.1f;

        public float namePosX { get; set; } = 0f;
        public float namePosY { get; set; } = 39f;
        public float namePosZ { get; set; } = 0f;

        public float altTextPosX { get; set; } = -46f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0f;
    }

    public class Selection_R6
    {
        public string name { get; set; } = "R6";
        public string altText { get; set; } = "<color=orange>ALT://";

        public float posX { get; set; } = 240f;
        public float posY { get; set; } = 235f;
        public float posZ { get; set; } = 0f;

        public float rotX { get; set; } = 0f;
        public float rotY { get; set; } = 0f;
        public float rotZ { get; set; } = 0f;

        public float scaleX { get; set; } = 1.09f;
        public float scaleY { get; set; } = 1.09f;
        public float scaleZ { get; set; } = 1.09f;

        public float namePosX { get; set; } = 0f;
        public float namePosY { get; set; } = 39f;
        public float namePosZ { get; set; } = 0f;

        public float altTextPosX { get; set; } = -46f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0f;
    }

    public class Selection_R7
    {
        public string name { get; set; } = "R7";
        public string altText { get; set; } = "<color=orange>ALT://";

        public float posX { get; set; } = 317f;
        public float posY { get; set; } = -104f;
        public float posZ { get; set; } = 0f;

        public float rotX { get; set; } = 0f;
        public float rotY { get; set; } = 0f;
        public float rotZ { get; set; } = 0f;

        public float scaleX { get; set; } = 1f;
        public float scaleY { get; set; } = 1f;
        public float scaleZ { get; set; } = 1f;

        public float namePosX { get; set; } = 0f;
        public float namePosY { get; set; } = 39f;
        public float namePosZ { get; set; } = 0f;

        public float altTextPosX { get; set; } = -46f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0f;
    }

    public class Selection_R8
    {
        public string name { get; set; } = "R8";
        public string altText { get; set; } = "<color=orange>ALT://";

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

        public float altTextPosX { get; set; } = -46f;
        public float altTextPosY { get; set; } = 34.8f;
        public float altTextPosZ { get; set; } = 0f;
    }
}