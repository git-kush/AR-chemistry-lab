using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tm : MonoBehaviour
{
 public TextMeshProUGUI user_name;
 public TMP_InputField user_inputField;

 public void setName(){
	user_name.text=user_inputField.text;
	Debug.Log(user_inputField.text);
 }
}
