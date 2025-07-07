namespace ExtraRundownCustomization.DataHolders
{
    [System.Serializable]
    public class RundownLayout
    {
        public bool Enabled { get; set; } = false;
        public IndividualRundownLayout R1 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 32,

            Tier1 = [
                new ExpeditionButton()
                {
                    label = "R1A1",
                    buttonPos = new Vector3()
                    {
                        x = -75.0f,
                        y = 0.0f,
                        z = 0.0f,
                    },
                    buttonScale = new Vector3()
                    {
                        x = 10.0f,
                        y = 10.0f,
                        z = 10.0f,
                    },
                    buttonColor = new Color()
                    {
                        r = 1.0f,
                        g = 1.0f,
                        b = 1.0f,
                        a = 1.0f,
                    },
                    enableHeat = true,
                    heatText = "ARTIFACT HEAT: <color=orange>100%",
                    statusPos = new Vector3
                    {
                        x = -156.378f,
                        y = -67.81f,
                        z = -1.36f,
                    },
                    overrideDecryptText = false,
                    decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
                },
            ],

            Tier2 = [
                new ExpeditionButton()
                {
                    label = "R1B1",
                    buttonPos = new Vector3()
                    {
                        x = -412.5f,
                        y = 0.0f,
                        z = 0.0f,
                    },
                    buttonScale = new Vector3()
                    {
                        x = 1.818f,
                        y = 1.818f,
                        z = 1.818f,
                    },
                    buttonColor = new Color()
                    {
                        r = 1.0f,
                        g = 1.0f,
                        b = 1.0f,
                        a = 1.0f,
                    },
                    enableHeat = true,
                    heatText = "ARTIFACT HEAT: <color=orange>100%",
                    statusPos = new Vector3
                    {
                        x = -156.378f,
                        y = -67.81f,
                        z = -1.36f,
                    },
                    overrideDecryptText = false,
                    decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
                },

                new ExpeditionButton()
                {
                    label = "R1B2",
                    buttonPos = new Vector3()
                    {
                        x = 412.5f,
                        y = 0.0f,
                        z = 0.0f,
                    },
                    buttonScale = new Vector3()
                    {
                        x = 1.818f,
                        y = 1.818f,
                        z = 1.818f,
                    },
                    buttonColor = new Color()
                    {
                        r = 1.0f,
                        g = 1.0f,
                        b = 1.0f,
                        a = 1.0f,
                    },
                    enableHeat = true,
                    heatText = "ARTIFACT HEAT: <color=orange>100%",
                    statusPos = new Vector3
                    {
                        x = -156.378f,
                        y = -67.81f,
                        z = -1.36f,
                    },
                    overrideDecryptText = false,
                    decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
                },
            ],

            Tier3 = [
                new ExpeditionButton()
                {
                    label = "R1C1",
                    buttonPos = new Vector3()
                    {
                        x = -487.5f,
                        y = 0.0f,
                        z = 0.0f,
                    },
                    buttonScale = new Vector3()
                    {
                        x = 1.5385f,
                        y = 1.5385f,
                        z = 1.5385f,
                    },
                    buttonColor = new Color()
                    {
                        r = 1.0f,
                        g = 1.0f,
                        b = 1.0f,
                        a = 1.0f,
                    },
                    enableHeat = true,
                    heatText = "ARTIFACT HEAT: <color=orange>100%",
                    statusPos = new Vector3
                    {
                        x = -156.378f,
                        y = -67.81f,
                        z = -1.36f,
                    },
                    overrideDecryptText = false,
                    decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
                },

                new ExpeditionButton()
                {
                    label = "R1C2",
                    buttonPos = new Vector3()
                    {
                        x = 487.5f,
                        y = 0.0f,
                        z = 0.0f,
                    },
                    buttonScale = new Vector3()
                    {
                        x = 1.5385f,
                        y = 1.5385f,
                        z = 1.5385f,
                    },
                    buttonColor = new Color()
                    {
                        r = 1.0f,
                        g = 1.0f,
                        b = 1.0f,
                        a = 1.0f,
                    },
                    enableHeat = true,
                    heatText = "ARTIFACT HEAT: <color=orange>100%",
                    statusPos = new Vector3
                    {
                        x = -156.378f,
                        y = -67.81f,
                        z = -1.36f,
                    },
                    overrideDecryptText = false,
                    decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
                },
            ],

            Tier4 = [
                new ExpeditionButton()
                {
                    label = "R1D1",
                    buttonPos = new Vector3()
                    {
                        x = -75.0f,
                        y = 0.0f,
                        z = 0.0f,
                    },
                    buttonScale = new Vector3()
                    {
                        x = 10.0f,
                        y = 10.0f,
                        z = 10.0f,
                    },
                    buttonColor = new Color()
                    {
                        r = 1.0f,
                        g = 1.0f,
                        b = 1.0f,
                        a = 1.0f,
                    },
                    enableHeat = true,
                    heatText = "ARTIFACT HEAT: <color=orange>100%",
                    statusPos = new Vector3
                    {
                        x = -156.378f,
                        y = -67.81f,
                        z = -1.36f,
                    },
                    overrideDecryptText = false,
                    decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
                },
            ],

            Tier5 = []
        };

        public IndividualRundownLayout R2 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 33,

            Tier1 = [],

            Tier2 = [],

            Tier3 = [],

            Tier4 = [],

            Tier5 = []
        };

        public IndividualRundownLayout R3 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 34,

            Tier1 = [],

            Tier2 = [],

            Tier3 = [],

            Tier4 = [],

            Tier5 = []
        };

        public IndividualRundownLayout R4 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 37,

            Tier1 = [],

            Tier2 = [],

            Tier3 = [],

            Tier4 = [],

            Tier5 = []
        };

        public IndividualRundownLayout R5 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 38,

            Tier1 = [],

            Tier2 = [],

            Tier3 = [],

            Tier4 = [],

            Tier5 = []
        };

        public IndividualRundownLayout R6 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 41,

            Tier1 = [],

            Tier2 = [],

            Tier3 = [],

            Tier4 = [],

            Tier5 = []
        };

        public IndividualRundownLayout R7 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 31,

            Tier1 = [],

            Tier2 = [],

            Tier3 = [],

            Tier4 = [],

            Tier5 = []
        };

        public IndividualRundownLayout R8 { get; set; } = new IndividualRundownLayout()
        {
            Enabled = false,
            RundownDatablockID = 35,

            Tier1 = [],

            Tier2 = [],

            Tier3 = [],

            Tier4 = [],

            Tier5 = []
        };
    }

    [System.Serializable]
    public class IndividualRundownLayout
    {
        public bool Enabled { get; set; }
        public uint RundownDatablockID { get; set; }

        public ExpeditionButton[] Tier1 { get; set; }

        public ExpeditionButton[] Tier2 { get; set; }

        public ExpeditionButton[] Tier3 { get; set; }

        public ExpeditionButton[] Tier4 { get; set; }

        public ExpeditionButton[] Tier5 { get; set; }

        public bool EnableExtensionPage { get; set; } = false;
        public Vector3 ExtensionPagePos { get; set; } = new Vector3{ x = 0, y = -459, z = 0 };
        public string ExtensionPageText { get; set; } = "<color=orange>://EXT";
    }

    [System.Serializable]
    public class ExpeditionButton
    {
        public string label { get; set; }

        public Vector3 buttonPos { get; set; } = new();

        public bool changeScale { get; set; } = false;
        public Vector3 buttonScale { get; set; } = new();

        public Color buttonColor { get; set; } = new Color()
        {
            r = 1,
            g = 1,
            b = 1,
            a = 1,
        };

        public bool enableHeat { get; set; } = true;

        public string heatText { get; set; } = "ARTIFACT HEAT <color=orange>100%";

        public Vector3 statusPos { get; set; } = new Vector3
        {
            x = -156.378f,
            y = -67.81f,
            z = -1.36f,
        };

        public bool overrideDecryptText { get; set; } = false;

        public string decryptText { get; set; }
    }
}
