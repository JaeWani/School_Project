using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpRange : MonoBehaviour
{
    EXP exp;
    GameObject _player;
    void Start()
    {
        exp = GetComponentInParent<EXP>();
        _player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _Tracking();
        }
    }
    Vector2 _vec;

    void _Tracking(Vector2 target, Vector2 tracking)
    {
        _vec = target - tracking;

    }
}
