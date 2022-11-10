using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SO_Ability : ScriptableObject
{
    public Animation animation;
    public string abilityName;
    public float cost;
    public float cooldown;

    public abstract AbilityAction Trigger();
}
