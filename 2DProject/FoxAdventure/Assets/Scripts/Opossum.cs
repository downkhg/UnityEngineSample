using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Vector3 vPos = transform.position;
        Vector3 vBoxOffset = new Vector3(boxCollider.offset.x, boxCollider.offset.y);
        Vector3 vBoxSize = new Vector3(boxCollider.size.x, boxCollider.size.y);
        Gizmos.DrawCube(vPos/* + vBoxOffset*/, vBoxSize);
    }

    void Attack()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Vector3 vPos = transform.position;
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider = Physics2D.OverlapBox(vPos, boxCollider.size, 0, nLayer);
        //플레이어 공격
        if (collider)
        {
            Debug.Log(this.gameObject.name + " Attack:" + collider.gameObject.name);
            if (collider.gameObject.tag == "Player")
            {
                SuperMode superMode = collider.gameObject.GetComponent<SuperMode>();

                if (superMode != null && superMode.bActive == false)
                {
                    Player me = GetComponent<Player>();
                    Player target = collider.gameObject.GetComponent<Player>();

                    if(me && target)
                    {
                        me.Attack(target);
                        superMode.Active();
                        if(target.Dead())
                            me.StillExp(target);
                    }
                }
                //폐기된 오브젝트를 복제하면 문제가 발생한다.
                //Instantiate(collision.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        Attack();
        ////부딧힌대상의 모두 가져옴.
        //Collider2D[] colliders = Physics2D.OverlapBoxAll(vPos, boxCollider.size, 0);

        //for(int i = 0; i < colliders.Length; i++)
        //{
        //    Collider2D collider = colliders[i];
        //    if (collider)
        //    {
        //        Debug.Log(this.gameObject.name + "["+i+"] Attack:" + collider.gameObject.name);
        //        if (collider.gameObject.tag == "Player")
        //        {
        //            SuperMode superMode = collider.gameObject.GetComponent<SuperMode>();

        //            if (superMode != null && superMode.bActive == false)
        //                Destroy(collider.gameObject);
        //            //폐기된 오브젝트를 복제하면 문제가 발생한다.
        //            //Instantiate(collision.gameObject);
        //        }
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SuperMode superMode = collision.gameObject.GetComponent<SuperMode>();

            if(superMode != null && superMode.bActive == false)
                Destroy(collision.gameObject);
            //폐기된 오브젝트를 복제하면 문제가 발생한다.
            //Instantiate(collision.gameObject);
        }
    }
    ////트리거: 물리충돌은 되지않지만 충돌체크는 가능한 대상
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        //연관성있는 처리는 한쪽에서 모두 마치는것이 좋다.
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}
