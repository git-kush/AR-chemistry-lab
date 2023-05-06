using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public int currentFoodIndex = 0;
    public GameObject[] foodModels;





   
    void Start()
    {
        currentFoodIndex = PlayerPrefs.GetInt("SelectedFood", 0);
        foreach (GameObject food in foodModels)
            food.SetActive(false);
        foodModels[currentFoodIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNext()
    {
        foodModels[currentFoodIndex].SetActive(false);


        currentFoodIndex++;
        if(currentFoodIndex==foodModels.Length)
        {
            currentFoodIndex = 0;
        }
        foodModels[currentFoodIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedFood", currentFoodIndex);




    }

    public void ChangePrevious()
    {
        foodModels[currentFoodIndex].SetActive(false);


        currentFoodIndex--;
        if (currentFoodIndex == -1)
        {
            currentFoodIndex = foodModels.Length - 1;
        }
        foodModels[currentFoodIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedFood", currentFoodIndex);




    }













}
