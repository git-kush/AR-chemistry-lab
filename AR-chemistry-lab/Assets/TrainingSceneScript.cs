using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class TrainingSceneScript : MonoBehaviour
{
    public string tagToMove = "ok1";
    private bool isMoved = false;
    private bool isMoving = false;
    public static bool ClickToComplete = false;

    public static int CurrentState = 0;
    public static int Max = 8;
    public int N = 0;
    public GameObject[] Parts;
    public static bool itisIncrement=false;

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
    public bool prefabspawned = false;
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



        /*
         * For Hiding the 3d Text Lables it was
        objectsToChange = GameObject.FindGameObjectsWithTag("Text3D");
        foreach (GameObject obj in objectsToChange)
        {
            obj.SetActive(false);
        }
        */



        elementToMove1 = GameObject.FindGameObjectWithTag("Part1");
        elementToMove2 = GameObject.FindGameObjectWithTag("Part2");
        elementToMove3 = GameObject.FindGameObjectWithTag("Part3");
        elementToMove4 = GameObject.FindGameObjectWithTag("Part4");
        elementToMove5 = GameObject.FindGameObjectWithTag("Part5");
        elementToMove6 = GameObject.FindGameObjectWithTag("Part6");
        elementToMove7 = GameObject.FindGameObjectWithTag("Part7");
        /* Parts[0] = elementToMove1;
         Parts[1] = elementToMove2;
         Parts[2] = elementToMove3;
         Parts[3] = elementToMove4;
         Parts[4] = elementToMove5;
         Parts[5] = elementToMove6;
         Parts[6] = elementToMove7;*/


        foreach (GameObject i in Parts)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in Labels)
        {
            i.SetActive(false);
        }






        initialPosition1 = elementToMove1.transform.position;
        initialPosition2 = elementToMove2.transform.position;
        initialPosition3 = elementToMove3.transform.position;
        initialPosition4 = elementToMove4.transform.position;
        initialPosition5 = elementToMove5.transform.position;
        initialPosition6 = elementToMove6.transform.position;
        initialPosition7 = elementToMove7.transform.position;




        //Target Positions
        targetPosition1 = elementToMove1.transform.position + new Vector3(0.3412f, 0, 0);
        targetPosition2 = elementToMove2.transform.position + new Vector3(0, 0.186f, 0);
        targetPosition3 = elementToMove3.transform.position + new Vector3(0, 0, 0.464f);
        targetPosition4 = elementToMove4.transform.position + new Vector3(0, 0, -0.5576f);
        targetPosition5 = elementToMove5.transform.position + new Vector3(0, 0, -0.108f);
        targetPosition6 = elementToMove6.transform.position + new Vector3(0, 0.1488f, 0);
        targetPosition7 = elementToMove7.transform.position + new Vector3(-0.4604f, 0, 0);

        prefabspawned = true;

        // if(N==99)
        {
            StartCoroutine(Shift1());

            StartCoroutine(Shift2());

            StartCoroutine(Shift3());

            StartCoroutine(Shift4());

            StartCoroutine(Shift5());
            StartCoroutine(Shift6());
            StartCoroutine(Shift7());
        }


    }


    private void Update()
    {

        //if(PlaceObjectsOnPlane.m_NumberOfPlacedObjects==1&&(N<100))
        

        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            if (!isMoved && !isMoving)
            {
               
                    isMoving = true;
                    StartCoroutine(Shift1());
               
                    StartCoroutine(Shift2());
                
                    StartCoroutine(Shift3());
                
                    StartCoroutine(Shift4());
                
                StartCoroutine(Shift5());
                StartCoroutine(Shift6());
                StartCoroutine(Shift7());




                /*foreach (GameObject obj in objectsToChange)
                {
                    obj.SetActive(true);
                }*/
        /* }
         else if (isMoved && !isMoving)
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
             }
         }
     }
     */
        if (CurrentState==1)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }


        }
        if (CurrentState == 2)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }

                Parts[6].SetActive(true);
            Labels[6].SetActive(true);
                if (itisIncrement)
            { 
                StartCoroutine(Shift7Back());
                StartCoroutine(LabelVisibility(6));

            }
            else
            {
                    Parts[5].SetActive(true);
                    StartCoroutine(visibilityOnDecrement(5));
                
                StartCoroutine(Shift6());
                StartCoroutine(LabelVisibility(6));

            }
            

        }
        if (CurrentState == 3)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Labels[5].SetActive(true);
            Parts[5].SetActive(true);
            Parts[6].SetActive(true);
            if (itisIncrement)
            {
                StartCoroutine(Shift6Back());
                StartCoroutine(LabelVisibility(5));
            }
            else
            {
                    Parts[4].SetActive(true);
                    StartCoroutine(visibilityOnDecrement(4));
                StartCoroutine(LabelVisibility(5));
                StartCoroutine(Shift5());
            }

        }
        if (CurrentState == 4)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Labels[4].SetActive(true);
            Parts[5].SetActive(true);
            Parts[6].SetActive(true);
            Parts[4].SetActive(true);
            if (itisIncrement)
            {
                StartCoroutine(Shift5Back());
                StartCoroutine(LabelVisibility(4));
            }
            else
            {
                    Parts[3].SetActive(true);
                    StartCoroutine(visibilityOnDecrement(3));
                    StartCoroutine(Shift4());
                StartCoroutine(LabelVisibility(4));
            }

        }
        if (CurrentState == 5)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Labels[3].SetActive(true);
            Parts[5].SetActive(true);
            Parts[6].SetActive(true);
            Parts[4].SetActive(true);
            Parts[3].SetActive(true);
            if (itisIncrement)
            {
                StartCoroutine(Shift4Back());
                StartCoroutine(LabelVisibility(3));
            }
            else
            {
                    Parts[2].SetActive(true);
                    StartCoroutine(visibilityOnDecrement(2));
                    StartCoroutine(Shift3());
                StartCoroutine(LabelVisibility(3));
            }
        }
        if (CurrentState == 6)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Labels[2].SetActive(true);
            Parts[5].SetActive(true);
            Parts[6].SetActive(true);
            Parts[4].SetActive(true);
            Parts[3].SetActive(true);
            Parts[2].SetActive(true);
            if (itisIncrement)
            {
                StartCoroutine(Shift3Back());
                StartCoroutine(LabelVisibility(2));
            }
            else
            {
                    Parts[1].SetActive(true);
                    StartCoroutine(visibilityOnDecrement(1));
                    StartCoroutine(Shift2());
                StartCoroutine(LabelVisibility(2));
            }

        }
        if (CurrentState == 7)
        {

            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Labels[1].SetActive(true);
            Parts[5].SetActive(true);
            Parts[6].SetActive(true);
            Parts[4].SetActive(true);
            Parts[3].SetActive(true);
            Parts[2].SetActive(true);
            Parts[1].SetActive(true);
            if (itisIncrement)
            {
                StartCoroutine(Shift2Back());
                StartCoroutine(LabelVisibility(1));
            }
            else
            {
                StartCoroutine(Shift1());
                    Parts[0].SetActive(true);
                    StartCoroutine(visibilityOnDecrement(1));
                }

        }
        if (CurrentState == 8)
        {
            foreach (GameObject i in Parts)
            {
                i.SetActive(false);
            }
            Labels[0].SetActive(true);
            Parts[5].SetActive(true);
            Parts[6].SetActive(true);
            Parts[4].SetActive(true);
            Parts[3].SetActive(true);
            Parts[2].SetActive(true);
            Parts[1].SetActive(true);
            Parts[0].SetActive(true);
            if (itisIncrement)
            {
                StartCoroutine(Shift1Back());
                StartCoroutine(LabelVisibility(0));
            }
            ClickToComplete = true;
           
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

    private IEnumerator visibilityOnDecrement(int i)
    {
        yield return new WaitForSeconds(1f);
            Parts[i].SetActive(false);
    }
    private IEnumerator LabelVisibility(int i)
    {
        yield return new WaitForSeconds(0.4f);
        Labels[i].SetActive(false);
    }


    private IEnumerator Shift1()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

        

        // start moving the element
        StartCoroutine(MoveElement(elementToMove1.transform, targetPosition1, 0.5f));



    }
    private IEnumerator Shift2()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);
        
        // start moving the element
        StartCoroutine(MoveElement(elementToMove2.transform, targetPosition2, 0.5f));

    }
    private IEnumerator Shift3()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);
       
        // start moving the element
        StartCoroutine(MoveElement(elementToMove3.transform, targetPosition3, 0.5f));

    }
    private IEnumerator Shift4()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

       
        // start moving the element
        StartCoroutine(MoveElement(elementToMove4.transform, targetPosition4, 0.5f));




    }
    private IEnumerator Shift5()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);


       
        // start moving the element
        StartCoroutine(MoveElement(elementToMove5.transform, targetPosition5, 0.5f));

    }
    private IEnumerator Shift6()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);


        
        // start moving the element
        StartCoroutine(MoveElement(elementToMove6.transform, targetPosition6, 0.5f));


    }
    private IEnumerator Shift7()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);


   
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
        yield return new WaitForSeconds(0.01f);



        // start moving the element
        StartCoroutine(MoveElement(elementToMove1.transform, initialPosition1, 0.5f));
        StartCoroutine(IsMovingR());


    }
    private IEnumerator Shift2Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

        // start moving the element
        StartCoroutine(MoveElement(elementToMove2.transform, initialPosition2, 0.5f));


    }
    private IEnumerator Shift3Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(MoveElement(elementToMove3.transform, initialPosition3, 0.5f));


    }
    private IEnumerator Shift4Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(MoveElement(elementToMove4.transform, initialPosition4, 0.5f));

    }
    private IEnumerator Shift5Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(MoveElement(elementToMove5.transform, initialPosition5, 0.5f));

    }
    private IEnumerator Shift6Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(MoveElement(elementToMove6.transform, initialPosition6, 0.5f));

    }
    private IEnumerator Shift7Back()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(MoveElement(elementToMove7.transform, initialPosition7, 0.5f));

    }









}
