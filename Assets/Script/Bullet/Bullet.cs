using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Mob"))
        {
            gameObject.SetActive(false);
        }
    }  
      void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
