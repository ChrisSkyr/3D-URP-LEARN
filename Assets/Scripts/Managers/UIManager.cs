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
    [SerializeField]
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

       
        for (int i = 0; i < PausePanel.transform.childCount; i++)
        {
            PauseUI.Add(PausePanel.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        //Sets the Version of the Game
        Info.Version = Version;
        VersionText.text = Version;

        //Resets the UI
        ResetUI();

        Panels[1].SetActive(false);
    }

    private void Update()
    {
        
        Pause();
    }

    public void Pause()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Info.isPaused)
            {
                Info.isPaused = false;
                ResetUI();
            }
            else
            {
                Info.isPaused = true;
                PlayerUI.SetCrosshair(false);
                Panels[1].SetActive(true);
            }
        }
    }

    private void ResetUI()
    {
        //Lock the Cursor in the center and enables GamePlay
        PlayerUI.SetCrosshair(true);

        //Sets the Pause Panel invisible
        Panels[1].SetActive(false);

        //Sets all panels visible exept Main Panel
        foreach (GameObject obj in PauseUI)
        {
            obj.SetActive(false);
        }
        PauseUI[0].SetActive(true);
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