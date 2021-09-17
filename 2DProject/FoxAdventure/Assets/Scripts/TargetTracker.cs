using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    public GameObject objTarget;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objTarget = GameObject.FindGameObjectWithTag("Player");

        if (objTarget)//추적대상이 있을때
        {
            //이동 //(대상의 방향)으로 이동한다.
            Vector3 vPos = this.transform.position;
            Vector3 vTargetPos = objTarget.transform.position;
            vTargetPos.z = vPos.z;
            Vector3 vDist = vTargetPos - vPos; //방향+거리
            Vector3 vDir = vDist.normalized; //방향만구함.
            float fDist = vDist.magnitude; //거리만 구함.
            float fMove = Speed * Time.deltaTime;
            if (fDist > fMove)//이동거리만큼 덜가더라도 이동을 종료시킨다.
            {
                Debug.DrawLine(vPos, vTargetPos, Color.red);
                transform.position += vDir * fMove;
            }
            else
            {
                Debug.Log("Target Trackin End:" + objTarget.name);
            }
        }
    }
}
