using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player cMaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Debug.Log(this.gameObject +" OnTriggerEnter2D:" + collision.gameObject.name);
        if (collision.gameObject.tag == "Monster")
        {
            if (cMaster)
            {
                Player target = collision.gameObject.GetComponent<Player>();
                //cMaster.Attack(target);
                //싱글톤을 이용하면 직접객체에 접근할수있다. 다만 이경우는 좋은 방법은 아니다.
                Player master = GameManager.GetInstance().responnerPlayer.objObject.GetComponent<Player>();
                 master.Attack(target);
                if (target.Dead())
                {
                    master.StillExp(target);
                    GameManager.GetInstance().SetInventory(target.gameObject.name);
                    Destroy(target.gameObject);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
