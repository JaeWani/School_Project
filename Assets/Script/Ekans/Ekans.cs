using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ekans : MonoBehaviour
{
    GameObject _player;
    Vector3 _vec;

    Rigidbody2D _rb;
    SpriteRenderer _spr;
    Monster _monster;
    Animator _anim;
    void Start()
    {
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
        _monster = GetComponent<Monster>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _Tracking(_player);
        _Animation(_rb.velocity.x);
    }
    void _Tracking(GameObject target)
    {
        _vec = target.transform.position - transform.position;
        _vec = _vec.normalized;
        if(!_anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        _rb.velocity = _vec * 2;
    }
    void _Animation(float veloX)
    {
        if(veloX > 0)
            _spr.flipX = true;
        else 
            _spr.flipX = false;
    }
}
