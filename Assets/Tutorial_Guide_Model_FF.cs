using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class Tutorial_Guide_Model_FF : MonoBehaviour
{
    public CompleteModel_FF MyBool;

    public GameObject Step7_UI;

    public GameObject Hint;
    FossilPiece[] childrenTutorial;
    

    void Update()
    {
        childrenTutorial = this.GetComponentsInChildren<FossilPiece>();

        if (childrenTutorial.Length == 1 )
        {
            Hint.SetActive(true);
        }

        if (MyBool.modelIsCompleted == true)
        {

            Step7_UI.SetActive(true);
            Hint.SetActive(false);
        }
    }
}
