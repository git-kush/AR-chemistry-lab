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
           Invoke("HeightChange",0.8f);
         }

          if(a>=4) Invoke("ColorChange",1f);
    
    }

    void ColorChange(){
         
         GetComponent<Renderer>().material.color = Color.red;
    }
    void HeightChange(){
        transform.localScale = transform.localScale + new Vector3(0, 0 , 10f);
    }

    
}
