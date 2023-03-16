using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Range (0,1000)] public int MonsterHP;

    Rigidbody2D rb;
    Animator _anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    public void Hit(int Damage)
    {
        MonsterHP -= Damage;
        _anim.SetTrigger("Hit");
        _KnockBack();
        Dead();
    }
    
    void Dead()
    {
        if(MonsterHP <= 0)
        {
            ObjectPooler.SpawnFromPool("Exp", transform.position);
            gameObject.SetActive(false);
        }
    }

    WaitForFixedUpdate wait;

    public bool IsKnockBack = false;
    void _KnockBack()
    {
        StartCoroutine(KnockBack());
        IEnumerator KnockBack()
        {
            yield return wait;
            
            Vector3 PlayerPos = Player.I.transform.position;
            Vector3 dirVec = transform.position - PlayerPos;
            IsKnockBack = true;
            rb.AddForce(dirVec.normalized * GameManager.I.KnockBackPower, ForceMode2D.Impulse);
        }
        IsKnockBack = false;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Wepon"))
        {
            WeponStat wepon = other.GetComponent<WeponStat>();
            Debug.Log(wepon);
            Hit(wepon.WeponDamage * GameManager.I.playerDamage);
        }
    }
    void OnDisable()
    {
        StopAllCoroutines();
        ObjectPooler.ReturnToPool(gameObject);
    }
}
