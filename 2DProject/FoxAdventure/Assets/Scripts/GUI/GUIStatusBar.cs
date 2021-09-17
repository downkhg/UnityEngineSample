using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIStatusBar : MonoBehaviour
{
    public Text textLabel;
    public RectTransform rectBar;
    public Vector2 vMaxSize;

    public void Init()
    {
        vMaxSize = rectBar.sizeDelta;
    }

    public void SetStatus(float status, float maxstatus)
    {
        float rat = status / maxstatus;
        Vector2 vSize = rectBar.sizeDelta;
        vSize.x = vMaxSize.x * rat;
        rectBar.sizeDelta = vSize;
    }

    private void Awake()
    {
        Init();
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
