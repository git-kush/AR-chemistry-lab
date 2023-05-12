using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnstart : MonoBehaviour
{
   
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void LoadNextScenefrbuild()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


     public void QuitGame()
    {
        Application.Quit();
    }
}
