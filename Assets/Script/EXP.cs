using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    [SerializeField] private int AddEXP = 10;
    [SerializeField] GameObject _player;
    Rigidbody2D _rb;
    void Start()
    {
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            ExpManager.I.Exp += AddEXP;
            gameObject.SetActive(false);
        }    
    }
    Vector2 _vec;
    public void PlayerTracking()
    {
        _vec = _player.transform.position - transform.position;
        _rb.velocity = _vec;
    }
    private void OnDisable() 
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}