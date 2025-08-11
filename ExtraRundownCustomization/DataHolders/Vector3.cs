namespace ExtraRundownCustomization.DataHolders
{
    [System.Serializable]
    public class Vector3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public static implicit operator UnityEngine.Vector3(Vector3 v) => new UnityEngine.Vector3(v.x, v.y, v.z);
    }
}
