using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public bool IsPierce = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Mob") && IsPierce == false)
        {
            gameObject.SetActive(false);
        }
        else if(other.CompareTag("Mob") && IsPierce == true)
        {
            Invoke("_Destroy", 10f);
        }
    }  
    void _Destroy()
    {
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
