using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    Rigidbody2D _Rb;
    Animator _Anim;
    SpriteRenderer _Spr;
    Monster _monster;


    public Vector2 inputVec;

    void Start()
    {
        _Rb = GetComponent<Rigidbody2D>();
        _Anim = GetComponent<Animator>();
        _Spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        _Animation(inputVec.x , inputVec.y);
    }
    private void FixedUpdate() 
    {
        _Move();
    }
    void _Move()
    {
        
        Vector2 nextVec = inputVec.normalized * GameManager.I.PlayerSpeed * Time.fixedDeltaTime;
        _Rb.MovePosition(_Rb.position + nextVec);

    }
    void _Animation(float veloX,float veloY) 
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
        {
            _Anim.SetBool("IsLeft", false);
            _Anim.SetBool("IsDown", false);
            _Anim.SetBool("IsUp", false);
        }

        if(veloY > 0 && veloX == 0)
        {
            _Anim.SetBool("IsUp", true);
             _Spr.flipX = false;
        }
        else if(veloY < 0 && veloX == 0)
        {
            _Anim.SetBool("IsDown", true);
            _Spr.flipX = false;
        }
        else 
        {
            _Anim.SetBool("IsDown", false);
            _Anim.SetBool("IsUp", false);
        }
    }   
}
