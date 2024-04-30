using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIConstantFloat : MonoBehaviour
{

    public float amp;
    public float freq;
    Vector3 initpos;
    //public CompleteModel_FF MyBool;
    //public GameObject CurrentGameObj;
    //public GameObject NextGameObj;


    private void Start()
    {
        initpos = this.transform.position;


    }


    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(initpos.x, Mathf.Sin(Time.time * freq) * amp + initpos.y, initpos.z);

    }
}
