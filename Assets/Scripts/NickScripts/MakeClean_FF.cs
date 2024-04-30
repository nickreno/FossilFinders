using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeClean_FF : MonoBehaviour
{
    public GameObject fossilToBeCleaned;

    public void MakeMeClean()
    {
        FossilPieceLock.fossilIsClean = true;

    }
}
