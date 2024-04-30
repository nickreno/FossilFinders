using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIFloatingScript : MonoBehaviour
{

    public float amp;
    public float freq;
    Vector3 initpos;
    public CompleteModel_FF MyBool;
    public GameObject CurrentGameObj;
    public GameObject NextGameObj;
    public GameObject Fact1GameObj;
    public GameObject Fact2GameObj;


    private void Start()
    {
        initpos = transform.position;


    }


    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(initpos.x, Mathf.Sin(Time.time * freq) * amp + initpos.y, 0);
        

        if (MyBool.modelIsCompleted == true)
        {

            CurrentGameObj.SetActive(false);
            NextGameObj.SetActive(true);
            Fact1GameObj.SetActive(true);
            Fact2GameObj.SetActive(true);
        }
        

    }
}
