using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    [SerializeField] private SO_PlayerStats soStats;
    [SerializeField] private PlayerStats pStats;

    /* --------------------------------- STATES -------------------------------- */
    protected bool canRegenHP = true;
    protected bool canRegenSP = true;


    /* ---------------------------------- INIT ----------------------------- */
    private void Awake()
    {
        pStats = new PlayerStats();

        // TODO: move all the initialization into respective classes.
        pStats.maxHP = soStats.hp;
        pStats.maxSP = soStats.sp;
        pStats.str = soStats.str;
        pStats.agl = soStats.agl;
        pStats.def = soStats.def;
        pStats.reg = soStats.reg;
        pStats.rec = soStats.rec;

        pStats.aRec = soStats.aRec;
        pStats.aReg = soStats.aReg;
        pStats.LSTL = soStats.LSTL;
        pStats.LUCK = soStats.LUCK;
        pStats.PREC = soStats.PREC;
        pStats.CDR = soStats.CDR;
        pStats.APEN = soStats.APEN;
    }

    private void Start()
    {
        pStats.curHP = pStats.maxHP;
        pStats.curSP = pStats.maxSP;
        StartCoroutine(HandleSPRegen());
    }

    /* -------------------------------- MODIFIERS ------------------------------- */
    public void SpendStamina(float value)
    {
        pStats.curSP -= value;
        StopAllCoroutines();
        StartCoroutine(HandleSPRegen());
    }


    /* --------------------------------- GETTERS -------------------------------- */
    public float GetMovementSpeed()
    {
        // TODO: implement speed calculator
        return pStats.agl * 5;
    }
    public PlayerStats GetPlayerStats()
    {
        return pStats;
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
        return pStats.reg * 5;
    }
    private void RecoverHP(float value)
    {
        pStats.curHP += value;

        if (pStats.curHP > pStats.maxHP)
        {
            pStats.curHP = pStats.maxHP;
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
        return pStats.rec * 5;
    }
    private void RecoverSP(float value)
    {
        pStats.curSP += value;

        if (pStats.curSP > pStats.maxSP)
        {
            pStats.curSP = pStats.maxSP;
        }
    }
    private IEnumerator HandleSPRegen()
    {
        while (pStats.curSP < pStats.maxSP)
        {
            yield return StartCoroutine(RegenSP());
        }
    }


    
}
