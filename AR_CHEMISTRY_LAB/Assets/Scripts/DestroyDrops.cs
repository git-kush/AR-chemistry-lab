using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDrops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision Collision){

        Destroy(gameObject, 0.05f);
    }
}
