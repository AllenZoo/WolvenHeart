using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Object that contains the stats of an entity
 */


[CreateAssetMenu(fileName = "new stats", menuName = "SO/Stats/stat")]

public class Stats : ScriptableObject
{
    [SerializeField] protected List<StatInfo> stats;

    public enum Stat
    {
        maxHealth,
        maxStamina,
        curHealth,
        curStamina,
        strength,
        agility,
        defence,
        vitality,
        endurance,
        aVitality,
        aEndurance,
        lifesteal,
        luck,
        precision,
        cooldownReduc,
        armourPen,
    }

    public float GetStatValue(Stats.Stat statType)
    {
        foreach (StatInfo s in stats)
        {
            if (s.statType == statType)
            {
                return s.value;
            } 
        }

        Debug.LogError("Stat not found on object : "  + statType.ToString());
        throw new CannotFindSpecifiedStatInEntity();
    }

    public void AddToStatValue(Stats.Stat statType, float value)
    {
        foreach (StatInfo s in stats)
        {
            if (s.statType == statType)
            {
                s.value += value;
                return;
            }
        }
    }

    public void SubtractToStatValue(Stats.Stat statType, float value)
    {
        foreach (StatInfo s in stats)
        {
            if (s.statType == statType)
            {
                s.value -= value;
                return;
            }
        }
        AddToStatValue(statType, -value);
    }

    public void MultiplyToStatValue(Stats.Stat statType, float value)
    {
        foreach (StatInfo s in stats)
        {
            if (s.statType == statType)
            {
                s.value *= value;
                return;
            }
        }
    }

    public void SetStatValue(Stats.Stat statType, float value)
    {
        foreach (StatInfo s in stats)
        {
            if (s.statType == statType)
            {
                s.value = value;
                return;
            }
        }
    }

    public void Copy(Stats _stats)
    {
        List<StatInfo> tempStats  = new List<StatInfo>();

        foreach (StatInfo s in _stats.stats)
        {
            StatInfo tempSI = new StatInfo();
            tempSI.statType = s.statType;
            tempSI.value = s.value;
            tempStats.Add(tempSI);
        }

        this.stats = tempStats;
    }
}

[Serializable]
public class CannotFindSpecifiedStatInEntity : Exception
{
    public CannotFindSpecifiedStatInEntity() : base() { }
    public CannotFindSpecifiedStatInEntity(string message) : base(message) { }
    public CannotFindSpecifiedStatInEntity(string message, Exception inner) : base(message, inner) { }
}