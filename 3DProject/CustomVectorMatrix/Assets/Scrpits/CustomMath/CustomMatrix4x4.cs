using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMath
{
    [Serializable]
    public struct Matrix4x4
    {
        public float _m00;
        public float _m01;
        public float _m02;
        public float _m03;

        public float _m10;
        public float _m11;
        public float _m12;
        public float _m13;

        public float _m20;
        public float _m21;
        public float _m22;
        public float _m23;

        public float _m30;
        public float _m31;
        public float _m32;
        public float _m33;

        public Matrix4x4(UnityEngine.Matrix4x4 mat)
        {
            _m00 = mat.m00;
            _m01 = mat.m01;
            _m02 = mat.m02;
            _m03 = mat.m03;

            _m10 = mat.m10;
            _m11 = mat.m11;
            _m12 = mat.m12;
            _m13 = mat.m13;

            _m20 = mat.m20;
            _m21 = mat.m21;
            _m22 = mat.m22;
            _m23 = mat.m23;

            _m30 = mat.m30;
            _m31 = mat.m31;
            _m32 = mat.m32;
            _m33 = mat.m33;
        }

        public Vector3 MultiplyPoint(Vector3 vec)
        {
            Vector3 vResult = new Vector3();
            return vResult;
        }
    }
}