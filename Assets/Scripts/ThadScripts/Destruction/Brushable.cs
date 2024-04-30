using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brushable : MonoBehaviour
{
    Material mat;
    float dirtReveal = 0;
    public float brushEffortNeeded = 100f;
    public GameObject dirtParticles;
    bool brushable = true;

    public GameObject RespectiveSocket;
    public GameObject LeftHand;

    private bool fossilIsClean = false;
    GameObject fossilParent;

    public bool pickupable = true;

    public GameObject exclPoint;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        fossilParent = GameObject.FindGameObjectWithTag("CompleteModel");

    }
    private void OnCollisionStay(Collision collision)
    {
        if(brushable && collision.gameObject.tag == "Brush")
        {
            dirtReveal += Mathf.Clamp(Mathf.Abs(collision.relativeVelocity.magnitude) / brushEffortNeeded, 0, .05f);
            var part = Instantiate(dirtParticles, collision.GetContact(0).point, Quaternion.identity);
            part.transform.forward = collision.GetContact(0).normal * -1;
            mat.SetFloat("_Revealed", dirtReveal);
            if (dirtReveal > .8f)
            {
                brushable = false;
                StartCoroutine(FinishBrushing());
            }

            LeftHandSoundEffects.InstanceLeft.PlayBrushStroke();
            HapticFeedback.instance.LefttControllerHapticEvent(.1f, .1f);

        }
    }

    public bool IsFullyBrushed() { return brushable; }

    public IEnumerator FinishBrushing()
    {
        var dirt = dirtReveal;
        for(int i = 0; i < 30; i++)
        {
            dirtReveal = Mathf.Lerp(dirt, 1, i / 30f);
            mat.SetFloat("_Revealed", dirtReveal) ;
            yield return new WaitForEndOfFrame();
        }
        dirtReveal = 1;
        mat.SetFloat("_Revealed", dirtReveal);
        fossilIsClean = true;
    }



    private void Update()
    {
        if ( !pickupable)
        {
            return;
        }
        if (fossilIsClean == true)
        {
            //connect the fossil to the left hand controller as a PARENT
            GetComponent<Rigidbody>().isKinematic = true;
            fossilIsClean = false;
            exclPoint.SetActive(false);

            this.transform.parent.transform.parent = LeftHand.transform;

            this.transform.parent.transform.localRotation = Quaternion.Euler(40, 0, 0);

            //move the fossil to be in front of the player connected to the left hand
            Vector3 fossilOffset = new Vector3(0, 0.25f, 0.25f);
            this.transform.parent.transform.localPosition = fossilOffset;

            //** cannot set the rotation to a flat level view due to Quaternion issues **\\
        }
    }
}
