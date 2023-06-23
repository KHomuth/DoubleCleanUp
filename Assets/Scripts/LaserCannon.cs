using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    private float healthBarBoss;
    private Transform target;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        healthBarBoss = BossHealth.healthBar;
    }

    private void Update()
    {
        if(healthBarBoss <= 50f)
        {
            ShootLaser();
            Debug.Log("low HP");
        }
    }

    void ShootLaser()
    {
        /*
         * if (Physics2D.Raycast(m_transform.transform.position, target.position))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, target.position);
            Draw2DRay(laserFirePoint.position, _hit.point);

            Debug.Log("A");
        }
        else
        {
        
         */
            Draw2DRay(laserFirePoint.position, target.position * defDistanceRay);
            Debug.Log("B");
        //}
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
