using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static float healthBar = 50f;
    private GameObject laser;


    // Start is called before the first frame update
    void Start()
    {
        laser = GameObject.FindGameObjectWithTag("Laser");
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar <= 50)
        {
            laser.SetActive(true);
        }
        else
        {
            laser.SetActive(false);
        }
    }
}
