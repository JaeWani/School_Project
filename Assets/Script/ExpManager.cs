using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : Singleton<ExpManager>
{   
    [SerializeField] Slider ExpBar;

    [SerializeField] List<Button> button = new List<Button>();

    [SerializeField] Image SkillPanel;
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
        }
    }
    public int PlayerLevel = 1;
    public List<int> NeedExp = new List<int>();
    void LevelUp()
    {
        if(_Exp >= NeedExp[PlayerLevel])
        {
        SkillPanel.transform.localPosition = new Vector2(0,0);
        PlayerLevel++;
        Exp = 0;
        Time.timeScale = 0;
        }
    }
    void Start()
    {
        button[0].onClick.AddListener(() => _SelectSkill(1));
        button[1].onClick.AddListener(() => _SelectSkill(2));
        button[2].onClick.AddListener(() => _SelectSkill(3));
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
    }
    void _SelectSkill(int num)
    {
        int _num = num-1;
        switch(_num)
        {
            case 0:
            Charmander.I.EmberLevel++;
            break;
            case 1:
            Charmander.I.FireSpinLevel++;
            break;
            case 2:
            Charmander.I.FlamethrowerLevel++;
            break;
            default:
            break;
        }
        Time.timeScale = 1;
        SkillPanel.transform.localPosition = new Vector2(2000,0);
    }
    
}
