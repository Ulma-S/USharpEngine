using System.Collections.Generic;

namespace USharpEngine {
    public abstract class GameObject {
        private readonly List<Component> m_components = new List<Component>();

        protected GameObject() { 
            AddComponent<Transform>();
        }

        public void Update() {
            foreach (var component in m_components) {
                component.Update();
            }
            UpdateGameObject();
        }

        protected abstract void UpdateGameObject();

        public void AddComponent<T>() where T : Component, new() {
            var comp = new T {
                owner = this,
            };
            m_components.Add(comp);
        }

        public T GetComponent<T>() where T : Component {
            foreach (var component in m_components) {
                var cast = component as T;
                if (cast != null) {
                    return cast;
                }
            }
            return null;
        }
    }
}