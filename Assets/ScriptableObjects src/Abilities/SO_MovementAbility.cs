using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementAbility", menuName = "Abilities/MovementAbility")]
public class SO_MovementAbility : SO_Ability
{
    public float directionRotModifier;
    public float speed;

    public override Ability GenerateAbilityRef(GameObject abilityHolder)
    {
        return new MovementAbility(this, abilityHolder);
    }

}
