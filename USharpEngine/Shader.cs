using System;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace USharpEngine {
    public class Shader : IDisposable { 
        private readonly int m_handle;
        private bool m_disposedValue = false;
        private string m_path = "../../../Shader/";

        public Shader(string vertexPath, string fragmentPath) {
            vertexPath = m_path + vertexPath;
            fragmentPath = m_path + fragmentPath;
            
            int VertexShader;
            int FragmentShader;
            
            string VertexShaderSource;
            using (StreamReader reader = new StreamReader(vertexPath, Encoding.UTF8)) {
                VertexShaderSource = reader.ReadToEnd();
            }
            VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, VertexShaderSource);
            string infoLogVert = GL.GetShaderInfoLog(VertexShader);
            if (infoLogVert != string.Empty) {
                Console.WriteLine(infoLogVert);
            }
            GL.CompileShader(VertexShader);

            string FragmentShaderSource;
            using (StreamReader reader = new StreamReader(fragmentPath, Encoding.UTF8)) {
                FragmentShaderSource = reader.ReadToEnd();
            }
            FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, FragmentShaderSource);
            string infoLogFrag = GL.GetShaderInfoLog(FragmentShader);
            if (infoLogFrag != string.Empty) {
                Console.WriteLine(infoLogFrag);
            }
            GL.CompileShader(FragmentShader);
            
            m_handle = GL.CreateProgram();

            GL.AttachShader(m_handle, VertexShader);
            GL.AttachShader(m_handle, FragmentShader);

            GL.LinkProgram(m_handle);
            
            GL.DetachShader(m_handle, VertexShader);
            GL.DetachShader(m_handle, FragmentShader);
            GL.DeleteShader(FragmentShader);
            GL.DeleteShader(VertexShader);
        }
        
        ~Shader()
        {
            GL.DeleteProgram(m_handle);
        }
        
        public void Use() {
            GL.UseProgram(m_handle);
        }
        
        protected void Dispose(bool disposing) {
            if (!m_disposedValue) {
                GL.DeleteProgram(m_handle);
                m_disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}