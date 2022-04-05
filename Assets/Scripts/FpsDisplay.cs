using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    private float pollingTime = 2f;
    private float time;
    private int frameCount;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
;       }

    }
}
