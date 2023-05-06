/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class OnClickMotion3 : MonoBehaviour
{
    public string tagToMove = "ok1";
    private bool isMoved = false;
    private bool isMoving = false;



    private Vector3 initialPosition1;
    private Vector3 initialPosition2;
    private Vector3 initialPosition3;
    private Vector3 initialPosition4;
    private Vector3 initialPosition5;
    private Vector3 initialPosition6;
    private Vector3 initialPosition7;

    private Vector3 targetPosition1;
    private Vector3 targetPosition2;
    private Vector3 targetPosition3;
    private Vector3 targetPosition4;
    private Vector3 targetPosition5;
    private Vector3 targetPosition6;
    private Vector3 targetPosition7;




    public bool isVisible = false;
    
    private GameObject[] objectsToChange;
    private GameObject elementToMove1;
    private GameObject elementToMove2;
    private GameObject elementToMove3;
    private GameObject elementToMove4;
    private GameObject elementToMove5;
    private GameObject elementToMove6;
    private GameObject elementToMove7;

    public GameObject[] Labels;

    void Start()
    {
        // get the initial position of the object
        elementToMove1 = GameObject.FindGameObjectWithTag("Part1");
        elementToMove2 = GameObject.FindGameObjectWithTag("Part2");
        elementToMove3 = GameObject.FindGameObjectWithTag("Part3");
        elementToMove4 = GameObject.FindGameObjectWithTag("Part4");
        elementToMove5 = GameObject.FindGameObjectWithTag("Part5");
        elementToMove6 = GameObject.FindGameObjectWithTag("Part6");
        elementToMove7 = GameObject.FindGameObjectWithTag("Part7");


        foreach (GameObject i in Labels)
        {
            i.SetActive(false);
        }







        initialPosition1 = elementToMove1.transform.position;
        initialPosition2 = elementToMove2.transform.position;
        initialPosition3 = elementToMove3.transform.position;
        initialPosition4 = elementToMove4.transform.position;
        initialPosition5 = elementToMove5.transform.position;
        initialPosition6 = elementToMove5.transform.position;
        initialPosition7 = elementToMove5.transform.position;
        /*
         * For Hiding the 3d Text Lables it was
        objectsToChange = GameObject.FindGameObjectsWithTag("Text3D");
        foreach (GameObject obj in objectsToChange)
        {
            obj.SetActive(false);
        }
        */
/*

    }


    private void Update()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           
            if (!isMoved && !isMoving)
            {
                // calculate the target position for the element
                {
                    //   For Part 1
                    isMoving = true;
                    StartCoroutine(Shift1());
                }
                {
                    // For Part 2

                    StartCoroutine(Shift2());
                }
                {
                    // For Part 3

                    StartCoroutine(Shift3());
                }
                {
                    // For Part 4 

                    StartCoroutine(Shift4());
                }
                StartCoroutine(Shift5());
                StartCoroutine(Shift6());
                StartCoroutine(Shift7());




                /*foreach (GameObject obj in objectsToChange)
                {
                    obj.SetActive(true);
                }*//*
            }
            else if (isMoved&& !isMoving)
            {
                // start moving the element back to its initial position

                isMoving = true;

                StartCoroutine(Shift7Back());
                StartCoroutine(Shift6Back());
                StartCoroutine(Shift5Back());
                StartCoroutine(Shift4Back());
                StartCoroutine(Shift3Back());
                StartCoroutine(Shift2Back());
                StartCoroutine(Shift1Back());

                
                foreach (GameObject i in Labels)
                {
                    i.SetActive(false);
                }

                /*foreach (GameObject obj in objectsToChange)
                {
                    obj.SetActive(false);
                }*//*
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



    

    private IEnumerator Shift1()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.5f);

        targetPosition1 = elementToMove1.transform.position + new Vector3(0.3412f, 0, 0);

        // start moving the element
        StartCoroutine(MoveElement(elementToMove1.transform, targetPosition1, 0.5f));
        

        
    }
    private IEnumerator Shift2()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(2f);
        targetPosition2 = elementToMove2.transform.position + new Vector3(0, 0.186f, 0);
        // start moving the element
        StartCoroutine(MoveElement(elementToMove2.transform, targetPosition2, 0.5f));
        
    }
    private IEnumerator Shift3()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(4f);
        targetPosition3 = elementToMove3.transform.position + new Vector3(0, 0, 0.464f);
        // start moving the element
        StartCoroutine(MoveElement(elementToMove3.transform, targetPosition3, 0.5f));
        
    }
    private IEnumerator Shift4()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(6f);

        targetPosition4 = elementToMove4.transform.position + new Vector3(0, 0, -0.5576f);
        // start moving the element
        StartCoroutine(MoveElement(elementToMove4.transform, targetPosition4, 0.5f));
 
      


    }
    private IEnumerator Shift5()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(8f);


        targetPosition5 = elementToMove5.transform.position + new Vector3(0, 0, -0.108f);
        // start moving the element
        StartCoroutine(MoveElement(elementToMove5.transform, targetPosition5, 0.5f));

    }
    private IEnumerator Shift6()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(10f);


        targetPosition6 = elementToMove6.transform.position + new Vector3(0, 0.1488f, 0);
        // start moving the element
        StartCoroutine(MoveElement(elementToMove6.transform, targetPosition6, 0.5f));

        
    }
    private IEnumerator Shift7()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(12f);


        targetPosition7 = elementToMove7.transform.position + new Vector3(-0.4604f, 0, 0);
        // start moving the element
        StartCoroutine(MoveElement(elementToMove7.transform, targetPosition7, 0.5f));

        foreach (GameObject i in Labels)
        {
            i.SetActive(true);
        }
        StartCoroutine(IsMoving());

    }














    private IEnumerator IsMoving()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(1f);



        // start moving the element
        isMoved = true;
        isMoving = false;



    }
    private IEnumerator IsMovingR()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(1f);



        // start moving the element
        isMoved = false;
        isMoving = false;



    }


    private IEnumerator Shift1Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(12f);

        

        // start moving the element
        StartCoroutine(MoveElement(elementToMove1.transform, initialPosition1, 0.5f));
        StartCoroutine(IsMovingR());


    }
    private IEnumerator Shift2Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(10f);
      
        // start moving the element
        StartCoroutine(MoveElement(elementToMove2.transform, initialPosition2, 0.5f));
        
        
    }
    private IEnumerator Shift3Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(8f);
      
        StartCoroutine(MoveElement(elementToMove3.transform, initialPosition3, 0.5f));
        
        
    }
    private IEnumerator Shift4Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(6f);
      
        StartCoroutine(MoveElement(elementToMove5.transform, initialPosition5, 0.5f));
      
    }
    private IEnumerator Shift5Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(4f);

        StartCoroutine(MoveElement(elementToMove5.transform, initialPosition5, 0.5f));

    }
    private IEnumerator Shift6Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(2f);

        StartCoroutine(MoveElement(elementToMove6.transform, initialPosition6, 0.5f));

    }
    private IEnumerator Shift7Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveElement(elementToMove7.transform, initialPosition7, 0.5f));

    }









}*/
