using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    Rigidbody2D _Rb;
    Animator _Anim;
    SpriteRenderer _Spr;

    [Range (0,10)] public float PlayerSpeed;
    void Start()
    {
        _Rb = GetComponent<Rigidbody2D>();
        _Anim = GetComponent<Animator>();
        _Spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _Move();
    }
    void _Move()
    {
        float veloX = Input.GetAxis("Horizontal");
        float veloY = Input.GetAxis("Vertical");

        _Rb.velocity = new Vector2(veloX * PlayerSpeed,veloY * PlayerSpeed);
        _Animation(veloX);
    }
    void _Animation(float veloX) 
    {
        if (veloX > 0)
        {
            _Anim.SetBool("IsLeft", true);
            _Spr.flipX = true;
        }
        else if (veloX < 0)
        {
            _Anim.SetBool("IsLeft", true);
            _Spr.flipX = false;
        }
        else
            _Anim.SetBool("IsLeft", false);
    }   
}
