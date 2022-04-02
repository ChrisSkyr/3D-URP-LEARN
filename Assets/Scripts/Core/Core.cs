using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public class PlayerUI 
    {
        //Hides or Reveals the Crosshair
        public static void SetCrosshair(bool state)
        {
            GameObject crosshair = GameObject.Find("Crosshair");

           if(state)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

       
       
    }
    public class Game
    {
        //Have gamestate of the game
        public static bool isPaused()
        {
            PauseManager pauseMaanager = GameObject.Find("GameManager").GetComponent<PauseManager>();
            bool pausevalue = pauseMaanager.isPaused;
            return pausevalue;
        }


    }
}

