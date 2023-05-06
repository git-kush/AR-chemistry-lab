using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrainingSceneCompletionScript : MonoBehaviour
{
    public static int rewardCoins;
    // Start is called before the first frame update
    void Start()
    {
        rewardCoins += 10;
        StartCoroutine(BackAfter3Sec());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator BackAfter3Sec()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("");

    }
}
