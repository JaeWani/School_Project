using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : Singleton<ExpManager>
{   
    [SerializeField] Slider ExpBar;

    [SerializeField] Button Skill1;
    [SerializeField] Button Skill2;
    [SerializeField] Button Skill3;
    private float _Exp = 0;
    public float Exp
    {
        get
        {
        return _Exp;
        }
        set
        {
            _Exp = value;
            LevelUp();
            _SetExpBar();
            Debug.Log(_Exp);
        }
    }
    public int PlayerLevel = 1;
    public List<int> NeedExp = new List<int>();
                                //0, 1 ,  2   ,  3 ,   4    ,  5 ,   6,   7   , 8   ,  9 , 10
     void LevelUp()
    {
        if(_Exp >= NeedExp[PlayerLevel])
        {
        Time.timeScale = 0;
        }
    }
    void Start()
    {
        Skill1.onClick.AddListener(() => _SelectSkill(1));
        Skill2.onClick.AddListener(() => _SelectSkill(2));
        Skill3.onClick.AddListener(() => _SelectSkill(3));
    }
    private void Update()
     {
        if(Input.GetKeyDown(KeyCode.F1))
            Exp += 10;
    }
    void _SetExpBar()
    {
        float value = Exp / NeedExp[PlayerLevel];
        ExpBar.value = value;
        Debug.Log(ExpBar.value);
    }
    void _SelectSkill(int num)
    {


    }
    
}
