using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] List<GameObject> ButtonList = new List<GameObject>();
    [SerializeField] List<GameObject> PanelList = new List<GameObject>();
    
    private GameObject PausePanel;
    private Transform PausePanelTransform;
    private GameObject Canvas;
    private PauseInfo pauseInfo;

    public void Awake()
    {
        pauseInfo = GameObject.Find("GameManager").GetComponent<PauseInfo>();

        //ButtonList
        PausePanel = GameObject.Find("PausePanel");
        PausePanelTransform = PausePanel.transform;
         for (int i = 0; PausePanelTransform.childCount > i; i++)
        {
            ButtonList.Add(PausePanelTransform.GetChild(i).gameObject);
        }

        //PanelList
        Canvas = GameObject.Find("GameCanvas");
        for (int i = 0; Canvas.transform.childCount > i; i++)
        {
            ButtonList.Add(Canvas.transform.GetChild(i).gameObject);
        }
    }

    public void Update()
    {
        inPause();
        UIReset();
    }

    private void inPause()
    {
        if (Game.isPaused())
        {
            PlayerUI.SetCrosshair(true);
            PauseCanvas.SetActive(true);
        }
        else
        {
            PlayerUI.SetCrosshair(false);
            PauseCanvas.SetActive(false);
        }
    }

    public void UIReset()
    {
        if(pauseInfo.isReseted)
        {
            
            foreach (GameObject obj in ButtonList)
            {
                obj.SetActive(true);
            }

            PanelList[2].SetActive(false);

            pauseInfo.isReseted = false;
        }
    }

    public void Settings()
    {
        ButtonList[0].SetActive(false);
        ButtonList[1].SetActive(false);
        PanelList[2].SetActive(true);
    }
}
