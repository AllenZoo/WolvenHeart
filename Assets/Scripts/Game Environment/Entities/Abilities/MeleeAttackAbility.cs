using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAbility : DamageAbility
{
   
    private SO_MeleeAttackAbility mData;

    public MeleeAttackAbility(SO_MeleeAttackAbility mData, GameObject abilityHolder) : base(mData, abilityHolder)
    {
        this.mData = mData;
    }

    protected override void Activate()
    {
        throw new System.NotImplementedException();
    }
}
