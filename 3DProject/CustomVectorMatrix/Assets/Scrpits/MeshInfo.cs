using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshInfo : MonoBehaviour {
    public int idx = 0; //오브젝트의 번호를 넣는다.
    public MeshFilter m_meshFilter;
    public Mesh m_mesh;
    int m_nIndicesNumber = 0;
    public Vector3 m_vPlaneNormal;

    // Use this for initialization
    void Start()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_mesh = m_meshFilter.mesh;
    }
    
    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(150*idx, 0, 150, 120));
        if(GUI.Button(new Rect(0,0,50,20),"-"))
        {
            m_nIndicesNumber -= 3;
        }
        GUI.Box(new Rect(50, 0, 50, 20), ""+ m_nIndicesNumber);
        if (GUI.Button(new Rect(100, 0, 50, 20), "+"))
        {
            m_nIndicesNumber += 3;
        }
        string msg = string.Format("vertex:{0}\n,Indices:{1}\n", m_mesh.vertexCount, m_mesh.subMeshCount) ;
        for(int i = 0; i < m_mesh.subMeshCount; i++)
        {
            msg += string.Format("{0},",m_mesh.GetIndices(i).Length);
        }
        GUI.Box(new Rect(0, 20, 150, 100), msg);
        GUI.EndGroup();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        Quaternion quaternion = transform.localRotation;
        Vector3 scale = transform.localScale;

        for (int i = 0; i < m_mesh.subMeshCount; i++)
        {
            int[] indices = m_mesh.GetIndices(i);

            int a = indices[m_nIndicesNumber + 0];
            int b = indices[m_nIndicesNumber + 1];
            int c = indices[m_nIndicesNumber + 2];

            Vector3 vA = m_mesh.vertices[a];
            Vector3 vB = m_mesh.vertices[b];
            Vector3 vC = m_mesh.vertices[c];
            ////회전적용
            //vA = quaternion * vA;
            //vB = quaternion * vB;
            //vC = quaternion * vC;
            ////위치이동
            //vA += pos;
            //vB += pos;
            //vC += pos;

            Matrix4x4 mat = transform.localToWorldMatrix;

            vA = mat.MultiplyPoint(vA);
            vB = mat.MultiplyPoint(vB);
            vC = mat.MultiplyPoint(vC);

            Debug.DrawLine(vA, vB, Color.red);
            Debug.DrawLine(vA, vC, Color.red);
            Debug.DrawLine(vB, vC, Color.red);

            Vector3 vAtoB = vB - vA;
            Vector3 vBtoC = vC - vB;

            m_vPlaneNormal = Vector3.Cross(vAtoB, vBtoC);

            float fSclae = scale.magnitude;

            //Gizmos.color = Color.green;
            Debug.DrawLine(pos, pos + m_vPlaneNormal * fSclae * 2, Color.red);
        }
    }
}
