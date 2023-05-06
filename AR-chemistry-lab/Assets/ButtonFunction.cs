using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Increment()
    {
        if (TrainingSceneScript.CurrentState <= TrainingSceneScript.Max)
        {
            TrainingSceneScript.CurrentState += 1;
            TrainingSceneScript.itisIncrement = true;
        }

    }
    public void Decrement()
    {
        if (TrainingSceneScript.CurrentState > 1)
        {
            TrainingSceneScript.CurrentState -= 1;
            TrainingSceneScript.itisIncrement = false;
        }

    }
    
}
