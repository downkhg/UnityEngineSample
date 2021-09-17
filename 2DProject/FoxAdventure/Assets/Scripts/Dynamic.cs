using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public float JumpPower;
    public bool Jumping = false;
    public Gun cGun;
    public Vector3 vDir = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        vDir = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        //유니티 키입력 -> 키워드
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //위치 = 위치+(방향*이동량) //게임수학: 벡터
            transform.position += Vector3.right * Time.deltaTime;
            //transform.Rotate(Vector3.up * 0);//이미 회전된 축에서 회전됨.
            transform.localRotation = Quaternion.Euler(Vector3.up * 0);
            vDir = Vector3.right;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime;
            //transform.Rotate(Vector3.up * 180);
            //항상 지정된 각도로 회전함.
            transform.localRotation = Quaternion.Euler(Vector3.up * 180);
            vDir = Vector3.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position += Vector3.down * Time.deltaTime;

        if (Jumping == false)
        { 
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Jump");
                Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
                rigidbody2D.AddForce(Vector3.up * JumpPower);
                Jumping = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            cGun.cMaster = this.GetComponent<Player>();
            cGun.Shot(vDir);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
