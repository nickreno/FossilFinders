using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionSound : MonoBehaviour
{
    public void PlayDestructionSound()
    {
        SoundEffectTool.Instance.PlayDestructionSound();
    }
}
