using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageAbility : Ability
{
    protected SO_DamageAbility dData;

    public DamageAbility(SO_DamageAbility dData, GameObject abilityHolder) : base(dData, abilityHolder)
    {
        this.dData = dData; 
    }
}
