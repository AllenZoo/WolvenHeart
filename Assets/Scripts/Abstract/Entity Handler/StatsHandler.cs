using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsHandler : MonoBehaviour
{
    [SerializeField] protected Stats curStats;
    [SerializeField] protected Stats defaultStats;
    public Action OnStatChange;

    private void Awake()
    {
        curStats.Copy(defaultStats);
    }

    public Stats GetStats() {
        return curStats;
    }

    public void BuffStat(Stats.Stat stat, float amount, float duration)
    {
        throw new NotImplementedException();
    }
    public  void DeBuffStat(Stats.Stat stat, float amount, float duration)
    {
        throw new NotImplementedException();
    }
    public void DecreaseStat(Stats.Stat stat, float amount)
    {
        curStats.SubtractToStatValue(stat, amount);
        OnStatChange?.Invoke();
    }
    public void IncreaseStat(Stats.Stat stat, float amount)
    {
        curStats.AddToStatValue(stat, amount);
        OnStatChange?.Invoke();
    }
}
