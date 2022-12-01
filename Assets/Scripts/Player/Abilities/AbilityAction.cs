using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAction
{
    public AbilityActionType actionType;
    public SO_Ability soAbility;
    public float cost;
}

public enum AbilityActionType
{
    DashAbility,
    BuffAbility,
}
