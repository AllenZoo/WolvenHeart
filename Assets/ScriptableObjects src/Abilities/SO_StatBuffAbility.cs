using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatBuffAbility", menuName = "Abilities/StatBuffAbility")]
public class SO_StatBuffAbility : SO_Ability
{
    public Stats.Stat statType;
    public float amount;

    public bool isDurationBased;
    public float duration;

    public override Ability GenerateAbilityRef(GameObject abilityHolder)
    {
        return new StatBuffAbility(this, abilityHolder);
    }
}
