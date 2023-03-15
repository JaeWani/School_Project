using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmander : Singleton<Charmander>
{
    public GameObject _CharmanderBullet;

    private enum EvolutionState
    {
        Charmander,
        Charmeleon,
        Charizard
    }
    EvolutionState _CurrentState = EvolutionState.Charmander;
    EvolutionState CurrentState
    {
        get
        {
            return _CurrentState;
        }
        set
        {
            _CurrentState = value;        
            _Evolution();    
        }
    }
    void _Evolution()
    {
        switch(_CurrentState)
        {
            case EvolutionState.Charmander:
            GameManager.I.PlayerSpeed = 3;
            GameManager.I.playerDamage = 1;
            break;
            case EvolutionState.Charmeleon:
            GameManager.I.PlayerSpeed = 4;
            GameManager.I.playerDamage = 2;
            break;
            case EvolutionState.Charizard:
            GameManager.I.PlayerSpeed = 5;
            GameManager.I.playerDamage = 3;
            break;
        }
    }


    // 불꽃 세례 스킬
    [Header ("불꽃 세례")]
    [SerializeField] private int _AmberLevel = 0;
    public int AmberLevel
    {
            get
            {
                return _AmberLevel;
            }
            set
            {
                _AmberLevel = value;
                _SetSkill();
            }
    }
    void _SetSkill()
    {
        StopAllCoroutines();
        _Ember(_AmberLevel);
        _FireBlast(_FireBlastLevle);
        _FireSpin(_FireSpinLevel);
    }
    void _Ember(int level) 
    {
        StartCoroutine(_Attack());
        IEnumerator _Attack()
        {
            switch(_AmberLevel)
            {
                case 0:
                break;
                case 1:
                    if(AttackRange.I.nearestTarget != null)
                    ObjectPooler.SpawnFromPool("Bullet",transform.position,Quaternion.identity);
                break;
                case 2:
                break;

            }

            yield return new WaitForSeconds(0.4f);
            StartCoroutine(_Attack());
        }
    }

    //회오리 불꽃 스킬
    [SerializeField] private int _FireSpinLevel = 0;
    public int FireSpinLevel
    {
        get
        {
            return _FireSpinLevel;
        }
        set
        {
            _FireSpinLevel = value;
            Debug.Log(_FireSpinLevel);
            _SetSkill();
        }
    }

    [SerializeField] List<GameObject> SpinObj = new List<GameObject>();

    void _FireSpin(int level)
    {
        switch(level)
        {
            case 0:
            break;
            case 1:
            _1LV(2);
            break;

        }
        void _1LV(float Speed)
        {
            int ObjSize = SpinObj.Count;
            float circleR = 1.5f; // 반지름
            float deg = 0;  // 각도
            float objSpeed = Speed; // 회전 속도
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
                yield return new WaitForSeconds(0.01f);
                StartCoroutine(Loof());
            }
        }

    }

    [Header ("불대문자")]
    [SerializeField] private int _FireBlastLevle = 0;
    public int FireBlastLevle
    {
        get
        {
            return _FireBlastLevle;
        }
        set
        {
            _FireBlastLevle = value;
            _SetSkill();
        }
    }
    void _FireBlast(int level)
    {


    }
    void Update()
    {
        
    }
}
