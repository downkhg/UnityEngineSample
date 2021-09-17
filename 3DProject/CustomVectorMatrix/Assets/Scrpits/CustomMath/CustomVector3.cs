using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMath
{
    [Serializable]
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x= 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(UnityEngine.Vector3 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }
        public UnityEngine.Vector3 UnityVector()
        {
            return new UnityEngine.Vector3(x, y, z);
        }
        //더하기/빼기/곱하기
        public static Vector3 operator+(Vector3 vA, Vector3 vB)
        {
            Vector3 vTemp = new Vector3();
            return vTemp;
        }
        public static Vector3 operator -(Vector3 vA, Vector3 vB)
        {
            Vector3 vTemp = new Vector3();
            return vTemp;
        }
        public static Vector3 operator*(Vector3 vec, float scala)
        {
            Vector3 vTemp = new Vector3();
            return vTemp;
        }
        //평준화/스칼라
        public float Magnitude()
        {
            return 0.0f;
        }
        public Vector3 Normalize()
        {
            Vector3 vNor = new Vector3();
            return vNor;
        }
        //내적/외적
        static public Vector3 Cross(Vector3 vA, Vector3 vB)
        {
            Vector3 vCross = new Vector3();
            return vCross;
        }
        //반사
        static public Vector3 Reflect(Vector3 vDir, Vector3 vNor)
        {
            Vector3 vReflect = new Vector3();
            return vReflect;
        }
    }
}
