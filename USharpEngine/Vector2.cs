using System;

namespace USharpEngine {
    public class Vector2 {
        public float x, y;
        
        public Vector2() {
            x = 0f;
            y = 0f;
        }

        public Vector2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector3 vec) {
            x = vec.x;
            y = vec.y;
        }
        
        public float Magnitude() {
            return MathF.Sqrt(x * x + y * y);
        }

        public void Normalize() {
            var mag = Magnitude();
            x /= mag;
            y /= mag;
        }

        public Vector2 Normalized() {
            var vec = new Vector2();
            var mag = Magnitude();
            vec.x = x / mag;
            vec.y = x / mag;
            return vec;
        }

        public Vector2 Scale(Vector2 vec) {
            var result = new Vector2 {
                x = x * vec.x,
                y = y * vec.y,
            };
            return result;
        }

        public static Vector2 operator+ (Vector2 left, Vector2 right) {
            var result = new Vector2 {
                x = left.x + right.x,
                y = left.y + right.y,
            };
            return result;
        }
        
        public static Vector2 operator- (Vector2 left, Vector2 right) {
            var result = new Vector2 {
                x = left.x - right.x,
                y = left.y - right.y,
            };
            return result;
        }
        
        public static Vector2 operator* (Vector2 left, float right) {
            var result = new Vector2 {
                x = left.x * right,
                y = left.y * right,
            };
            return result;
        }
        
        public static Vector2 operator/ (Vector2 left, float right) {
            var result = new Vector2 {
                x = left.x / right,
                y = left.y / right,
            };
            return result;
        }

        public static implicit operator Vector3(Vector2 vec) {
            return new Vector3(vec.x, vec.y, 0f);
        }

        public static Vector2 zero => new Vector2();
    }
}