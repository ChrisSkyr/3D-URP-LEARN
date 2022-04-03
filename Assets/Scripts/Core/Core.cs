using UnityEngine;


namespace Core
{
    public class PlayerUI
    {
        //Hides or Reveals the Crosshair
        public static void SetCrosshair(bool state)
        {

            if (!state)
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
            GameInfo info = GameObject.Find("GameManager").GetComponent<GameInfo>();
            bool pausevalue = info.isPaused;
            return pausevalue;
        }


    }
}

