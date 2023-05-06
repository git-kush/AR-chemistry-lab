using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CubeRotation : MonoBehaviour
{
    public Vector3 RotateAmount;  // degrees per second to rotate in each axis. Set in inspector.
   
    // Update is called once per frame
    void Update () {
        transform.Rotate(RotateAmount * Time.deltaTime);
    }
}
