using System;
using static USharpEngine.EngineSettings;

namespace USharpEngine {
    class EntryPoint {
        static void Main() {
            Engine.OnInitSettingsHandler += () => {
                Width = 640;
                Height = 480;
                Name = "SampleGame";
                BackgroundColor = Color.Black;
            };

            Engine.OnInitGameHandler += () => {
                var shader = new Shader("shader.vert", "shader.frag");
                
                var scene = new Scene("test");
                SceneManager.RegisterScene(scene);

                var player = new Player();
                player.renderer.shader = shader;
                
                scene.AddGameObject(player);
                
                SceneManager.ChangeScene("test");
            };

            Engine.OnExitHandler += () => {
                Console.WriteLine("exit.");
            };

            Engine.Run();
        }
    }
}
