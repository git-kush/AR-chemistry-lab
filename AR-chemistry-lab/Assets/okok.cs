using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class okok : MonoBehaviour
{
    public Animator anim;
    public string ss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
 if(collision.gameObject.tag == "ok1")
 {
    fadetolevel("Scenes/Scene2");
    //  SceneManager.LoadScene("Scenes/Scene2");


 }
 if(collision.gameObject.name == "ok2")
 {
     fadetolevel("Scenes/Scene3");

    //  SceneManager.LoadScene("Scenes/Scene3");
 }
    }
    public void fadetolevel(string s)
    {
        ss =s;
        anim.SetTrigger("FadeOut");
    }
public void OnFadeComplete()
{
    SceneManager.LoadScene(ss);
}










}
