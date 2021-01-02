using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTextureSetup : MonoBehaviour
{
    public Camera cameraPortalOrange;
    public Material cameraMatOrange;
    public Camera cameraPortalBlue;
    public Material cameraMatBlue;

    // Start is called before the first frame update
    void Start()
    {
      if(cameraPortalOrange.targetTexture != null)
      {
        cameraPortalOrange.targetTexture.Release();
      }
      cameraPortalOrange.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
      cameraMatOrange.mainTexture = cameraPortalOrange.targetTexture;

      if(cameraPortalBlue.targetTexture != null)
      {
        cameraPortalBlue.targetTexture.Release();
      }
      cameraPortalBlue.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
      cameraMatBlue.mainTexture = cameraPortalBlue.targetTexture;

    }

}
