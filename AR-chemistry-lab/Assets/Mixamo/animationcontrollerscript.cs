using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class animationcontrollerscript : MonoBehaviour
{
    private Animator myAnim;
    private Rigidbody rigidbdy;
    public static float Speed=0.31f;
    private bool running;
    private bool isJumping;
    private float horizontalinput;
    private int spaceCount=-50;
    public GameObject gameObject;
      public float jumpforce = 300f;
       public bool IsGrounded;
public bool sp=true;

   
    // Start is called before the first frame update
    void Start()
    {
        myAnim=GetComponent<Animator>();
        rigidbdy=GetComponent<Rigidbody>();
        running=false;
        isJumping=false;
    }

    // Update is called once per frame
    void Update()
    {
        // isrunning=Input.GetKey(KeyCode.W);
        // isJumping=Input.GetKey(KeyCode.Space);

        // myAnim.SetBool("isrunning",isrunning);
        // myAnim.SetBool("isjumping",isJumping);
        


        // horizontalinput=Input.GetAxis("Horizontal");/
        // if(Mathf.Abs(horizontalinput)>0.01f)
        {
             if(SceneManager.GetActiveScene().name=="Scene2")
             {

            transform.rotation=Quaternion.LookRotation(new Vector3(-90f,0f,0f));
            rigidbdy.MovePosition(rigidbdy.position+transform.forward*Speed*Time.deltaTime);
             myAnim.SetBool("isrunning",true);
             }
             else{
                
            transform.rotation=Quaternion.LookRotation(new Vector3(90f,0f,0f));
            rigidbdy.MovePosition(rigidbdy.position+transform.forward*Speed*Time.deltaTime);
             myAnim.SetBool("isrunning",true);
             }
            // if(!running)
            // {
            //     running=true;
            //     myAnim.SetBool("isrunning",true); isJumping=false;

            //      if(Input.GetKeyDown(KeyCode.Space)&&rigidbdy.velocity.y==0)
            //      {
            //         rigidbdy.AddForce(Vector3.up * jumpforce);
            //         myAnim.SetBool("isjumping",true);
            //         // myAnim.SetBool("isjumping",true);
            //          running=false;
            // myAnim.SetBool("isrunning",false);
            // isJumping=false;
            //         // isJumping=true;
            //      }
            //      else
            //      {   running=true;
            //           myAnim.SetBool("isrunning",true); isJumping=false;
            //      }
            // }
        }
        // else if (running)
        // {
        //     running=false;
        //     myAnim.SetBool("isrunning",false);
        //     isJumping=false;

            
        // }
   if(Input.GetKey(KeyCode.Space))
   {
    spaceCount++;
    Debug.Log(spaceCount);
   }
   if(spaceCount>50)
   {
      myAnim.SetBool("isjumping",false);
   }

        if(Input.GetKeyDown(KeyCode.Space)&&rigidbdy.velocity.y==0)
        {
                    rigidbdy.AddForce(Vector3.up * jumpforce);
                    myAnim.SetBool("isjumping",true);
                    // myAnim.SetBool("isjumping",true);
                    isJumping=true;
                    Debug.Log("jump" + spaceCount);
                
                
                
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
                // rigidbdy.AddForce(Vector3.up * 100f);
                // myAnim.SetBool("isjumping",true);
               
                    myAnim.SetBool("isjumping",false);
                    isJumping=false;
                    running=false;
                    myAnim.SetBool("isrunning",false);
                    Debug.Log("fall" +spaceCount);
                    spaceCount=0;
                
        }
        // else{
        //     myAnim.SetBool("isjumping",false);

        // }
            // isJumping=false;
    //     void OnCollisionEnter2D(Collision col)
    //    {
    //     if(col.gameObject.CompareTag("Ground"))

    //     {
    //         isJumping=false;
    //     }
    //    }
    //     void OnCollisionExit2D(Collision2D col)
    //    {
    //     if(col.gameObject.CompareTag("Ground"))

    //     {
    //         isJumping=true;
    //     }
    //    }
 if (Input.GetKeyUp(KeyCode.S))
     {
        myAnim.SetBool("OnSpell",false);
     }
 if (Input.GetKeyDown(KeyCode.S))
     {
        myAnim.SetBool("OnSpell",true);
     }



//  if (Input.GetKeyUp(KeyCode.Space))
//      {
//         myAnim.SetBool("isjumping",false);
//         sp=true;
//      }
//  if (Input.GetKeyDown(KeyCode.Space)&&sp)
//      {
//  myAnim.SetBool("isjumping",true);
//  sp=false;                                  
//      }
 
   
        
        // if (Input.GetKey("right"))
        // {
        //    myAnimo.SetBool("isrunning",true);
        // }else
        // {
        //      myAnimo.SetBool("isrunning",false);
        // }

        // if (Input.GetKey("up"))
        // {
        //   myAnimo.SetBool("isjumping",true);
        // }else
        // {
        //       myAnimo.SetBool("isjumping",false);
        // }

    }
   
}
