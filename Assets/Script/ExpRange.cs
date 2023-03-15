using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpRange : MonoBehaviour
{
    EXP exp;
    GameObject _player;

    bool IsTracking = false;
    void Start()
    {
        exp = GetComponentInParent<EXP>();
        _player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            IsTracking = true;
        }
    }
    private void Update()
    {
        if(IsTracking == true)
            exp.PlayerTracking(_player, exp.gameObject);
    }
}
