using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttackBoss : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(_damageAmount);
        }
    }
}
