using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerUI
    {
        public static void SetCrosshair(bool state)
        {
            GameObject crosshair = GameObject.Find("Crosshair");

           if(state)
            {
                crosshair.SetActive(true);
            }
            else
            {
                crosshair.SetActive(false);
            }
        }
    }
}

