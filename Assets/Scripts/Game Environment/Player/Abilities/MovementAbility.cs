using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAbility : Ability
{
    private MovementHandler mHandler;
    private SO_MovementAbility mData;
    public MovementAbility(SO_MovementAbility mData, GameObject abilityHolder)
    {
        this.data = mData;
        this.mData = mData;
        mHandler = abilityHolder.GetComponent<MovementHandler>();
    }

    protected override void Activate()
    {
        Debug.Log("Activating movement ability");
        mHandler.Dash(mData.directionRotModifier, mData.speed);
    }

    
}


