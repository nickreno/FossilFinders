using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Guide_Brush_FF : MonoBehaviour
{

    public GameObject Step5_UI;
    public GameObject Step6_UI;

    [SerializeField] GameObject brushRay;


    void Update()
    {
        if (brushRay.activeInHierarchy == true)
        {
            Step5_UI.SetActive(false);
            Step6_UI.SetActive(true);
        }
        else
        {
            Step6_UI.SetActive(false);
        }
    }
}
