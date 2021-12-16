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
        public static KeyboardState Keyboard { get; private set; }
        
        private Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
            : base(gameWindowSettings, nativeWindowSettings) {
            switch (EngineSettings.Mode) {
                case WindowMode.Fixed:
                    WindowBorder = WindowBorder.Fixed;
                    break;
                
                case WindowMode.Resizable:
                    WindowBorder = WindowBorder.Resizable;
                    break;
            }

            Keyboard = KeyboardState;
        }
        
        public static Window Create() {
            var gameSettings = new GameWindowSettings();
            var nativeSettings = new NativeWindowSettings {
                Size = new Vector2i(EngineSettings.Width, EngineSettings.Height),
                Title = EngineSettings.Name,
            };
            return new Window(gameSettings, nativeSettings);
        }

        protected override void OnLoad() {
            var color = EngineSettings.BackgroundColor;
            GL.ClearColor(color.r, color.g, color.b, color.a);
            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args) {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            SceneManager.Render();
            Context.SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e) {
            GL.Viewport(0, 0, EngineSettings.Width, EngineSettings.Height);
            base.OnResize(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs args) {
            base.OnUpdateFrame(args);
            SceneManager.Update();

            if (KeyboardState.IsKeyDown(Keys.K)) {
                Console.WriteLine("kkk");
            }
        }
    }
}