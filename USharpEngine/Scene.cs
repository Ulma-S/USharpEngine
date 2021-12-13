using System.Collections.Generic;

namespace USharpEngine {
    public class Scene {
        private readonly List<GameObject> m_gameObjects = new List<GameObject>();
        
        public Scene() {
            
        }

        public void OnEnter() {
            
        }
        
        public void OnUpdate() {
            foreach (var gameObject in m_gameObjects) {
                gameObject.Update();
            }
        }

        public void OnExit() {
            
        }
    }
}