namespace USharpEngine.ECS {
    public abstract class SystemBase {
        public void Update() {
            OnUpdate();
        }

        protected abstract void OnUpdate();
    }
}