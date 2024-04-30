using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteModel_FF : MonoBehaviour
{
    public int piecesToBeAssembled;

    GameObject completeParent;
    FossilPiece[] children;

    //post-assembly to showcase to the player
    public bool modelIsCompleted = false;
    float rotateSpeed = 10f;
    Vector3 rotationDirection = new Vector3(0, 3, 0);


    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();    //can only do this in Start() or Update()
        completeParent = GameObject.FindGameObjectWithTag("CompleteModel");
        //reset global var piecesToBeAssembled to be amount of pieces in each level
        /*
        piecesToBeAssembled = 0;

        if (scene.name == "Tutorial_Level")
        {
            piecesToBeAssembled = 2;
        }
        else if (scene.name == "Level_One" || scene.name == "Level_Two")
        {
            piecesToBeAssembled = 3;
        }
        else
        {
            piecesToBeAssembled = 0;
        }
        */
    }

    void Update()
    {
        if (modelIsCompleted == false)
        {
            children = completeParent.GetComponentsInChildren<FossilPiece>();
        }
        

        //check if piecestobeassembled is max or if the parent has all the children in them
        
        if (((children.Length)) >= piecesToBeAssembled)
        {
            //move the model to the player's front and rotate it, and bring up the UI stuff
            //Debug.Log("All children accounted for.");
            piecesToBeAssembled = 0;    //reseting global value just incase (for other levels)
            modelIsCompleted = true;
        }

        if (modelIsCompleted == true)
        {
            completeParent.transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
        }
    }
}
