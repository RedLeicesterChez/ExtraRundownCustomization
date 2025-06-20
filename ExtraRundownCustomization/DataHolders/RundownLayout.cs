namespace ExtraRundownCustomization.DataHolders
{
    public class RundownLayout
    {
        public IndividualRundownLayout R1 { get; set; } = new IndividualRundownLayout()
        {
            RundownDatablockID = 32,

            Tier1 = new ExpeditionButton[]
            {
                new ExpeditionButton()
                {
                    label = "R1A1",
                    buttonPos = new Vector3()
                    {
                        x = -75,
                        y = 0,
                        z = 0,
                    },
                    buttonScale = new Vector3()
                    {
                        x = 10,
                        y = 10,
                        z = 10,
                    },
                    buttonColor = new Color()
                    {
                        r = 1,
                        g = 1,
                        b = 1,
                        a = 1,
                    },
                    enableHeat = true,
                    HeatLevel = 1,
                    statusPos = new Vector3
                    {
                        x = -156.378f,
                        y = -67.81f,
                        z = -1.36f,
                    },
                    forceEnableDecryptText = false,
                    decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
                },
            }
        };
    }

    public class IndividualRundownLayout
    {
        public int RundownDatablockID { get; set; } = 32;

        public ExpeditionButton[] Tier1 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton()
            {
                label = "R1A1",
                buttonPos = new Vector3()
                {
                    x = -75,
                    y = 0,
                    z = 0,
                },
                buttonScale = new Vector3()
                {
                    x = 10,
                    y = 10,
                    z = 10,
                },
                buttonColor = new Color()
                {
                    r = 1,
                    g = 1,
                    b = 1,
                    a = 1,
                },
                enableHeat = true,
                HeatLevel = 1,
                statusPos = new Vector3
                {
                    x = -156.378f,
                    y = -67.81f,
                    z = -1.36f,
                },
                forceEnableDecryptText = false,
                decryptText = "://err: UNABLE TO DECRYPT; QP_%: 66,1‬"
            },
        };
    }

    public class ExpeditionButton
    {
        public string label { get; set; }

        public Vector3 buttonPos { get; set; } = new();

        public Vector3 buttonScale { get; set; } = new Vector3()
        {
            x = 10,
            y = 10,
            z = 10,
        };

        public Color buttonColor { get; set; } = new Color()
        {
            r = 1,
            g = 1,
            b = 1,
            a = 1,
        };

        public bool enableHeat { get; set; } = true;

        public float HeatLevel { get; set; } = 1;

        public Vector3 statusPos { get; set; } = new Vector3
        {
            x = -156.378f,
            y = -67.81f,
            z = -1.36f,
        };

        public bool forceEnableDecryptText { get; set; } = false;

        public string decryptText { get; set; }
    }
}
