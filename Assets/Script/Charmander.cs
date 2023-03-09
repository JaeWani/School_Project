using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charmander : Singleton<Charmander>
{
    public GameObject AttackRange;

    enum Direction
    {
        left,
        right,
        up,
        down
    }
    Direction CurrentDir = Direction.down;

    void _SetDir()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
    }
    void Update()
    {
        
    }
}
