namespace USharpEngine {
    public abstract class Component {
        public GameObject owner { get; internal set; } = null;
        public bool Enable { get; set; } = true;
        public abstract void Update();
    }
}