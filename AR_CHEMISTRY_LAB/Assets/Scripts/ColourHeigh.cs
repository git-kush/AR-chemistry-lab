using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourHeigh : MonoBehaviour
{   //public GameObject cylinder;
    // Start is called before the first frame update
    int a=0;
    float time;
    private string input1;
    private string input2;
    float i1,i2;

    void Start(){

    }
   
 
    // Update is called once per frame
     void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space))
        { a++; 
           Invoke("HeightChange",0.8f);
         }

          if(a>=i1) Invoke("ColorChange",1f);
    

   }
      public void ReadScriptInput1(string s){
      input1=s;
      Debug.Log(input1);
      i1=((int)input1[0]-48);

      }
      public void ReadScriptInput2(string t){
      input2=t;
      Debug.Log(input2);
     i2=((int)input2[0]-48);
      }
  public void check(){
         a++; 
           Invoke("HeightChange",0.8f);
         
    }
     void ColorChange(){
         
         GetComponent<Renderer>().material.color = Color.red;
    }
     void HeightChange(){
        transform.localScale = transform.localScale + new Vector3(0, 0 , 10f);
    }
    
    
}
