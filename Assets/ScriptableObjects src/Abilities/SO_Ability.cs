using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public abstract class SO_Ability : ScriptableObject
{
    public Animation animation;
    public new string name;
    public float cost;
    public float cooldown;
    public float activeTime;
    public float castTime;

    public bool isOnCooldown;
    public bool requiresTarget;
    public bool isInstantCast;

    public abstract Ability GenerateAbilityRef(GameObject abilityHolder);

    private void OnValidate()
    {
        isOnCooldown = false;
    }
}
