using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instantiating : MonoBehaviour
{
     public GameObject player1;
     public float speed = 20f;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

     if (Input.GetMouseButtonDown(0))
     {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.transform.name =="Cube")
            {
             GameObject instFoam = Instantiate(player1, transform.position, Quaternion.identity);
             
             Rigidbody instFoamRB = instFoam.GetComponent<Rigidbody>();
           
             instFoamRB.AddForce(Vector3.right*50f);
 
             Destroy(instFoam, 3f);
            
            }
        }
     }


 







    }











}
