using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int m_nBulletCount = 10;
    public List<Bullet> listBullet;
    public static Queue<Bullet> queUsePool = new Queue<Bullet>();
    public static Queue<Bullet> queDisablePool = new Queue<Bullet>();
    

    // Start is called before the first frame update
    void Start()
    {
        listBullet = new List<Bullet>(m_nBulletCount);
        GameObject prefab = Resources.Load("Prefabs/Bullet") as GameObject;
        for(int i =0;  i< m_nBulletCount; i++)
        {
            GameObject objBullet = Instantiate(prefab);
            objBullet.transform.position = this.transform.position;
            Bullet cBullet = objBullet.GetComponent<Bullet>();
            listBullet.Add(cBullet);
            queDisablePool.Enqueue(cBullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    public void Shot()
    {
        if (queDisablePool.Count > 0)
        {
            Bullet cBullet = queDisablePool.Dequeue();
            queUsePool.Enqueue(cBullet);
            cBullet.transform.position = this.transform.position;
            cBullet.Move();
        }
    }
}
