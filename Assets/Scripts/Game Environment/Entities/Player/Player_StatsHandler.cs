using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StatsHandler : StatsHandler
{
    protected const double STAT_SCALE  = 0.01;
    


    /* --------------------------------- STATES -------------------------------- */
    protected bool canRegenHP = true;
    protected bool canRegenSP = true;


    /* ---------------------------------- INIT ----------------------------- */

    private void Start()
    {
        //pStats.curHP = pStats.maxHP;
        //pStats.curSP = pStats.maxSP;
        // StartCoroutine(HandleSPRegen());
    }

    /* -------------------------------- MODIFIERS ------------------------------- */

    // USE FOR REFERENCE TO IMPLEMENT IN STAT HANDLER
    //public void BuffStat(Stats.Stat stat, float amount, float duration)
    //{
    //    Debug.Log("Buffing StatType: " + stat + " by " + amount + " for " + duration + " seconds");
    //    StartCoroutine(BuffStatCoroutine(stat, amount, duration));
    //}

    //private IEnumerator BuffStatCoroutine(Stats.Stat stat, float amount, float duration)
    //{
    //    curStats.AddToStatValue(stat, amount);
    //    yield return new WaitForSeconds(duration);
    //    curStats.SubtractToStatValue(stat, amount);
    //}

    public void SpendStamina(float value)
    {
        curStats.SubtractToStatValue(Stats.Stat.curHealth, value);
        StopAllCoroutines();
        StartCoroutine(HandleSPRegen());
    }

    /* --------------------------------- GETTERS -------------------------------- */
    public float GetMovementSpeed()
    {
        // TODO: implement speed calculator
        try
        {
            float ms = curStats.GetStatValue(Stats.Stat.agility) * 5;
            return ms;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Stat not found on object");
            return -1;
        }
    }


    /* --------------------------------- REGEN -------------------------------- */

    // HP [Health Points]
    private IEnumerator RegenHP()
    {
        yield return new WaitForSeconds(1);
        RecoverHP(GetHPRegenValue());
    }
    private float GetHPRegenValue()
    {
        return curStats.GetStatValue(Stats.Stat.vitality) * 5;
    }
    private void RecoverHP(float value)
    {
        
        curStats.AddToStatValue(Stats.Stat.curHealth, value);

        float curHP = curStats.GetStatValue(Stats.Stat.curHealth);
        float maxHP = curStats.GetStatValue(Stats.Stat.maxHealth);

        if (curHP > maxHP)
        {
            curStats.SetStatValue(Stats.Stat.curHealth, maxHP);
        }
    }


    // SP [Stamina Points]
    private IEnumerator RegenSP()
    {
        yield return new WaitForSeconds(1);
        RecoverSP(GetSPRegenValue());
    }
    private float GetSPRegenValue()
    { 
        return curStats.GetStatValue(Stats.Stat.endurance) * 5;
    }
    private void RecoverSP(float value)
    {
        curStats.AddToStatValue(Stats.Stat.curStamina, value);

        float curSP = curStats.GetStatValue(Stats.Stat.curStamina);
        float maxSP = curStats.GetStatValue(Stats.Stat.maxStamina);

        if (curSP > maxSP)
        {
            curStats.SetStatValue(Stats.Stat.curStamina, maxSP);
        }
    }
    private IEnumerator HandleSPRegen()
    {
        float curSP = curStats.GetStatValue(Stats.Stat.curStamina);
        float maxSP = curStats.GetStatValue(Stats.Stat.maxStamina);

        while (curSP < maxSP)
        {
            yield return StartCoroutine(RegenSP());
        }
        yield return new WaitForSeconds(1);
    }

}
