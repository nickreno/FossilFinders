using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartDelay_FF : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DontLetPickBreakTooEarly());
    }

    IEnumerator DontLetPickBreakTooEarly()
    {
        yield return new WaitForSeconds(3);
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = true;
        }
    }
}
