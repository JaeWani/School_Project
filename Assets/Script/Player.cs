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
       if(Input.GetKey(KeyCode.W))
       {
       transform.position = transform.position + transform.up *Time.deltaTime * PlayerSpeed;
        _Anim.SetBool("IsUp",true);
        _Anim.SetBool("IsDown",false);
        _Anim.SetBool("IsLeft",false);
        _Spr.flipX = false;
       }
       else if(Input.GetKey(KeyCode.S))
       {
       transform.position = transform.position - transform.up *Time.deltaTime * PlayerSpeed;
        _Anim.SetBool("IsUp",false);
        _Anim.SetBool("IsDown",true);
        _Anim.SetBool("IsLeft",false);
        _Spr.flipX = false;
       }
       else if(Input.GetKey(KeyCode.A))
       {
       transform.position = transform.position - transform.right *Time.deltaTime * PlayerSpeed;
        _Anim.SetBool("IsUp",false);
        _Anim.SetBool("IsDown",false);
        _Anim.SetBool("IsLeft",true);
        _Spr.flipX = false;
       }
       else if(Input.GetKey(KeyCode.D))
       {
       transform.position = transform.position + transform.right *Time.deltaTime * PlayerSpeed;
       _Anim.SetBool("IsUp",false);
        _Anim.SetBool("IsDown",false);
        _Anim.SetBool("IsLeft",true);
        _Spr.flipX = true;
       }
       else 
       {
        _Anim.SetBool("IsUp",false);
        _Anim.SetBool("IsDown",false);
        _Anim.SetBool("IsLeft",false);
        _Spr.flipX = false;
       }

    }
}
