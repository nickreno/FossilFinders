using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class FossilPieceLock : MonoBehaviour
{
    public GameObject RespectiveSocket;
    public GameObject LeftHand;

    public static bool fossilIsClean = false;
    GameObject fossilParent;

    private void Start()
    {
        fossilParent = GameObject.FindGameObjectWithTag("CompleteModel");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject == RespectiveSocket)
        {
            LeftHandSoundEffects.InstanceLeft.PlayFossilPlaced();
            HapticFeedback.instance.LefttControllerHapticEvent(.5f, .2f);

            transform.parent = other.transform;
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            transform.parent = fossilParent.transform;

            Destroy(other.gameObject.transform.parent.gameObject);  //deletes the highlight
        }

    }    
}



//"this" == piece to be anchored (script attached to fossil_piece)
//on trigger enter with its respective socket, change the TRANSFORM (position) of the 
//      fossil piece to the TRANSFORM (position) of the socket, "locking" it in place
//Remove the fossil piece as a child of the hand, and make it a child of another empty
//      game object called "finalized fossil".
