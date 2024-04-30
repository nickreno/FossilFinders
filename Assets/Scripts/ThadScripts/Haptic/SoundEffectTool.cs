using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundEffectTool : MonoBehaviour
{
    [SerializeField] List<AudioClip> breakSounds;
    AudioSource aud;
    public static SoundEffectTool Instance;
    public AudioClip rockDrop;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("uhhh multiple sound effect sctripts.");
            Destroy(this);
        }
        aud = GetComponent<AudioSource>();
    }

    public void PlayDestructionSound()
    {
        aud.PlayOneShot(breakSounds.ElementAt(Random.Range(0,breakSounds.Count)));
    }

    public void PlayRockDropSound()
    {
        aud.PlayOneShot(rockDrop);
    }
}
