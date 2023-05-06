using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// LevelsScrollViewController - generate scrollview items
/// handle all things those required for scrollview controller
/// </summary>
public class LevelsScrollViewController : MonoBehaviour
{
    public GameObject[] Parts;
    [SerializeField] Text levelNumberText;
    [SerializeField] int numberOfLevels;
    [SerializeField] GameObject levelBtnPref;
    [SerializeField] Transform levelBtnParent;

    private void Start()
    {
        LoadLevelButtons();
        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
    }

    // load level buttons on game start
    private void LoadLevelButtons()
    {
        for (int i = 0; i < numberOfLevels; i++)
        {
            GameObject levelBtnObj = Instantiate(levelBtnPref, levelBtnParent) as GameObject;
            levelBtnObj.GetComponent<LevelButtonItem>().levelIndex = i;
            levelBtnObj.GetComponent<LevelButtonItem>().levelsScrollViewController = this;
        }
    }

    // user defined public method to handle something when user press any level button
    // at present we are just changing level number, in future you can do anything that is required at here
    public void OnLevelButtonClick(int levelIndex)
    {
        //levelNumberText.text = "Level " + (levelIndex + 1);


        if (levelIndex == 0)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[0].SetActive(true);
        }
        if (levelIndex == 1)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[1].SetActive(true);
        }
        if (levelIndex == 2)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[2].SetActive(true);
        }
        if (levelIndex == 3)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[3].SetActive(true);

        }
        if (levelIndex == 4)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[4].SetActive(true);
        }
        if (levelIndex == 5)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[5].SetActive(true);
        }
        if (levelIndex == 6)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[6].SetActive(true);
        }







    }

}
