using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Guide_Pickaxe_FF : MonoBehaviour
{

    public GameObject Step1_UI;
    public GameObject Step2_UI;
    public GameObject Step3_UI;

    void Start()
    {
        StartCoroutine(StepOneHideTwoView());
        
    }

    IEnumerator StepOneHideTwoView()
    {

        yield return new WaitForSeconds(7);
        Step1_UI.SetActive(false);
        Step2_UI.SetActive(true);
        StartCoroutine(StepTwoHideThreeView());
    }

    IEnumerator StepTwoHideThreeView()
    {
        yield return new WaitForSeconds(5);
        Step2_UI.SetActive(false);
        Step3_UI.SetActive(true);
        
    }

}
