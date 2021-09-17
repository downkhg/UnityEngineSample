using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject objObject;
    public bool bRespon;
    public string strPrefabName;
    public float fResponTime;

    void ResponObject(string prefabname)
    {
        if (objObject == null)
        {
            GameObject prefab =
                Resources.Load("Prefabs/" + prefabname) as GameObject;
            objObject = Instantiate(prefab,transform.position,Quaternion.identity);
            objObject.name = prefab.name;
            //Eagle eagle = objObject.GetComponent<Eagle>();
            //if(eagle)
            //    eagle.objRespon = this.gameObject;
            //objObject.transform.position = transform.position;
            //objObject.transform.localRotation = Quaternion.identity;
        }
    }

    IEnumerator ResponTimmerProcess(string prefpabname, float time)
    {
        bRespon = true;
        Debug.Log("ResponTimmerProcess start");
        yield return new WaitForSeconds(time);
        ResponObject(prefpabname);
        Debug.Log("ResponTimmerProcess end");
        bRespon = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objObject == null && bRespon == false)
            StartCoroutine(ResponTimmerProcess(strPrefabName, fResponTime));
    }
}
