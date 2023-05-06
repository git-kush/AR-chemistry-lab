using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
 
public class BundleWebLoaderScene3 : MonoBehaviour
{
    private string bundleUrl = "https://drive.google.com/uc?export=download&id=1VyAAl0vOQMnWUTcJLH9tV2jsojqY0KBP";
    private string assetName = "Scene3Prefab";
     
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