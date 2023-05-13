using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tm : MonoBehaviour
{
 public static TextMeshProUGUI n1pass;
 public TMP_InputField N1input;

 public void AssignParameter(){
	n1pass.text=N1input.text;
	
	// Debug.Log(user_inputField.text);
 }
}
