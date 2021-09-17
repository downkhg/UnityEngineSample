using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public GameObject objTarget;
    public float Speed;
    public float Site = 0.5f;

    public GameObject objRespon;
    public bool isTracking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetTracking();
    }

    private void FixedUpdate()
    {
        Detect();
        Attack();
    }

    void Attack()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider = null;
        Vector3 vPos = this.transform.position;

        if (circleCollider)//공격처리
        {
            collider = Physics2D.OverlapCircle(vPos, circleCollider.radius, nLayer);

            if (collider)
            {
                SuperMode superMode = collider.gameObject.GetComponent<SuperMode>();

                if (superMode != null && superMode.bActive == false)
                    Destroy(collider.gameObject);
            }
        }
    }

    void Detect()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider = null;
        Vector3 vPos = this.transform.position;

        //시야처리
        collider = Physics2D.OverlapCircle(vPos, Site, nLayer);
        if (collider)
        {
            objTarget = collider.gameObject;
        }
        //else
        //    objTarget = objRespon;
    }

    private void OnDrawGizmos() //시야범위 그리기
    {
        
        Gizmos.DrawWireSphere(this.transform.position, Site);
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(this.transform.position, Time.deltaTime);
        Gizmos.color = Color.green;
        if (objTarget != null) 
        Gizmos.DrawSphere(objTarget.transform.position, Time.deltaTime);
        Gizmos.color = Color.white;
    }


    public bool TargetTracking()
    {
        if (objTarget)//추적대상이 있을때
        {
            //이동 //(대상의 방향)으로 이동한다.
            Vector3 vPos = this.transform.position;
            Vector3 vTargetPos = objTarget.transform.position;
            Vector3 vDist = vTargetPos - vPos; //방향+거리
            Vector3 vDir = vDist.normalized; //방향만구함.
            float fDist = vDist.magnitude; //거리만 구함.
            float fMove = Speed * Time.deltaTime;
            if (fDist > fMove)//이동거리만큼 덜가더라도 이동을 종료시킨다.
            {
                Debug.DrawLine(vPos, vTargetPos, Color.red);
                transform.position += vDir * fMove;
                isTracking = true;
                return true;
            }
            else
            {
                Debug.Log("Target Trackin End:"+objTarget.name);
                isTracking = false;
                return false;
            }
        }
        return false;
    }
}
