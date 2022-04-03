using Core;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    [Header("The Current Version")]
    private string Version;
    private TextMeshProUGUI VersionText;

    private GameObject UIPanels;
    [SerializeField]
    private List<GameObject> Panels = new List<GameObject>();
    private GameObject PausePanel;
    [SerializeField]
    private List<GameObject> PauseUI = new List<GameObject>();

    private GameInfo Info;

    private void Awake()
    {
        VersionText = GameObject.Find("Version").GetComponent<TextMeshProUGUI>();
        Info = gameObject.GetComponent<GameInfo>();

        UIPanels = GameObject.Find("Panels");
        for (int i = 0; UIPanels.transform.childCount > i; i++)
        {
            Panels.Add(UIPanels.transform.GetChild(i).gameObject);
        }

        PausePanel = GameObject.Find("PausePanel");
        for (int i = 0; i < PausePanel.transform.childCount; i++)
        {
            PauseUI.Add(PausePanel.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        Info.Version = Version;
        VersionText.text = Version;

        Panels[1].SetActive(false);
    }

    private void Update()
    {
        UIReset();
        GetInput();
    }

    public void GetInput()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Info.isPaused)
            {
                Info.isReseted = true;
                Info.isPaused = false;
                Panels[1].SetActive(false);
                PlayerUI.SetCrosshair(true);
            }
            else
            {
                Info.isPaused = true;
                Panels[1].SetActive(true);
                PlayerUI.SetCrosshair(false);

            }
        }
    }

    private void UIReset()
    {
        if (Info.isReseted)
        {
            foreach (GameObject obj in PauseUI)
            {
                obj.SetActive(false);
            }
            PauseUI[0].SetActive(true);
            Info.isReseted = false;
        }
    }

    #region Main Buttons
    public void Settings()
    {
        PauseUI[0].SetActive(false);
        PauseUI[1].SetActive(true);
    }

    public void Resume()
    {
        Info.isPaused = false;
        PausePanel.SetActive(false);
        PlayerUI.SetCrosshair(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}