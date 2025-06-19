namespace ExtraRundownCustomization.DataHolders
{
    [System.Serializable]
    public class CustomWatermark
    {
        public bool Enabled { get; set; } = false;
        public string Text { get; set; } = "<color=red>MODDED</color> <color=orange>" + MTFO.MTFO.VERSION + "</color>";
    }
}
