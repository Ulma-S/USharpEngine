namespace USharpEngine {
    public class Color {
        public float r, g, b, a;

        public Color() {
            r = 0f;
            g = 0f;
            b = 0f;
            a = 1f;
        }
        
        public Color(float r, float g, float b, float a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public static Color White = new Color(1f, 1f, 1f, 1f);
        public static Color Black = new Color(0f, 0f, 0f, 1f);
    }
}