using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class OnClickMotion : MonoBehaviour
{
    public string tagToMove = "ok1";
    private bool isMoved = false;
    private Vector3 initialPosition1;
    private Vector3 initialPosition2;
    private Vector3 initialPosition3;
    private Vector3 initialPosition4;
    private Vector3 initialPosition5;

    private Vector3 targetPosition1;
    private Vector3 targetPosition2;
    private Vector3 targetPosition3;
    private Vector3 targetPosition4;
    private Vector3 targetPosition5;
    private Vector3 targetPositionFor3dView;


    private float moveDuration = 0.5f; // adjust this to change the speed of the transition
    public bool isVisible = false;
    private GameObject[] objectsToChange;
    private GameObject elementToMove1;
    private GameObject elementToMove2;
    private GameObject elementToMove3;
    private GameObject elementToMove4;
    private GameObject elementToMove5;
    private GameObject element3D1;
    private GameObject element3D2;
    private GameObject element3D3;
    private GameObject element3D4;
    private GameObject element3D5;
    void Start()
    {
        // get the initial position of the object
         elementToMove1 = GameObject.FindGameObjectWithTag("Part1");
         elementToMove2 = GameObject.FindGameObjectWithTag("Part2");
        elementToMove3 = GameObject.FindGameObjectWithTag("Part3");
         elementToMove4 = GameObject.FindGameObjectWithTag("Part4");
        elementToMove5 = GameObject.FindGameObjectWithTag("Part5");
        element3D1 = GameObject.FindGameObjectWithTag("3d1");
        element3D2 = GameObject.FindGameObjectWithTag("3d2");
        element3D3 = GameObject.FindGameObjectWithTag("3d3");
        element3D4 = GameObject.FindGameObjectWithTag("3d4");
        element3D5 = GameObject.FindGameObjectWithTag("3d5");

        element3D1.SetActive(false);
        element3D2.SetActive(false);
        element3D3.SetActive(false);
        element3D4.SetActive(false);
        element3D5.SetActive(false);






        initialPosition1 = elementToMove1.transform.position;
        initialPosition2 = elementToMove2.transform.position;
        initialPosition3 = elementToMove3.transform.position;
        initialPosition4 = elementToMove4.transform.position;
        initialPosition5 = elementToMove5.transform.position;
        /*
         * For Hiding the 3d Text Lables it was
        objectsToChange = GameObject.FindGameObjectsWithTag("Text3D");
        foreach (GameObject obj in objectsToChange)
        {
            obj.SetActive(false);
        }
        */
    }
    private void Update()
    {
        // Check if the user has tapped on the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isMoved)
        {
            // Raycast to get the game object that was clicked on
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the game object has the Player tag
                if (hit.collider.gameObject.CompareTag("Part1"))
                {
                    // Get a reference to the Player game object
                    
                    elementToMove1.SetActive(false);
                    elementToMove2.SetActive(false);
                    elementToMove3.SetActive(false);
                    elementToMove4.SetActive(false);
                    elementToMove5.SetActive(false);
                    element3D1.SetActive(true);
                    
                    element3D2.SetActive(false);
                    element3D3.SetActive(false);
                    element3D4.SetActive(false);
                    element3D5.SetActive(false);


                }
                else if (hit.collider.gameObject.CompareTag("Part2"))
                {
                    // Get a reference to the Player game object
                    
                    elementToMove1.SetActive(false);
                    elementToMove2.SetActive(false);
                    elementToMove3.SetActive(false);
                    elementToMove4.SetActive(false);
                    elementToMove5.SetActive(false);
                    element3D2.SetActive(true); element3D1.SetActive(false);
                    
                    element3D3.SetActive(false);
                    element3D4.SetActive(false);
                    element3D5.SetActive(false);


                }
                else if (hit.collider.gameObject.CompareTag("Part3"))
                {
                    // Get a reference to the Player game object
                    
                    elementToMove1.SetActive(false);
                    elementToMove2.SetActive(false);
                    elementToMove3.SetActive(false);
                    elementToMove4.SetActive(false);
                    elementToMove5.SetActive(false);
                    element3D3.SetActive(true);
                    element3D1.SetActive(false);
                    element3D2.SetActive(false);
                    
                    element3D4.SetActive(false);
                    element3D5.SetActive(false);


                }
                else if (hit.collider.gameObject.CompareTag("Part4"))
                {
                    // Get a reference to the Player game object
                    
                    elementToMove1.SetActive(false);
                    elementToMove2.SetActive(false);
                    elementToMove3.SetActive(false);
                    elementToMove4.SetActive(false);
                    elementToMove5.SetActive(false);
                    element3D4.SetActive(true);
                    element3D5.SetActive(true);
                    element3D1.SetActive(false);
                    element3D2.SetActive(false);
                    element3D3.SetActive(false);
                   


                }
                else if (hit.collider.gameObject.CompareTag("Part5"))
                {
                    // Get a reference to the Player game object
                    
                    elementToMove1.SetActive(false);
                    elementToMove2.SetActive(false);
                    elementToMove3.SetActive(false);
                    elementToMove4.SetActive(false);
                    elementToMove5.SetActive(false);
                    element3D5.SetActive(true);
                    element3D4.SetActive(true);
                    element3D1.SetActive(false);
                    element3D2.SetActive(false);
                    element3D3.SetActive(false);
                    


                }
            }
        }
    }
    public void OnPressedBack()
    {
        elementToMove1.SetActive(true);
        elementToMove2.SetActive(true);
        elementToMove3.SetActive(true);
        elementToMove4.SetActive(true);
        elementToMove5.SetActive(true);
        element3D5.SetActive(false);
        element3D4.SetActive(false);
        element3D1.SetActive(false);
        element3D2.SetActive(false);
        element3D3.SetActive(false);
    }

    public void OnButtonClick()
    {
        // check if there is a touch on the screen
        
        
            

           
            
                // select the element with the specific tag
               

                if ( !isMoved)
                {
                    // calculate the target position for the element
                    {
                        //   For Part 1

                        targetPosition1 = elementToMove1.transform.position + new Vector3(0, 0.2f, 0);
                targetPositionFor3dView = elementToMove1.transform.position + new Vector3(0, 0.2f, 0);
                // start moving the element
                StartCoroutine(MoveElement(elementToMove1.transform, targetPosition1, moveDuration));
                        isMoved = true;
                    }
                    {
                        // For Part 2

                        targetPosition2 = elementToMove2.transform.position + new Vector3(-0.174f,0, 0);
                        // start moving the element
                        StartCoroutine(MoveElement(elementToMove2.transform, targetPosition2, moveDuration));
                        isMoved = true;
                    }
                    {
                        // For Part 3

                        targetPosition3 = elementToMove3.transform.position + new Vector3(0, 0, 0.2005f);
                        // start moving the element
                        StartCoroutine(MoveElement(elementToMove3.transform, targetPosition3, moveDuration));
                        isMoved = true;
                    }
                    {
                        // For Part 4

                        targetPosition4 = elementToMove4.transform.position + new Vector3(0,0, -0.21f);
                        // start moving the element
                        StartCoroutine(MoveElement(elementToMove4.transform, targetPosition4, moveDuration));
                        isMoved = true;
                    }
                    {
                        // For Part 5

                        targetPosition5 = elementToMove5.transform.position + new Vector3(0, 0, -0.21f);
                        // start moving the element
                        StartCoroutine(MoveElement(elementToMove5.transform, targetPosition5, moveDuration));
                        isMoved = true;
                    }






                    /*foreach (GameObject obj in objectsToChange)
                    {
                        obj.SetActive(true);
                    }*/
                }
                else if ( isMoved)
                {
                    // start moving the element back to its initial position
                    StartCoroutine(MoveElement(elementToMove1.transform, initialPosition1, moveDuration));
                    StartCoroutine(MoveElement(elementToMove2.transform, initialPosition2, moveDuration));
                    StartCoroutine(MoveElement(elementToMove3.transform, initialPosition3, moveDuration));
                    StartCoroutine(MoveElement(elementToMove4.transform, initialPosition4, moveDuration));
                    StartCoroutine(MoveElement(elementToMove5.transform, initialPosition5, moveDuration));

                    isMoved = false;

                    /*foreach (GameObject obj in objectsToChange)
                    {
                        obj.SetActive(false);
                    }*/
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
