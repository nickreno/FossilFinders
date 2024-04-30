using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Guide_FossilPiece_FF : MonoBehaviour
{
    public GameObject Step1_UI;
    public GameObject Step2_UI;

    public GameObject Step3_UI;
    public GameObject Step4_UI;
    public GameObject Step5_UI;

    private bool doThisOnce = true;

    private void OnCollisionStay(Collision collision)
    {
        
        if (doThisOnce == true)
        {
            Step1_UI.SetActive(false);
            Step2_UI.SetActive(false);
            Step3_UI.SetActive(false);
            Step4_UI.SetActive(true);
            doThisOnce = false;
            StartCoroutine(StepFourHideFiveShow());
        }
    }

    IEnumerator StepFourHideFiveShow()
    {
        yield return new WaitForSeconds(7);
        Step4_UI.SetActive(false);
        Step5_UI.SetActive(true);
    }
}
