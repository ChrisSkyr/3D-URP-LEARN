using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class GameManager : MonoBehaviour
{
 
    
  
    private GameInfo pauseInfo;

    public void Awake()
    {
        pauseInfo = GameObject.Find("GameManager").GetComponent<GameInfo>();

    }

    public void Update()
    {
       
    }


}
