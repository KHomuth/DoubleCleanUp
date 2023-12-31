using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Vector2 dir;
    private float angle;
    public Transform initTarget;
    private float bossHP;
    public LayerMask layersToHit;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(initTarget.position);
        Debug.Log(transform.position);
        bossHP = BossHealth.healthBar;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHP <= 50f)
        {
            angle = transform.eulerAngles.z * Mathf.Deg2Rad;
            dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 50f, layersToHit);
            if (hit.collider == null)
            {
                transform.localScale = new Vector3(50f, transform.localScale.y, 1);
                return;
            }
            //transform.localScale = new Vector3(hit.distance, transform.localScale.y, 1);
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.tag == "Player")
            {
                //Debug.Log("Damage dealt");
                //Destroy(hit.collider.gameObject);
            }
        }
    }
}
