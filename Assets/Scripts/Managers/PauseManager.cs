using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public bool isPaused = false;
    private bool pausevalue = false;

    //Buttons
    private GameObject PausePanel;
    private PauseInfo pauseInfo;


    private void Awake()
    {
        pauseInfo = GameObject.Find("GameManager").GetComponent<PauseInfo>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseInfo.isReseted = true;
            if(pausevalue)
            {
                isPaused = false;
                pausevalue = false;
            }
            else
            {
                isPaused = true;
                pausevalue = true;
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        pausevalue = false;
    }

   
}
