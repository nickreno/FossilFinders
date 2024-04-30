using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{

    [SerializeField] Enemy mainEnemy;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "hands")
        {
            mainEnemy.DisableBodies();
        }
    }
}
