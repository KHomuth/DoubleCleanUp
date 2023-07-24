using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _anglesPerSecond = 45;
    private float bosshealth;
    private float speed;
    private float delayTime;
    public GameObject player;

    private void Start()
    {
        
        speed = 50f;
        delayTime = 2f;
        bosshealth = BossHealth.healthBar;
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }

    // ------------------------------------------------------
    void Update()
    {

        //Debug.Log(delayTime);
        if (bosshealth <= 50f)
        {
            delayTime = delayTime - Time.deltaTime;

            if (delayTime < 0)
            {
                Vector3 rotation = transform.localEulerAngles;
                rotation.z += Time.deltaTime * _anglesPerSecond;
                transform.localEulerAngles = rotation;
            }
        }
    }
}
