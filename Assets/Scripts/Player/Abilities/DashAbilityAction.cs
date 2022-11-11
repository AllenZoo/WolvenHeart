using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DashAbilityAction : AbilityAction
{
    public float range;
    public float dir;
    public float cost;
    public DashAbilityAction(float range, float dir)
    {
        actionType = AbilityActionType.DashAbility;
        this.range = range;
        this.dir = dir;
    }

    public DashAbilityAction(SO_DashDamageAbility soDDA)
    {
        actionType = AbilityActionType.DashAbility;
        soAbility = soDDA;
        this.range = soDDA.dashRange;
        this.dir = soDDA.dashDir;
        this.cost = soDDA.cost;
    }
}
