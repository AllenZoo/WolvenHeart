using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    /* ------------------------------- NORMALSTATS ------------------------------ */
    [SerializeField] protected float hp = 100;
    [SerializeField] protected float sp = 100;
    [SerializeField] protected float str = 1;
    [SerializeField] protected float agl = 1;
    [SerializeField] protected float def = 1;
    [SerializeField] protected float reg = 1;
    [SerializeField] protected float rec = 1;

    /* ------------------------------ SPECIAL STATS ----------------------------- */


    /* --------------------------------- GETTERS -------------------------------- */
    public float GetMovementSpeed()
    {
        // TODO: implement speed calculator
        return agl * 5;
    }
}
