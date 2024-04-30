using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Markers_FF : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FacePlayer();


    }


    void FacePlayer()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        direction.y = player.transform.position.y;
        this.transform.rotation = Quaternion.LookRotation(direction);
    }
}
