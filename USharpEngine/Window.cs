using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace USharpEngine.Core {
    public enum WindowMode {
        Fixed,
        Resizable,
    }
    
    public class Window : GameWindow { 
        public event Action OnUpdateHandler;
        private readonly float[] m_vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f, //Bottom-right vertex
            0.0f,  0.5f, 0.0f  //Top vertex
        };

        private int m_vertexBufferObject;
        private int m_vertexArrayObject;

        private Shader m_shader;
        
        private Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
            : base(gameWindowSettings, nativeWindowSettings) {
            switch (WindowSettings.Mode) {
                case WindowMode.Fixed:
                    WindowBorder = WindowBorder.Fixed;
                    break;
                
                case WindowMode.Resizable:
                    WindowBorder = WindowBorder.Resizable;
                    break;
            }
        }
        
        public static Window Create() {
            var gameSettings = new GameWindowSettings();
            var nativeSettings = new NativeWindowSettings {
                Size = new Vector2i(WindowSettings.Width, WindowSettings.Height),
                Title = WindowSettings.Name,
            };
            return new Window(gameSettings, nativeSettings);
        }

        protected override void OnLoad() {
            GL.ClearColor(0.3f, 0.3f, 0.3f, 1.0f);
            
            m_shader = new Shader("shader.vert", "shader.frag");

            GL.UseProgram(0);
            m_shader.Use();
            base.OnLoad();
        }

        protected override void OnUnload() {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(m_vertexBufferObject);
            m_shader.Dispose();
            GL.DisableVertexAttribArray(0);
            base.OnUnload();
        }

        protected override void OnRenderFrame(FrameEventArgs args) {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Context.SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e) {
            GL.Viewport(0, 0, WindowSettings.Width, WindowSettings.Height);
            base.OnResize(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs args) {
            base.OnUpdateFrame(args);

            OnUpdateHandler?.Invoke();
            
            if (KeyboardState.IsKeyPressed(Keys.Escape)) {
                Console.WriteLine("escape");
                Close();
            }
        }
    }
}