namespace ExtraRundownCustomization.DataHolders
{
    [System.Serializable]
    public class Color
    {
        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }
        public float a { get; set; }
        public static implicit operator UnityEngine.Color (Color c) => new UnityEngine.Color() { r = c.r, g = c.g, b = c.b, a = c.a };
    }
}
