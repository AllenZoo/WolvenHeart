using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DashAbilityAction : AbilityAction
{
    public float range;
    public float dir;
    public DashAbilityAction(float range, float dir)
    {
        actionType = AbilityActionType.DashAbility;
        this.range = range;
        this.dir = dir;
    }
}
