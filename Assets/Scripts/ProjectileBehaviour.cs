using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 8f;

    private void Update(){
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2d(Collision2D collision) {
        Destroy(gameObject);
    }
}
