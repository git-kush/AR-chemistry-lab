using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiHideScriptTrainingSession : MonoBehaviour
{
    private GameObject Btn1,Btn2,Btn3;
    
    // Start is called before the first frame update
    void Start()
    {
        Btn1= GameObject.FindGameObjectWithTag("Button1");
        Btn2= GameObject.FindGameObjectWithTag("Button2");
        Btn3= GameObject.FindGameObjectWithTag("Button3");
        Btn1.SetActive(false);
        Btn2.SetActive(false);
        Btn3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlaceObjectsOnPlane.m_NumberOfPlacedObjects>0)
        {
            Btn1.SetActive(true);
            Btn2.SetActive(true);
            Btn3.SetActive(false);
        }
        if (TrainingSceneScript.ClickToComplete ==true)
        {
            Btn1.SetActive(false);
            Btn2.SetActive(false);
            Btn3.SetActive(true);
        }

    }
    public void onClickCompleted()
    {
        StartCoroutine(LoadSceneWithDelay());
    }
    public void OnPressedBack()
    {
        SceneManager.LoadScene("Scenes/New Folder/Menu");
    }
    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Scenes/New Folder/TrainingCompletionReward");

    }
}
