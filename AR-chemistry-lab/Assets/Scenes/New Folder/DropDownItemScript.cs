using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownItemScript : MonoBehaviour
{
    public GameObject[] Parts;
    
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();
       
        List<string> items = new List<string>();
        items.Add("Part 1");
        items.Add("Part 2");
        items.Add("Part 3");
        items.Add("Part 4");
        items.Add("Part 5");
        items.Add("Part 6");
        items.Add("Part 7");
        foreach(var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }
        DropDownItemSelected(dropdown);
        dropdown.onValueChanged.AddListener(delegate { DropDownItemSelected(dropdown); });

        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }




    }
    void DropDownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        string partNum = dropdown.options[index].text;


        if(partNum=="Part 1")
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[0].SetActive(true);
        }
        if (partNum == "Part 2")
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[1].SetActive(true);
        }
        if (partNum == "Part 3")
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[2].SetActive(true);
        }
        if (partNum == "Part 4")
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[3].SetActive(true);

        }
        if (partNum == "Part 5")
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[4].SetActive(true);
        }
        if (partNum == "Part 6")
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[5].SetActive(true);
        }
        if (partNum == "Part 7")
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Parts[6].SetActive(true);
        }
















    }
}
