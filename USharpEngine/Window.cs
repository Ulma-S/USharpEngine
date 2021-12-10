using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace USharpEngine {
    public enum WindowMode {
        Fixed,
        Resizable,
    }
    
    public class Window : GameWindow {
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
        
        protected override void OnUpdateFrame(FrameEventArgs args) {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyPressed(Keys.Escape)) {
                Console.WriteLine("escape");
                Close();
            }
        }
    }
}