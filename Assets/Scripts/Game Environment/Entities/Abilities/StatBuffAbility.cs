using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBuffAbility : Ability
{
    private StatsHandler sHandler;
    private SO_StatBuffAbility sData;

    public StatBuffAbility(SO_StatBuffAbility sData, GameObject abilityHolder) : base(sData, abilityHolder)
    {
        this.sData = sData;
        this.sHandler = abilityHolder.GetComponent<StatsHandler>();
    }

    protected override void Activate()
    {
        Debug.Log("Activating stat buff ability");
        sHandler.BuffStat(sData.statType, sData.amount, sData.duration);
    }
}
