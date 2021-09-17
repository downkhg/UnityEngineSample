using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject objBullet;
    public Player cMaster;

    public void Shot(Vector3 vDir)
    {
        //총알을 발사
        GameObject objNewBullet = Instantiate(objBullet,transform.position,Quaternion.identity);
        Rigidbody2D rigidbody = objNewBullet.GetComponent<Rigidbody2D>();
        Bullet bullet = objNewBullet.GetComponent<Bullet>();
        bullet.cMaster = cMaster;
        rigidbody.AddForce(vDir * 100);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
