using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Core;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Player variables
    public GameObject player = null;
    public PlayerInput playerInput = null;

    public bool isPaused = false;
    public string Version;




    public void Awake()
    {
        Instance = this;
        playerInput = player.GetComponent<PlayerInput>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


}
