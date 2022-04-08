using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPaused = false;
    public string Version;




    public void Awake()
    {
        Instance = this; 
    }

  


}
