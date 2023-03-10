using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    AttackRange _range = GameObject.Find("AttackRange").GetComponent<AttackRange>();
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackRange"))
        {
            _range.InRangeMob.Add(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackRange"))
        {
            int index = _range.InRangeMob.FindIndex(gameObject);
        }
    }
    void Update()
    {
        
    }
}
