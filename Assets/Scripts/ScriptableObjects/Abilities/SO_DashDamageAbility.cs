using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new dash damage ability", menuName = "SO/Abilities/Damage/Dash Ability")]
public class SO_DashDamageAbility : SO_DamageAbility
{
    public float dashRange;

    // 1 = front
    // -1 = backwards
    public float dashDir;

    public override AbilityAction Trigger()
    {
        DashAbilityAction dashAbility = new DashAbilityAction(dashRange, dashDir);
        return dashAbility;
    }
}
