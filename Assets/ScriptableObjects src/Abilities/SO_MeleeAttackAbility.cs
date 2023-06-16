using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_MeleeAttackAbility : SO_DamageAbility
{

    public float radius;
    public float swingAngle;

    public override Ability GenerateAbilityRef(GameObject abilityHolder)
    {
        return new MeleeAttackAbility(this, abilityHolder);
    }
}
