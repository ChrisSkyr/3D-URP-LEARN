using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private List<GameObject> Panels = new List<GameObject>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < MainMenu.transform.childCount; i++)
        {
            Panels.Add(MainMenu.transform.GetChild(i).gameObject);
        }
    }

    public void OnSettings()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
