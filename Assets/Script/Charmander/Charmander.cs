using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmander : Singleton<Charmander>
{
    public GameObject _CharmanderBullet;
    public GameObject _FireSpinObj;

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
    [SerializeField] private int _EmberLevel = 0;
    public int EmberLevel
    {
            get
            {
                return _EmberLevel;
            }
            set
            {
                _EmberLevel = value;
                _SetSkill();
            }
    }
    void _SetSkill()
    {
        StopAllCoroutines();
        _Ember(_EmberLevel);
        _Flamethrower(_FlamethrowerLevel);
        _FireSpin(_FireSpinLevel);
    }
    void _Ember(int level) 
    {
            switch(_EmberLevel)
            {
                case 0:
                break;
                case 1:StartCoroutine(_1LV()); break;
                case 2:
                break;

            }
        IEnumerator _1LV()
        {
            if(AttackRange.I.nearestTarget != null)
                    ObjectPooler.SpawnFromPool("Bullet",transform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(_1LV());
        }
        IEnumerator _2LV()
        {
            if(AttackRange.I.nearestTarget != null)
                ObjectPooler.SpawnFromPool("Bullet",transform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.3f);

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
            case 1:_1LV(2);break;
            case 2:_2LV(2.1f);break;

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
         void _2LV(float Speed)
        {
            GameObject obj = Instantiate(_FireSpinObj,transform);
            SpinObj.Add(obj);
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

    [Header ("화염방사")]
    [SerializeField] private int _FlamethrowerLevel = 0;
    public int FlamethrowerLevel
    {
        get
        {
            return _FlamethrowerLevel;
        }
        set
        {
            _FlamethrowerLevel = value;
            _SetSkill();
        }
    }
    void _Flamethrower(int level)
    {
        switch(level)
        {
            case 0:
            break;
            case 1: StartCoroutine(_1LV()); break;
            case 2: StartCoroutine(_2LV()); break;
        }
        IEnumerator _1LV()
        {
            for(int i = 0; i < 2; i++)
            {
            Flame flame = ObjectPooler.SpawnFromPool("Flame", transform.position).GetComponent<Flame>();
            flame._Flame((Flame.dir)i);
            }
            yield return new WaitForSeconds(2);
            StartCoroutine(_1LV());
        }
        IEnumerator _2LV()
        {
            for(int i = 0; i< 4; i++)
            {
                var flame = ObjectPooler.SpawnFromPool("Flame", transform.position).GetComponent<Flame>();
                flame._Flame((Flame.dir)i);
            }
            yield return new WaitForSeconds(2);
            StartCoroutine(_2LV());
        }
    }
    void Update()
    {
        
    }
}
