using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp;
    public int MaxHp { get; set; }
    public int Mp;
    public int MaxMp { get; set; }
    public int Str;
    public int Exp;
    public int Lv;

    public GUIStatusBar guiStatusBarHP;

    public void LvUp()
    {
        if(Exp >= 100)
        {
            Hp += 10;
            Mp += 10;
            MaxHp += 10;
            MaxMp += 10;
            Str += 10;
            Lv++;
            Exp -= 100;
        }
    }

    public void StillExp(Player target)
    {
        this.Exp += target.Exp + target.Lv * 100 ;
    }

    public void Attack(Player target)
    {
        target.Hp -= this.Str;
    }

    public bool Dead()
    {
        if (Hp <= 0)
            return true;
        else
            return false;
    }
    public int idx;
    //private void OnGUI()
    //{
    //    int nSizeX = 100;
    //    int nSizeY = 20;
    //    GUI.Box(new Rect(idx*nSizeX, 0, nSizeX, nSizeY), "Name:" + gameObject.name);
    //    GUI.Box(new Rect(idx * nSizeX, 20, nSizeX, nSizeY), "HP:" + Hp + "/" + MaxHp);
    //    GUI.Box(new Rect(idx * nSizeX, 40, nSizeX, nSizeY), "MP:" + Mp + "/" + MaxMp);
    //    GUI.Box(new Rect(idx * nSizeX, 60, nSizeX, nSizeY), "Str:" + Str);
    //    GUI.Box(new Rect(idx * nSizeX, 80, nSizeX, nSizeY), "Exp:" + Exp);
    //    GUI.Box(new Rect(idx * nSizeX, 100, nSizeX, nSizeY), "Lv:" + Lv);
    //}

    private void Start()
    {
        if(guiStatusBarHP) guiStatusBarHP.Init();
        MaxHp = Hp;
        MaxMp = Mp;
    }

    private void Update()
    {
        //if (Dead())  Destroy(this.gameObject);
        LvUp();

        if(guiStatusBarHP)
            guiStatusBarHP.SetStatus(Hp, MaxHp);
    }
}
