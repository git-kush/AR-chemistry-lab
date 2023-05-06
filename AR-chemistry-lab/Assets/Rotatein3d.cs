using UnityEngine;

public class Rotatein3d : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Rotate the object around the world Y axis
            transform.Rotate(0, -touchDeltaPosition.x * 0.5f, 0, Space.World);

            // Rotate the object around the local X axis
            transform.Rotate(touchDeltaPosition.y * 0.5f, 0, 0, Space.Self);
        }
    }
}
