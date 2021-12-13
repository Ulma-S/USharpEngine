using System;

namespace USharpEngine {
    class EntryPoint {
        static void Main() {
            Engine.OnInitHandler += () => {
                WindowSettings.Width = 640;
                WindowSettings.Height = 360;
                WindowSettings.Name = "SampleGame";
            };

            Engine.OnExitHandler += () => {
                Console.WriteLine("exit.");
            };

            Engine.Run();
        }
    }
}
