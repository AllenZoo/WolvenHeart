using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * The class that defines the cost of an ability.
 * 
 */
[System.Serializable]
public class AbilityCost
{
    [SerializeField] private List<StatCost> StatToCostMap = new List<StatCost>();
}

/*
 * 
 * The class that defines the cost of a stat.
 * 
 */

[System.Serializable]
public class StatCost
{
    public Stats.Stat statType;
    public float value;
}
