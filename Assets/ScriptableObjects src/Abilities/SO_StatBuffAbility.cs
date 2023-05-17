using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_StatBuffAbility : SO_Ability
{
    public Stats.Stat statType;
    public float amount;

    public override Ability GenerateAbilityRef(GameObject abilityHolder)
    {
        throw new System.NotImplementedException();
    }
}
