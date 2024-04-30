using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandSoundEffects : MonoBehaviour
{
    AudioSource audLeft;
    public static LeftHandSoundEffects InstanceLeft;

    public AudioClip brushStroke;
    public AudioClip fossilPlaced;
    public AudioClip sciFiBeam;
    float cooldown = .05f;
    float timer = 0;

    private void Start()
    {
        if (InstanceLeft == null)
        {
            InstanceLeft = this;
        }
        else
        {
            Debug.Log("uhhh multiple LEFT HAND sound effect sctripts.");
            Destroy(this);
        }
        audLeft = GetComponent<AudioSource>();
    }

    public void PlayBrushStroke()
    {
        cooldown = Random.Range(0, 0.3f);       //originally 0.01f, 0.08f
        if (timer >= cooldown)
        {
            timer = 0;
            return;
        } else
        {
        }
        timer = 0;
        audLeft.PlayOneShot(brushStroke);
        audLeft.loop = false;

    }

    public void PlayFossilPlaced()
    {
        audLeft.PlayOneShot(fossilPlaced);
                    audLeft.loop = false;

    }

    public void PlaySciFiBeam()
    {
        audLeft.PlayOneShot(sciFiBeam);
        audLeft.loop = true;
    }


    private void Update()
    {
        timer += Time.deltaTime;
    }

}


//to call a function from here in another script:
// LeftHandSoundEffects.InstanceLeft.Function();
