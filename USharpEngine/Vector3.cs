using System;

namespace USharpEngine {
    public class Vector3 {
        public float x, y, z;

        public Vector3() {
            x = 0f;
            y = 0f;
            z = 0f;
        }

        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector2 vec) {
            x = vec.x;
            y = vec.y;
            z = 0f;
        }

        public float Magnitude() {
            return MathF.Sqrt(x * x + y * y + z * z);
        }

        public void Normalize() {
            var mag = Magnitude();
            x /= mag;
            y /= mag;
            z /= mag;
        }

        public Vector3 Normalized() {
            var vec = new Vector3();
            var mag = Magnitude();
            vec.x = x / mag;
            vec.y = x / mag;
            vec.z = z / mag;
            return vec;
        }

        public Vector3 Scale(Vector3 vec) {
            var result = new Vector3 {
                x = x * vec.x,
                y = y * vec.y,
                z = z * vec.z
            };
            return result;
        }

        public static Vector3 operator+ (Vector3 left, Vector3 right) {
            var result = new Vector3 {
                x = left.x + right.x,
                y = left.y + right.y,
                z = left.z + right.z
            };
            return result;
        }
        
        public static Vector3 operator- (Vector3 left, Vector3 right) {
            var result = new Vector3 {
                x = left.x - right.x,
                y = left.y - right.y,
                z = left.z - right.z
            };
            return result;
        }
        
        public static Vector3 operator* (Vector3 left, float right) {
            var result = new Vector3 {
                x = left.x * right,
                y = left.y * right,
                z = left.z * right
            };
            return result;
        }
        
        public static Vector3 operator/ (Vector3 left, float right) {
            var result = new Vector3 {
                x = left.x / right,
                y = left.y / right,
                z = left.z / right
            };
            return result;
        }

        public static implicit operator Vector2(Vector3 vec) {
            return new Vector2(vec.x, vec.y);
        }

        public static Vector3 zero => new Vector3();
    }
}