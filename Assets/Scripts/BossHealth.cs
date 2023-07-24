using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static float healthBar = 50f;
    private bool isDamaged = false;
    //private GameObject laser;


    // Start is called before the first frame update
    void Start()
    {
        //laser = GameObject.FindGameObjectWithTag("Laser");
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar == 100f)
        {
            //Debug.Log("full hp, Phase 1");
        }
        else if (healthBar <= 75f && healthBar > 50f)
        {
            //Debug.Log("Phase 2");
        }
        else if (healthBar <= 50f && healthBar > 25f)
        {
            //Debug.Log("Phase 3");
        }
        else if (healthBar <= 25f && healthBar > 0f)
        {
            //Debug.Log("Phase 4");
        }
        else if (healthBar == 0)
        {
            //Debug.Log("Me deaderinoes");
        }

    }
    public void BossHit()
    {
        isDamaged = true;
        //insert Boss get damaged animation (probably boss blinking red)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == GameObject.FindGameObjectWithTag("SpeedyAttack"))
        {
            healthBar -= 10f;
            Debug.Log(healthBar);
        }
        else if (collision.collider == GameObject.FindGameObjectWithTag("BeefyAttack"))
        {
            healthBar -= 15f;
        }
    }
}
