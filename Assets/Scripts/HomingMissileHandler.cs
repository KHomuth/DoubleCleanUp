using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileHandler : MonoBehaviour
{
    private bool isCoroutineRunning;

    // Update is called once per frame
    void Update()
    {
        HomingMissile missile = GameObject.FindGameObjectWithTag("LeftArm").GetComponent<HomingMissile>();

        if(missile != null) {
            missile.FindClosestPlayer();
        }
    }
}
