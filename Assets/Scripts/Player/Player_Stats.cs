using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    [SerializeField] private SO_PlayerStats stats;
    /* --------------------------------- STATES -------------------------------- */
    protected bool canRegenHP = true;
    protected bool canRegenSP = true;

    /* ------------------------------ NORMAL STATS ----------------------------- */
    [SerializeField] protected float curHP;
    [SerializeField] protected float curSP;
    protected float maxHP = 100;
    protected float maxSP = 100;
    protected float str = 1;
    protected float agl = 1;
    protected float def = 1;
    protected float reg = 1;
    protected float rec = 1;

    /* ------------------------------ SPECIAL STATS ----------------------------- */

    protected float aRec = 1;
    protected float aReg = 1;
    protected float LSTL = 1;
    protected float LUCK = 1;
    protected float PREC = 1;
    protected float CDR = 1;
    protected float APEN = 1;

    /* ---------------------------------- INIT ----------------------------- */
    private void Awake()
    {
        maxHP = stats.hp;
        maxSP = stats.sp;
        str = stats.str;
        agl = stats.agl;
        def = stats.def;
        reg = stats.reg;
        rec = stats.rec;

        aRec = stats.aRec;
        aReg = stats.aReg;
        LSTL = stats.LSTL;
        LUCK = stats.LUCK;
        PREC = stats.PREC;
        CDR = stats.CDR;
        APEN = stats.APEN;
    }

    private void Start()
    {
        curHP = maxHP;
        curSP = 0;
        StartCoroutine(HandleSPRegen());
    }


    /* --------------------------------- GETTERS -------------------------------- */
    public float GetMovementSpeed()
    {
        // TODO: implement speed calculator
        return agl * 5;
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
        return reg * 5;
    }
    private void RecoverHP(float value)
    {
        curHP += value;

        if (curHP > maxHP)
        {
            curHP = maxHP;
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
        return rec * 5;
    }
    private void RecoverSP(float value)
    {
        curSP += value;

        if (curSP > maxSP)
        {
            curSP = maxSP;
        }
    }
    private IEnumerator HandleSPRegen()
    {
        while (curSP < maxSP)
        {
            yield return StartCoroutine(RegenSP());
        }
    }

}
