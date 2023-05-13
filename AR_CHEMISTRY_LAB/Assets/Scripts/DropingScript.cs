using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingScript : MonoBehaviour
{      public GameObject drop;
       public Transform spwanposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space)) SpwanDrop();  
    }

    public void SpwanDrop(){
        Instantiate(drop, spwanposition.position, Quaternion.identity);
    }
}
