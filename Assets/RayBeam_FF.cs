using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBeam_FF : MonoBehaviour
{

    LineRenderer lr;
    public GameObject gravityGun;
    bool playOnce = true;
    public Transform point;
    Transform newpoint;
    GameObject shadersphere;
    
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
    }

    void Update()
    {

        Collider go = this.GetComponentInChildren<Collider>();

        if (go != null)
        {
            //ray is turned on
            //lr.enabled = true;
           // lr.positionCount = 2;
            //lr.SetPosition(0, point.position);
            //lr.SetPosition(1, go.transform.position);

            if (playOnce == true)
            {
                gravityGun.SetActive(true);
                LeftHandSoundEffects.InstanceLeft.PlaySciFiBeam();
                playOnce = false;
                shadersphere= go.GetComponentInChildren<FossilPiece>().shaderSphere;
                shadersphere.SetActive(true);
                newpoint = go.GetComponentInChildren<FossilPiece>().rayPoint.transform;

            }
            point.transform.position = newpoint.position;



        }
        else
        {
            //ray is turned off
            lr.enabled = false;
            playOnce = true;
            gravityGun.SetActive(false);
            if(shadersphere != null)
            {
                shadersphere.SetActive(false);

            }


        }



    }
}
