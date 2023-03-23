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
    public List<float> AttackDelay = new List<float>();
    public List<float> BulletSpeed = new List<float>();

    public List<bool> IsPierce = new List<bool>();
    public int EmberLevel
    {
        get{return _EmberLevel;}
        set{_EmberLevel = value;_SetSkill();}
    }
    void _SetSkill()
    {
        Charmander_Skill.StopAllSkill();
        _Ember(EmberLevel);
        _Flamethrower(FlamethrowerLevel);
    }
    void _Ember(int level) 
    {
        if(level > 5)
            level = 5;
        Charmander_Skill.Ember(IsPierce[level],AttackDelay[level],BulletSpeed[level]);
    }

    //회오리 불꽃 스킬
    [SerializeField] private int _FireSpinLevel = 0;
    public int FireSpinLevel
    {
        get{return _FireSpinLevel;}
        set{_FireSpinLevel = value;_SetSkill();}
    }


    public List<float> SpinSpeed = new List<float>();
    public List<int> ObjCount = new List<int>();

    public List<GameObject> SpinObj = new List<GameObject>(); 

    void _FireSpin(int level)
    {
        if(level > 5)
            level = 5;
        Charmander_Skill.FireSpin(SpinSpeed[level],ObjCount[level],SpinObj);
    }

    [Header ("화염방사")]
    [SerializeField] private int _FlamethrowerLevel = 0;

    public List<float> Attackdelay = new List<float>();
    public List<int> AttackCount = new List<int>();
    public int FlamethrowerLevel
    {
        get{return _FlamethrowerLevel;}
        set{_FlamethrowerLevel = value;_SetSkill();}
    }
    void _Flamethrower(int level)
    {
        if(level > 5)
            level = 5;
        Charmander_Skill.Flamethrower(AttackCount[level],Attackdelay[level]);
    }
    void Update()
    {
        
    }
}
