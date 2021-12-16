using System.Collections.Generic;
using USharpEngine.Core;

namespace USharpEngine {
    public abstract class GameObject {
        private readonly List<Component> m_components = new List<Component>();
        public IDrawable renderer { get; private set; }
        public readonly Transform transform;

        protected GameObject() { 
            transform = new Transform();
        }

        public void Load() {
            renderer.Load();
            OnLoad();
        }

        protected abstract void OnLoad();

        public void Update() {
            foreach (var component in m_components) {
                component.Update();
            }
            OnUpdate();
        }

        public void Render() {
            renderer.Update();
        }

        protected abstract void OnUpdate();

        public void Unload() {
            OnUnload();
            renderer.Unload();
        }

        protected abstract void OnUnload();
        
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

        protected void AddRenderer(IDrawable drawable) {
            renderer = drawable;
        }
    }
}