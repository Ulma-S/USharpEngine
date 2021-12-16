using System;
using USharpEngine.Core;

namespace USharpEngine {
    public class Engine {
        private static Window window;
        public static event Action OnInitSettingsHandler;
        public static event Action OnInitGameHandler;
        public static event Action OnExitHandler;

        private static void Init() {
            OnInitSettingsHandler?.Invoke();
            window = Window.Create();
            OnInitGameHandler?.Invoke();
        }
        
        public static void Run() {
            Init();
            window.Run();
            Exit();
        }

        private static void Exit() { 
            OnExitHandler?.Invoke();
        }
    }
}