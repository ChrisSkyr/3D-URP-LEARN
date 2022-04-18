using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TakeScreenShot : MonoBehaviour
{
    GameManager gm = GameManager.Instance;

    [SerializeField] private Canvas canvas;
    [SerializeField] private bool showCanvas = false;

    public int width = 256;
    public int height = 256;

   

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // gm.playerInput.actions["ScreenShot"].triggered
        if (Input.GetKeyDown(KeyCode.F2))
        {
            PlayerPrefs.SetInt("iconNumber", PlayerPrefs.GetInt("iconNumber") + 1);
            if (!showCanvas) canvas.enabled = false;
            // ScreenCapture.CaptureScreenshot("GameScreenShot.png");
            StartCoroutine(CoroutineScreenShot());    
            if (canvas.enabled == false) canvas.enabled = true;
        }
    }

    private IEnumerator CoroutineScreenShot()
    {
        yield return new WaitForEndOfFrame();

        
        

        Texture2D screenShotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);

        Rect rect = new Rect(0, 0, width, height);
        screenShotTexture.ReadPixels(rect, 0, 0);
        screenShotTexture.Apply();

        byte[] bytearray = screenShotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + $"/icons/{PlayerPrefs.GetInt("iconNumber").ToString()}.png", bytearray);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif

    }


}
