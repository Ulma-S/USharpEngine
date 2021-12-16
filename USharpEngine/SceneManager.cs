using System.Collections.Generic;

namespace USharpEngine {
    public class SceneManager {
        private static readonly Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();
        private static Scene currentScene;

        public static void Update() {
            currentScene.OnUpdate();
        }

        public static void Render() {
            currentScene.OnRender();
        }

        public static void ChangeScene(string sceneName) {
            if (!scenes.ContainsKey(sceneName)) {
                return;
            }

            currentScene?.OnExit();
            currentScene = scenes[sceneName];
            currentScene.OnEnter();
        }

        public static void RegisterScene(Scene scene) {
            var sceneName = scene.sceneName;
            if (scenes.ContainsKey(sceneName)) {
                return;
            }
            scenes.Add(sceneName, scene);
        }
    }
}