using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourHeigh : MonoBehaviour
{   //public GameObject cylinder;
    // Start is called before the first frame update
    int a=0;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { a++; 
         // time=Time.deltatime;
         }

          if(a>=4) GetComponent<Renderer>().material.color = Color.red;
    
    }

    
}
