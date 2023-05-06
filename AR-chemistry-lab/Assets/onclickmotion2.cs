using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class onclickmotion2 : MonoBehaviour
{
    public string tagToMove = "ok1";
    private bool isMoved = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float moveDuration = 0.5f; // adjust this to change the speed of the transition
    public bool isVisible = false;
    private GameObject[] objectsToChange;
    void Start()
    {
        // get the initial position of the object
        initialPosition = transform.position;
        objectsToChange = GameObject.FindGameObjectsWithTag("Text3D");
        foreach (GameObject obj in objectsToChange)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        // check if there is a touch on the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // select the element with the specific tag
                GameObject elementToMove = GameObject.FindGameObjectWithTag(tagToMove);

                if (elementToMove != null && !isMoved)
                {
                    // calculate the target position for the element
                    targetPosition = elementToMove.transform.position + new Vector3(0, 0.3f, 0);
                    // start moving the element
                    StartCoroutine(MoveElement(elementToMove.transform, targetPosition, moveDuration));
                    isMoved = true;
                    foreach (GameObject obj in objectsToChange)
                    {
                        obj.SetActive(true);
                    }
                }
                else if (elementToMove != null && isMoved)
                {
                    // start moving the element back to its initial position
                    StartCoroutine(MoveElement(elementToMove.transform, initialPosition, moveDuration));
                    isMoved = false;
                    foreach (GameObject obj in objectsToChange)
                    {
                        obj.SetActive(false);
                    }
                }
            }
        }
    }

    IEnumerator MoveElement(Transform element, Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = element.position;

        // lerp the position of the element over time
        while (elapsedTime < duration)
        {
            element.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // set the element's position to the target position to avoid any rounding errors
        element.position = targetPosition;
    }
}
