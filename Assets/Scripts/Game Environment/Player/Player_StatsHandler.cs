using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StatsHandler : StatsHandler
{
    protected const double STAT_SCALE  = 0.01;
    [SerializeField] private Stats statsTemplate;
    [SerializeField] private Stats curStats;


    /* --------------------------------- STATES -------------------------------- */
    protected bool canRegenHP = true;
    protected bool canRegenSP = true;


    /* ---------------------------------- INIT ----------------------------- */
    private void Awake()
    {
        curStats.Copy(statsTemplate);
    }

    private void Start()
    {
        //pStats.curHP = pStats.maxHP;
        //pStats.curSP = pStats.maxSP;
        // StartCoroutine(HandleSPRegen());
    }

    /* -------------------------------- MODIFIERS ------------------------------- */
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
            //float ms = curStats.GetStatValue(Stats.Stat.agility) * 5;
            // TODO: fix, this is a temp fix
            return 10;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Stat not found on object");
            return -1;
        }
    }

    public Stats GetPlayerStats()
    {
        return curStats;
    }
    public override Stats GetStats()
    {
        return curStats;
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
