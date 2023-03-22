using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int playerDamage;
    public int PlayerSpeed = 4;
    public int PlayerHp = 100;
    public Player CurrentPlayer;

    public enum Playerble
    {
        Charmander, // 파이리
        Bulbasaur, // 이상해씨
        Squirtle // 꼬부기
    }
    public Playerble CurrentCharacter = Playerble.Charmander;
    [Range (0,10)] public float KnockBackPower;

    void SetBasicSkill()
    {
        switch(CurrentCharacter)
        {
            case Playerble.Charmander:
            Charmander.I.EmberLevel = 1;
                break;
            case Playerble.Bulbasaur:
                break;
            case Playerble.Squirtle:
                break;
        }
    }
    void Start()
    {
        CurrentPlayer = GameObject.Find("Player").GetComponent<Player>();
        SetBasicSkill();
    }
}
