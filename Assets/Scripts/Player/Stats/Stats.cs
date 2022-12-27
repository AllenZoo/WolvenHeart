using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new stats", menuName = "SO/Stats/stat")]

public class Stats : ScriptableObject
{
    [SerializeField] public List<StatInfo> stats;

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

        Debug.LogError("Stat not found on object");
        return -1;
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

    public void MultipleToStatValue(Stats.Stat statType, float value)
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
