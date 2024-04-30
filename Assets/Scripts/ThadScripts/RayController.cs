using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField] LineRenderer[] lr;
    [SerializeField] Transform[] trans;
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        lr.ToList().ForEach(x => { x.SetPosition(0,point1.position);
            x.SetPosition(2, point2.position);
        });
        lr[0].SetPosition(1, trans[0].position);
        lr[1].SetPosition(1, trans[1].position);
        lr[2].SetPosition(1, trans[2].position);
        lr[3].SetPosition(1, trans[3].position);

    }
}
