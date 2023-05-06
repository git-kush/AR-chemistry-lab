using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonVisibilityofComponents : MonoBehaviour
{





    public GameObject[] Parts;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick1()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        Parts[0].SetActive(true);
    }
    public void OnButtonClick2()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        Parts[1].SetActive(true);
    }
    public void OnButtonClick3()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        Parts[2].SetActive(true);
    }
    public void OnButtonClick4()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        Parts[3].SetActive(true);

    }
    public void OnButtonClick5()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        Parts[4].SetActive(true);
    }
    public void OnButtonClick6()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        Parts[5].SetActive(true);
    }
    public void OnButtonClick7()
    {
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        Parts[6].SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Scenes/New Folder/Menu");
    }













}
