using System;
using UnityEngine;

namespace Hexagonal
{
    [System.Serializable]
    public struct Vector3Hex
    {
        public Vector3Hex(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int x;
        public int y;
        public int z;

        public static int Distance(Vector3Hex a, Vector3Hex b) 
            => (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;

        public override bool Equals(object obj)
        {
            return obj is Vector3Hex hex &&
                   x == hex.x &&
                   y == hex.y &&
                   z == hex.z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }

        public static bool operator !=(Vector3Hex lhs, Vector3Hex rhs)
        {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
                return false;
            return true;
        }
        public static bool operator ==(Vector3Hex lhs, Vector3Hex rhs)
        {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
                return true;
            return false;
        }
        public static Vector3Hex operator -(Vector3Hex lhs, Vector3Hex rhs)
        {
            return new Vector3Hex(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static Vector3Hex operator +(Vector3Hex lhs, Vector3Hex rhs)
        {
            return new Vector3Hex(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

    }
}