using System;

namespace USharpEngine {
    class EntryPoint {
        static void Main() {
            Application.OnInitHandler += () => {
                WindowSettings.Width = 1280;
                WindowSettings.Height = 720;
                WindowSettings.Name = "SampleGame";
            };

            Application.OnExitHandler += () => {
                Console.WriteLine("exit.");
            };
            
            Application.Run();
        }
    }
}
