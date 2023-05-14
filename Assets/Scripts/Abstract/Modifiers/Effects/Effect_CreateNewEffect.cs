using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect_CreateNewEffect : IEffect
{
    public void ApplyEffect()
    {
        Debug.Log("Applying new Effect");
    }
}
