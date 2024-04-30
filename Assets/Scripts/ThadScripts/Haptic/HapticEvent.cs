using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticEvent : MonoBehaviour
{
    public void CauseHaptic()
    {
        HapticFeedback.instance.RightControllerHapticEvent(1f, .1f);
    }
}
