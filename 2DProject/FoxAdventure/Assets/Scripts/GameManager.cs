using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterInfo
{
    public string name;
    public string coment;
    public string image;

    public MonsterInfo(string name, string coment, string image)
    {
        this.name = name;
        this.coment = coment;
        this.image = image;
    }
}

public class GameManager : MonoBehaviour
{
    //
    public Responner[] responnerEagle;
    public Responner responnerPlayer;
    public Responner responnerOpossum;

    public GameObject[] objPatrolPoint;
    public TargetTracker targetTrackerCamera;

    public Dictionary<string, MonsterInfo> monsterInfos = new Dictionary<string, MonsterInfo>();
    //public List<MonsterInfo> monsterInfos;

    public List<string> Inventory;

    public GUIInventory guiInventory;
    public GUIContentInfo guiContentInfo;
    public GameObject popupLayer;

    public void SetInventory(string name)
    {
        Inventory.Add(name);
    }

    public string GetInventory(int idx)
    {
        return Inventory[idx];
    }

    public string GetInventory(string name)
    {
        return Inventory.Find(item => item.Equals(name));
    }

    public void OnGUI()
    {
        for(int i = 0; i< Inventory.Count; i++)
            GUI.Box(new Rect(0, 0 + (20 * i), 100, 20), Inventory[i]);
    }

    public enum E_GUI_STATUS { TITILE, GAMEOVER, THEEND, PLAY }
    //UI의 패널들을 관리하는 리스트
    public List<RectTransform> listGUI;
    public E_GUI_STATUS eGuiStatus;
    public void ShowGUI(E_GUI_STATUS status)
    {
        for (int i = 0; i < listGUI.Count; i++)
        {
            if(i == (int)status)
                listGUI[i].gameObject.SetActive(true);
            else
                listGUI[i].gameObject.SetActive(false);
        }
    }
    public void SetGUIStatus(E_GUI_STATUS status)
    {
        switch(status)
        {
            case E_GUI_STATUS.TITILE:
                Time.timeScale = 0;
                break;
            case E_GUI_STATUS.GAMEOVER:
                Time.timeScale = 0;
                break;
            case E_GUI_STATUS.THEEND:
                Time.timeScale = 0;
                break;
            case E_GUI_STATUS.PLAY:
                statusBarHP.Init();
                Time.timeScale = 1;
                break;
        }
        ShowGUI(status);
        eGuiStatus = status;
    }

    public void UpdataStatus()
    {
        switch(eGuiStatus)
        {
            case E_GUI_STATUS.TITILE:
                break;
            case E_GUI_STATUS.GAMEOVER:
                break;
            case E_GUI_STATUS.THEEND:
                break;
            case E_GUI_STATUS.PLAY:
                if (Input.GetKeyDown(KeyCode.I))
                {
                    if (popupLayer.activeSelf == false)
                    {
                        guiInventory.InitInventory();
                        popupLayer.SetActive(true);
                    }
                    else
                    {
                        popupLayer.SetActive(false);
                        guiInventory.ClearInventory();
                    }
                }

                SetStatusBar(statusBarHP, responnerPlayer.objObject);
                break;
        }
    }

    public GUIStatusBar statusBarHP;

    public void SetStatusBar(GUIStatusBar statusBar, GameObject obj)
    {
        if (obj)
        {
            Player player = obj.GetComponent<Player>();
            if (player)
                statusBar.SetStatus(player.Hp, player.MaxHp);
        }
    }

    public void EventStart()
    {
        SetGUIStatus(E_GUI_STATUS.PLAY);
    }

    static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        monsterInfos.Add("eagle", new MonsterInfo("독수리", "날아다닌다", "eagle"));
        monsterInfos.Add("opossum", new MonsterInfo("주머니쥐", "기어다닌다", "opossum"));

        instance = this;
        SetGUIStatus(eGuiStatus);
    }

    // Update is called once per frame
    void Update()
    {
        UpdataStatus();

        if (targetTrackerCamera.objTarget == null)
            targetTrackerCamera.objTarget = responnerPlayer.objObject;

        int idxPoint = 0;

        for (int i = 0; i < responnerEagle.Length; i++)
        {
            EagleRetrunTargetSetting(responnerEagle[i].objObject, objPatrolPoint[idxPoint]);
  
            EanglePatrolTarget(responnerEagle[i].objObject, objPatrolPoint[idxPoint], objPatrolPoint[idxPoint+1]);
            idxPoint += 2;
        }
    }

    void EagleRetrunTargetSetting(GameObject objEagle, GameObject objPoint)
    {
        if (objEagle == null) return;

        Eagle eagle = objEagle.GetComponent<Eagle>();

        if (eagle)
        {
            if (eagle.objTarget == null)
                eagle.objTarget = objPoint;
        }
    }

    //시작위치에서 끝위치로 이동이 끝나면, 시작위치와 끝위치를 변경한다.
    void EanglePatrolTarget(GameObject ogjEagle, GameObject objStart,  GameObject objEnd)
    {
        if (ogjEagle == null) return;

        Eagle cEagle = ogjEagle.GetComponent<Eagle>();

        if(cEagle)
        {
            //독수리의 추적이 끝나면
            if (cEagle.isTracking == false)
            {
                //지정된 대상에 따라 변경될 위치를 바꾼다.
                if (cEagle.objTarget.name == objEnd.name)
                {
                    Debug.Log(cEagle.objTarget.name + " to " + objStart.name);
                    cEagle.objTarget = objStart;
                    
                }
                else
                {
                    Debug.Log(cEagle.objTarget.name + " to " + objEnd.name);
                    cEagle.objTarget = objEnd;
                   
                }
                
            }
        }
    }
}
