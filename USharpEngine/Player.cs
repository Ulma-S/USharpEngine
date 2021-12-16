using System;

namespace USharpEngine {
    public class Player : GameObject {
        public Player() {
            var sprite = new Sprite();
            AddRenderer(sprite);
        }

        protected override void OnLoad() {
        }

        protected override void OnUpdate() {
            if(Input.GetKeyDown(KeyCode.A)) {
                Console.WriteLine("A is pressed.");
            }
        }

        protected override void OnUnload() {
        }
    }
}