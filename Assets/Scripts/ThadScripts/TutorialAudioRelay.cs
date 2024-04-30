using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAudioRelay : MonoBehaviour
{
    public TutorialAudio relay;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        relay.PlayHelpSoundWithDelay(delay);
    }

}
