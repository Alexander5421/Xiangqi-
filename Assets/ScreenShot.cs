using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
   
    private string path;
    private string fileName;
    [SerializeField]
    [Range(1, 4)]
    private int size = 1;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            path=Application.dataPath+"/ScreenShot/";
            fileName = "screenshot ";
            fileName += System.Guid.NewGuid().ToString() + ".png";
 
            ScreenCapture.CaptureScreenshot(path + fileName, size);
        }
    }
}
