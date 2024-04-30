using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Rigidbody> rb;
    Animator anim;

    private void Start()
    {
        rb.ForEach(r =>
        {
            r.isKinematic = true;
        });
        anim = GetComponent<Animator>();
    }


    public void DisableBodies()
    {
        rb.ForEach(r =>
        {
            r.isKinematic = false;
        });
        anim.enabled = false;
    }
}
