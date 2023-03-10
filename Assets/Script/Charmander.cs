using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmander : Singleton<Charmander>
{
    public GameObject _CharmanderBullet;

    private void Start()
    {
        _TrackingAttack(_CharmanderBullet);
    }
    void _TrackingAttack(GameObject bullet) 
    {
        StartCoroutine(_Attack());
        IEnumerator _Attack()
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
    void Update()
    {
        
    }
}
