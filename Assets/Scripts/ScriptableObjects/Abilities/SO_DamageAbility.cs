using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SO_DamageAbility : SO_Ability
{
    public float damage;
    public List<IDamageMultiplier> damageMultipliers;

    
}

public interface IDamageMultiplier
{

}