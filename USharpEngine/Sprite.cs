using OpenTK.Graphics.OpenGL4;
using USharpEngine.Core;

namespace USharpEngine {
    public enum SpriteType {
        Triangle,
        Square,
        Circle,
    }
    
    public class Sprite : IDrawable {
        private string m_fileName;
        public int drawOrder { get; set; } = 100;
        private readonly SpriteType m_type;
        private int m_vertexBufferObject;
        private int m_vertexArrayObject;

        public Shader shader { get; set; }

        private readonly float[] m_triangleVertices = {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f,
        };
        
        public Sprite(string fileName = "triangle", SpriteType type = SpriteType.Triangle, Shader shader = null) {
            m_fileName = fileName;
            m_type = type;
            Load();
        }

        public void Load() {
            switch (m_type) {
                case SpriteType.Triangle:
                    //vbo
                    m_vertexBufferObject = GL.GenBuffer();
                    GL.BindBuffer(BufferTarget.ArrayBuffer, m_vertexBufferObject);
                    GL.BufferData(
                        BufferTarget.ArrayBuffer, 
                        m_triangleVertices.Length * sizeof(float), 
                        m_triangleVertices,
                        BufferUsageHint.StaticDraw);

                    //vao
                    m_vertexArrayObject = GL.GenVertexArray();
                    GL.BindVertexArray(m_vertexArrayObject);
                    GL.VertexAttribPointer(
                        0,
                        3,
                        VertexAttribPointerType.Float, 
                        false,
                        3 * sizeof(float),
                        0);
                    GL.EnableVertexAttribArray(0);
                    break;
                
                case SpriteType.Square:
                    break;
                
                case SpriteType.Circle:
                    break;
            }
            GL.UseProgram(0);
            shader?.Use();
        }

        public void Update() {
            shader?.Use();
            
            GL.BindVertexArray(m_vertexArrayObject);
            switch (m_type) {
                case SpriteType.Triangle:
                    GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                    break;
                
                case SpriteType.Square:
                    break;
                
                case SpriteType.Circle:
                    break;
            }
        }

        public void Unload() {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(m_vertexBufferObject);
            GL.DisableVertexAttribArray(0);
        }
    }
}