using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FossilPiece : MonoBehaviour
{
    public LayerMask mask;
    bool lockedIn = false;
    bool detatched = false;
    public GameObject shaderSphere, rayPoint;
    List<GameObject> attatchedBlocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("testMove", 1f);
    }

    public void LockIn()
    {
        lockedIn = true;
        GetComponent<BoxCollider>().isTrigger = false;
    }

    private void Update()
    {
        if(!detatched && attatchedBlocks.Where(x => x!=null).Count() <=0)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            //rb.isKinematic = false;
            detatched = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mask != (mask | (1 << other.gameObject.layer)))
            return;
        if (lockedIn)
            return;
        if (attatchedBlocks.Contains(other.gameObject))
            return;
        else
            attatchedBlocks.Add(other.gameObject);
        Invoke("LockIn", .5f);
    }
}
