using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrainingSceneCompletionSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMenuSceneWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator LoadMenuSceneWithDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scenes/New Folder/Menu");

    }
}
