namespace USharpEngine {
    public class Triangle : Sprite{
        float[] vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f, //Bottom-right vertex
            0.0f,  0.5f, 0.0f  //Top vertex
        };

        public Triangle(string fileName) : base(fileName, SpriteType.Circle) {
        }
    }
}