namespace USharpEngine.Core {
    public interface IDrawable {
        Shader shader { set; }
        void Load();
        void Update();
        void Unload();
    }
}