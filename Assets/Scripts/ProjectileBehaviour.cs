using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    public float speed = 8f;

    private void Update(){
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "LeftArm")
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "RightArm")
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }
}
