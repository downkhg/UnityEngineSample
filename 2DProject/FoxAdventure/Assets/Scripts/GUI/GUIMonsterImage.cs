using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GUIMonsterImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image imageMonster;

    public void SetImage(string name)
    {
        imageMonster = GetComponent<Image>();
        Sprite spriteMonster = Resources.Load<Sprite>("Image/"+name);
        imageMonster.sprite = spriteMonster;
        gameObject.name = name;
        //imageMonster.overrideSprite
    }

    // Start is called before the first frame update

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log(gameObject.name+" Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log(gameObject.name + " Mouse is no longer on GameObject.");
    }
    void Start()
    {
        //SetImage("frog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        GUIContentInfo guiContentInfo = GameManager.GetInstance().guiContentInfo;
        guiContentInfo.SetText(gameObject.name);
        guiContentInfo.gameObject.SetActive(true);
        
        Debug.Log(gameObject.name + " OnPointerDown.");

        //throw new System.NotImplementedException();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        GUIContentInfo guiContentInfo = GameManager.GetInstance().guiContentInfo;
        guiContentInfo.gameObject.SetActive(false);
        Debug.Log(gameObject.name + " OnPointerUp.");
        //throw new System.NotImplementedException();
    }
}
