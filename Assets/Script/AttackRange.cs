using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : Singleton<AttackRange>
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] target;
    public Transform nearestTarget;
    private void FixedUpdate() 
    {
        target = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = _GetNearst();
    }
    Transform _GetNearst()
    {
        Transform result = null;
        float diff = 100;
        foreach(RaycastHit2D target in target)
        {
            Vector3 mypos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(mypos,targetPos);
            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
