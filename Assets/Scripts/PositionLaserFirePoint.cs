using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLaserFirePoint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Body").transform.position;
    }
}
