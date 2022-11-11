using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats : Stats
{
    public PlayerStats() : base()
    {
        
    }

    [SerializeField] public float curHP;
    [SerializeField] public float curSP;
    public float aRec = 1;
    public float aReg = 1;
    public float LSTL = 1;
    public float LUCK = 1;
    public float PREC = 1;
    public float CDR = 1;
    public float APEN = 1;
}
