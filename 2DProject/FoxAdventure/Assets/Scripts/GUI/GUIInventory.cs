using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> listIventory = new List<GameObject>();
    public RectTransform rectContent;

    public void InitInventory()
    {
        List<string> Inventory = GameManager.GetInstance().Inventory;

        GameObject prefabsImage = Resources.Load("GUI/MonsterImage") as GameObject;

        foreach(string name in Inventory)
        {
            GameObject monsterImage =  Instantiate(prefabsImage, rectContent);
            GUIMonsterImage guiMonsterImage = monsterImage.GetComponent<GUIMonsterImage>();
            guiMonsterImage.SetImage(name);
            listIventory.Add(monsterImage);
        }

        GridLayoutGroup gridLayout = rectContent.GetComponent<GridLayoutGroup>();
        Vector2 vContentSize = rectContent.sizeDelta;
        Vector2 vGridSize = gridLayout.cellSize;
        int nRayoutCount = (int)(rectContent.sizeDelta.x / vGridSize.x);
        int nLine = Inventory.Count / nRayoutCount;
        if (Inventory.Count % nRayoutCount > 0) 
            nLine++;
        vContentSize.y = vGridSize.y * nLine; 
        rectContent.sizeDelta = vContentSize;
    }

    public void ClearInventory()
    {
        for (int i = 0; i < listIventory.Count; i++)
            Destroy(listIventory[i]);
        listIventory.Clear();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
