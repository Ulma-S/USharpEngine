using System.Collections.Generic;

namespace USharpEngine {
    public class Scene {
        private readonly List<GameObject> m_gameObjects = new List<GameObject>();
        public string sceneName { get; }
        
        public Scene(string sceneName) {
            this.sceneName = sceneName;
        }

        public void OnEnter() {
            foreach (var gameObject in m_gameObjects) {
                gameObject.Load();
            }
        }
        
        public void OnUpdate() {
            foreach (var gameObject in m_gameObjects) {
                gameObject.Update();
            }
        }

        public void OnRender() {
            foreach (var gameObject in m_gameObjects) {
                gameObject.Render();
            }
        }

        public void OnExit() {
            foreach (var gameObject in m_gameObjects) {
                gameObject.Unload();
            }
        }

        public void AddGameObject(GameObject gameObject) {
            m_gameObjects.Add(gameObject);
        }
    }
}