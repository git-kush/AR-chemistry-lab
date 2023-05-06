using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneTraining()
    {
        SceneManager.LoadScene("Scenes/New Folder/Training Session Test");
    }
    public void LoadSceneViewComponents()
    {
        SceneManager.LoadScene("Scenes/New Folder/ViewComponentScene");
    }
    public void LoadSceneEvaluation()
    {
        //SceneManager.LoadScene(sceneName);
    }
    public void ExitApp()
    {
        Application.Quit();
    }












}
