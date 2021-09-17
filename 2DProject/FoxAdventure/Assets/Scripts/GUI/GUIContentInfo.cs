using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIContentInfo : MonoBehaviour
{
    public Text textInfo;

    public void SetText(string name)
    {
       
        GameManager gameManager = GameManager.GetInstance();
        MonsterInfo monsterInfo = gameManager.monsterInfos[name];

        string strContent = string.Format("{0}\n{1}\n", name, monsterInfo.coment);
        textInfo.text = strContent;

        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.position = Input.mousePosition;
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
