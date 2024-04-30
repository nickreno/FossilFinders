using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAudio : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] float delay = -1;
    AudioSource aud;

    private void OnEnable()
    {
        aud = gameObject.GetComponent<AudioSource>();
        if (delay == -1)
            return;
        Invoke ("PlayHelpSound", delay);
    }

    public void PlayHelpSound()
    {
        aud.PlayOneShot(clip);
    }

    public void PlayHelpSoundWithDelay(float _delay)
    {
        Invoke("PlayHelpSound", _delay);

    }
}


