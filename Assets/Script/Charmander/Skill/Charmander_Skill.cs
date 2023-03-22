using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmander_Skill : Singleton<Charmander_Skill>
{
    ///<summary>
    /// 모든 스킬의 반복을 멈춥니다.
    /// 스킬의 수치를 재설정하고 싶을때 호출합니다.
    ///</summary>
    public void StopAllSkill()
    {
        StopAllCoroutines();
    }
    ///<summary>
    /// 불꽃세례 스킬 함수입니다. 
    /// 매개변수로 관통 여부, 공격속도, 총알 속도를 요구합니다.
    ///</summary>
    public static void Ember(bool isPierce, float AttackDelay, float Speed)
    {
        I._EmberLoof(isPierce,AttackDelay,Speed);
    }
    private void _EmberLoof(bool isPierce, float AttackDelay, float Speed)
    {
        WaitForSeconds Delay = new WaitForSeconds(AttackDelay);
        StartCoroutine(Loof());
        IEnumerator Loof()
        {
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet", transform.position);
            TraceBullet curBullet = bullet.GetComponent<TraceBullet>();
            Bullet _curBullet = bullet.GetComponent<Bullet>();
            _curBullet.IsPierce = isPierce;
            curBullet.bulletSpeed = Speed;
            yield return Delay;
            StartCoroutine(Loof());
        }
    }

    ///<summary>
    /// 회오리불꽃 스킬 함수입니다. 
    /// 매개변수로 회전속도와 회전체 개수를 요구합니다.
    ///</summary>
    public static void FireSpin(float SpinSpeed, int ObjCount, List<GameObject> SpinObj)
    {
        I._FireSpinLoof(SpinSpeed,ObjCount,SpinObj);
    }
    private void _FireSpinLoof(float SpinSpeed, int ObjCount,List<GameObject> SpinObj)
    {
        int ObjSize = ObjCount;
        float circleR = 1.5f; // 반지름
        float deg = 0;  // 각도
        float objSpeed = SpinSpeed;

        WaitForSeconds wait = new WaitForSeconds(0.01f);

        StartCoroutine(Loof());
        IEnumerator Loof()
        {
                deg += 1f * objSpeed;
                if(deg < 360)
                {
                    for(int i = 0; i < ObjSize; i++)
                    {
                        var rad = Mathf.Deg2Rad * (deg + (i*(360/ObjSize)));
                        var x = circleR * Mathf.Sin(rad);
                        var y = circleR * Mathf.Cos(rad);
                        SpinObj[i].transform.position = transform.position + new Vector3(x,y); 
                        SpinObj[i].transform.rotation = Quaternion.Euler(0,0,(deg + (i *(360 / ObjSize))) * -1);
                    }
                }
                else
                    deg = 0;
            yield return wait;
            StartCoroutine(Loof());
        }
    }
    ///<summary>
    /// 화염방사 스킬 함수입니다. 
    /// 매개변수로 공격 횟수와 쿨타임을 요구합니다.
    ///</summary>
    public static void Flamethrower(int AttackCount, float AttackDelay)
    {
       I._FlamethrowerLoof(AttackCount, AttackDelay);
    }
    private void _FlamethrowerLoof(int AttackCount, float AttackDelay)
    {
        WaitForSeconds Delay = new WaitForSeconds(AttackDelay);
        StartCoroutine(Loof());
        IEnumerator Loof()
        {
            for(int i = 0; i < AttackCount; i++)
            {
                var flame = ObjectPooler.SpawnFromPool("Flame", transform.position).GetComponent<Flame>();
                flame._Flame((Flame.dir)i);
            }
            yield return Delay;
            StartCoroutine(Loof());
        }
    }
}
