using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomReflectBall : MonoBehaviour
{
    public Transform trTarget;
    public CustomMath.Vector3  vTargetDir;
    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        CustomMath.Vector3 vDist = new CustomMath.Vector3(trTarget.position - transform.position);
        vTargetDir = vDist.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vTargetDir.UnityVector() * Speed * Time.deltaTime;
    }

    Vector3 Reflect(Vector3 vIn, Vector3 vNor)
    {
        Vector3 vReflect = new Vector3();
        return vReflect;
    }

    private void OnTriggerEnter(Collider other)
    {
        CustomRelfectPlane relfectPlane = other.gameObject.GetComponent<CustomRelfectPlane>();

        if (relfectPlane != null)
        {
            vTargetDir = CustomMath.Vector3.Reflect(vTargetDir, relfectPlane.m_vPlaneNormal);
        }
    }
}
