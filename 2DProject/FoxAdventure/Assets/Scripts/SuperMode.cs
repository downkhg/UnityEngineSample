using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMode : MonoBehaviour
{
    public bool bActive = false;
    public float fTime = 1;

    public void Active()
    {
        StartCoroutine(ProcessTimmer(fTime));
    }

    IEnumerator ProcessTimmer(float time)
    {
        bActive = true;
        yield return new WaitForSeconds(time);
        bActive = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white; //원래색상으로 돌린다.
    }


    // Start is called before the first frame update
    void Start()
    {
        Active();
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bActive)//무적이됬을때 효과를 준다.
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            if (color.a == 1) color.a = 0;
            else color.a = 1;
            spriteRenderer.color = color;
        }
    }
}
