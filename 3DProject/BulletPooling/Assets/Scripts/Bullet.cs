using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_fSpeed = 1;
    bool m_isMove;
    public float m_fDist = 1;
    float m_fCurDist = 0;

    public void Move()
    {
        m_isMove = true;
        m_fCurDist = 0;
        gameObject.SetActive(true);
    }
    public void Stop()
    {
        m_isMove = false;
        m_fCurDist = 0;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isMove)
        {
            float fMove = m_fSpeed * Time.deltaTime;
            transform.position += transform.forward * fMove;

            m_fCurDist += fMove;
        }

        if(m_fCurDist >= m_fDist)
        {
            Stop();
            if(Player.queUsePool.Count > 0)
            {
                Bullet bullet =  Player.queUsePool.Dequeue();
                Player.queDisablePool.Enqueue(bullet);
            }
        }
    }
}
