using OpenTK.Windowing.GraphicsLibraryFramework;
using Window = USharpEngine.Core.Window;

namespace USharpEngine {
    public static class Input {
        public static bool GetKey(KeyCode keyCode) {
            var key = ConvertKeyFromOpenTK(keyCode);
            return Window.Keyboard.IsKeyDown(key);
        }

        public static bool GetKeyDown(KeyCode keyCode) {
            var key = ConvertKeyFromOpenTK(keyCode);
            return Window.Keyboard.IsKeyPressed(key);
        }

        public static bool GetKeyUp(KeyCode keyCode) {
            var key = ConvertKeyFromOpenTK(keyCode);
            return Window.Keyboard.IsKeyReleased(key);
        }

        private static Keys ConvertKeyFromOpenTK(KeyCode key) {
            var keyCode = Keys.Unknown;
            switch (key) {
                case KeyCode.A:
                    keyCode = Keys.A;
                    break;
                case KeyCode.B:
                    keyCode = Keys.B;
                    break;
                case KeyCode.C:
                    keyCode = Keys.C;
                    break;
                case KeyCode.D:
                    keyCode = Keys.D;
                    break;
                case KeyCode.E:
                    keyCode = Keys.E;
                    break;
                case KeyCode.F:
                    keyCode = Keys.F;
                    break;
                case KeyCode.G:
                    keyCode = Keys.G;
                    break;
                case KeyCode.H:
                    keyCode = Keys.H;
                    break;
                case KeyCode.I:
                    keyCode = Keys.I;
                    break;
                case KeyCode.J:
                    keyCode = Keys.J;
                    break;
                case KeyCode.K:
                    keyCode = Keys.K;
                    break;
                case KeyCode.L:
                    keyCode = Keys.L;
                    break;
                case KeyCode.M:
                    keyCode = Keys.M;
                    break;
                case KeyCode.N:
                    keyCode = Keys.N;
                    break;
                case KeyCode.O:
                    keyCode = Keys.O;
                    break;
                case KeyCode.P:
                    keyCode = Keys.P;
                    break;
                case KeyCode.Q:
                    keyCode = Keys.Q;
                    break;
                case KeyCode.R:
                    keyCode = Keys.R;
                    break;
                case KeyCode.S:
                    keyCode = Keys.S;
                    break;
                case KeyCode.T:
                    keyCode = Keys.T;
                    break;
                case KeyCode.U:
                    keyCode = Keys.U;
                    break;
                case KeyCode.V:
                    keyCode = Keys.V;
                    break;
                case KeyCode.W:
                    keyCode = Keys.W;
                    break;
                case KeyCode.X:
                    keyCode = Keys.X;
                    break;
                case KeyCode.Y:
                    keyCode = Keys.Y;
                    break;
                case KeyCode.Z:
                    keyCode = Keys.Z;
                    break;
                case KeyCode.Esc:
                    keyCode = Keys.Escape;
                    break;
                case KeyCode.Space:
                    keyCode = Keys.Space;
                    break;
                case KeyCode.LeftCtrl:
                    keyCode = Keys.LeftControl;
                    break;
                case KeyCode.RightCtrl:
                    keyCode = Keys.RightControl;
                    break;
                case KeyCode.LeftShift:
                    keyCode = Keys.LeftShift;
                    break;
                case KeyCode.RightShift:
                    keyCode = Keys.RightShift;
                    break;
            }
            return keyCode;
        }
    }
}