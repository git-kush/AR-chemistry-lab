using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ColourHeigh : MonoBehaviour
{   //public GameObject cylinder;
    // Start is called before the first frame update
    int a=0;
    float time;
    public int ni1;

    void Start(){

    }

    public TextMeshProUGUI user_name;
    public TMP_InputField user_inputField;
    public string n1;

    public void setName(){
	    user_name.text=user_inputField.text;
	    Debug.Log(user_inputField.text);
        n1=user_inputField.text;
       ni1=int.Parse(n1);
        Debug.Log(ni1);
        
 }
   
 
    // Update is called once per frame
     void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space))
        { a++; 
           Invoke("HeightChange",0.8f);
           
         }

          if(a>=ni1) Invoke("ColorChange",1f);
    
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
    }}
    
    

