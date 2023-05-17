using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsHandler : MonoBehaviour
{
    public abstract Stats GetStats();
    public abstract void BuffStat(Stats.Stat stat, float amount, float duration);
}
