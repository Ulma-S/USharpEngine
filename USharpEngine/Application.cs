using System;

namespace USharpEngine {
    public class Application {
        private static Window window;
        public static event Action OnInitHandler;
        public static event Action OnExitHandler;

        private static void Init() {
            OnInitHandler?.Invoke();

            window = Window.Create();
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