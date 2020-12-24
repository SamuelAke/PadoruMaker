using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Handler : MonoBehaviour
{
    private static SS_Handler instance;

    private Camera myCamera;
    private bool takeSsOnNextFrame;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    public void OnPostRender()
    {
        if(takeSsOnNextFrame)
        {
            takeSsOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraSS.png", byteArray);
            Debug.Log("Guardado CameraSS.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakeSS(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeSsOnNextFrame = true;
    }

    public static void TakeSs_Static(int width, int height)
    {
        instance.TakeSS(width, height);
    }

}
