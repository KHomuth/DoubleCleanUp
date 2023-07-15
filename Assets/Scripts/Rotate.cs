using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _anglesPerSecond = 45;
    private float bosshealth;
    public Transform initTarget;

    private void Start()
    {
        bosshealth = BossHealth.healthBar;
    }

    // ------------------------------------------------------
    void Update()
    {
        if(bosshealth <= 50f)
        {
            Vector3 rotation = transform.localEulerAngles;
            rotation.z += Time.deltaTime * _anglesPerSecond;
            transform.localEulerAngles = rotation;
        }
    }
}
