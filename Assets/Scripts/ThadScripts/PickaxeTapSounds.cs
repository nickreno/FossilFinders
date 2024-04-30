using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeTapSounds : MonoBehaviour
{
    Rigidbody rb;
    AudioSource aud;

    [SerializeField] AudioClip[] softHitSounds;
    [SerializeField] AudioClip[] hardHitSounds;
    [SerializeField] GameObject sparks;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Fracture>() != null)
        {
            var force = (collision.impulse / Time.fixedDeltaTime).magnitude;
            if (force < 50 && force > 5)
            {
                aud.PlayOneShot(softHitSounds[Random.Range(0, softHitSounds.Length-1)]);
            }
            else if (force >=50)
            {
                aud.PlayOneShot(hardHitSounds[Random.Range(0, softHitSounds.Length-1)]);
                Instantiate(sparks, collision.GetContact(0).point, Quaternion.identity);

            }
        }
    }
}
