using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tm : MonoBehaviour
{
 public int n1pass;
 public TMP_InputField N1input;

 public void AssignParameter(){
	string sn1 =N1input.text;
	if (!string.IsNullOrEmpty(sn1))
        {
            n1pass = int.Parse(sn1);
           // Debug.Log("Integer value: " + intValue);
        }
	
	// Debug.Log(user_inputField.text);
 }
}
