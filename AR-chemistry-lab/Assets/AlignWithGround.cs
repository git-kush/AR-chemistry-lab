using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class AlignWithGround : MonoBehaviour
{
    private Quaternion baseRotation;

    void Start()
    {
        // Store the initial rotation of the device
        baseRotation = Input.gyro.attitude;
    }

    void Update()
    {
        // Calculate the rotation of the device relative to its initial rotation
        Quaternion deviceRotation = Input.gyro.attitude * Quaternion.Inverse(baseRotation);

        // Convert the device rotation to Euler angles
        Vector3 eulerAngles = deviceRotation.eulerAngles;

        // Set the rotation of the object to align with the ground plane
        transform.rotation = Quaternion.Euler(90.0f, eulerAngles.y, 0.0f);
    }
}
