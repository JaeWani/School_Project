using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 vec;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(AttackRange.I.nearestTarget != null)
        {
        vec = AttackRange.I.nearestTarget.position - transform.position;
        vec = vec.normalized;
        rb.velocity = vec * 5;
        }
    }
    private void OnEnable() 
    {
        if(AttackRange.I.nearestTarget != null)
        {
        rb = GetComponent<Rigidbody2D>();
        vec = AttackRange.I.nearestTarget.position - transform.position;
        vec = vec.normalized;
        rb.velocity = vec * 5;
        }
    }
}