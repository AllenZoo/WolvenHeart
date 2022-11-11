using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new player stats", menuName = "SO/Stats/PlayerStats")]
public class SO_PlayerStats : SO_Stats
{
    /*------------------ Special Stats ----------------*/
    [Header("Special Stats")]
    [SerializeField] public float aRec = 1;
    [SerializeField] public float aReg = 1;
    [SerializeField] public float LSTL = 1;
    [SerializeField] public float LUCK = 1;
    [SerializeField] public float PREC = 1;
    [SerializeField] public float CDR = 1;
    [SerializeField] public float APEN = 1;
}
