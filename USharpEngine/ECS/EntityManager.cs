using System.Collections.Generic;

namespace USharpEngine.ECS {
    public class EntityManager {
        private static readonly List<Entity> m_entityList = new List<Entity>();

        private static int initialLength = 10;
        private static readonly bool[] entities = new bool[initialLength];
        
        private EntityManager() { }

        public static Entity Create() {
            var count = 0;
            while (true) {
                if (m_entityList.Exists(elem => elem.ID == count)) {
                    count++;
                }
                else {
                    break;
                }
            }
            var entity = new Entity(count);
            m_entityList.Add(entity);
            return entity;
        }

        public static void AddComponent<T>(ref Entity enitity) where T : IComponentData {
            
        }
    }
}