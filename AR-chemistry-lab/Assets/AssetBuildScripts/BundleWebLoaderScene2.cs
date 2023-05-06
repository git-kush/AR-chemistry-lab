using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
 
public class BundleWebLoaderScene2 : MonoBehaviour
{
    private string bundleUrl = "https://drive.google.com/uc?export=download&id=1l9xYciY8yDyZDu5pxQKNUMY1DWFDPg4U";
    private string assetName = "Scene2Prefab";
     
    // Start is called before the first frame update
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null) {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }
            Instantiate(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false);
        }
    }
 
 
}