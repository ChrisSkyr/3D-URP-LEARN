using Core;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    //Instance of UIManger
    public static UIManager Instance;

    #region Version
    [SerializeField]
    [Header("The Current Version")]
    private string Version;
    private TextMeshProUGUI VersionText;
    #endregion

    #region UI Dictionaries
    private GameObject UIPanels;
    [SerializeField]
    private Dictionary<string, GameObject> Panels = new Dictionary<string, GameObject>();
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private Dictionary<string, GameObject> PauseUI = new Dictionary<string, GameObject>();
    #endregion

    #region Class Refrences
    private GameManager gm;
    private SceneChanger sceneChanger;
    private PlayerInput playerInput;
    #endregion


    private void Awake()
    {
        Instance = this;


        gm = GameManager.Instance;
        sceneChanger = SceneChanger.Instance;
        VersionText = GameObject.Find("Version").GetComponent<TextMeshProUGUI>();
        playerInput = GameObject.Find("FirstPersonController").GetComponent<PlayerInput>();

        UIPanels = GameObject.Find("Panels");
        for (int i = 0; UIPanels.transform.childCount > i; i++)
        {
            Panels.Add(UIPanels.transform.GetChild(i).name, UIPanels.transform.GetChild(i).gameObject);
        }


        for (int i = 0; i < PausePanel.transform.childCount; i++)
        {
            PauseUI.Add(PausePanel.transform.GetChild(i).name ,PausePanel.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        //Sets the Version of the Game
        gm.Version = Version;
        VersionText.text = Version;

        //Resets the UI
        ResetUI();

        Panels["PausePanel"].SetActive(false);
    }

    private void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if (playerInput != null)
        {
            if (playerInput.actions["ExitUI"].triggered)
            {
                if (gm.isPaused)
                {
                    gm.isPaused = false;
                    ResetUI();
                }
                else
                {
                    gm.isPaused = true;
                    PlayerUI.SetCrosshair(false);
                    Panels["PausePanel"].SetActive(true);
                }
            }
        }

    }

    private void ResetUI()
    {
        //Lock the Cursor in the center and enables GamePlay
        PlayerUI.SetCrosshair(true);

        //Sets the Pause Panel invisible
        Panels["PausePanel"].SetActive(false);

        //Sets all panels visible exept Main Panel
        foreach (var obj in PauseUI.Values)
        {
            obj.SetActive(false);
        }
        PauseUI["Main"].SetActive(true);
    }

    #region Main Buttons
    public void Settings()
    {
        PauseUI["Main"].SetActive(false);
        PauseUI["Settings"].SetActive(true);
    }

    public void Resume()
    {
        gm.isPaused = false;
        PausePanel.SetActive(false);
        PlayerUI.SetCrosshair(true);
    }

    public void ExitGame()
    {
        sceneChanger.OnSceneExit();
    }
    #endregion
}