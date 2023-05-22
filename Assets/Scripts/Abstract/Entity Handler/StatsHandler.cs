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

    public float GetStatValue(Stats.Stat statType)
    {
        return curStats.GetStatValue(statType);
    }

    public void BuffStat(Stats.Stat stat, float amount, float duration)
    {
        StartCoroutine(BuffStatCoroutine(stat, amount, duration));
    }

    protected IEnumerator BuffStatCoroutine(Stats.Stat stat, float amount, float duration)
    {
        // Buff the stat for the duration
        IncreaseStat(stat, amount);
        yield return new WaitForSeconds(duration);
        DecreaseStat(stat, amount);

    }

    public  void DeBuffStat(Stats.Stat stat, float amount, float duration)
    {
        StartCoroutine(DeBuffStatCoroutine(stat, amount, duration));
    }

    protected IEnumerator DeBuffStatCoroutine(Stats.Stat stat, float amount, float duration)
    {
        // Debuff the stat for the duration
        DecreaseStat(stat, amount);
        yield return new WaitForSeconds(duration);
        IncreaseStat(stat, amount);
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
