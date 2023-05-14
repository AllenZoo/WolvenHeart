using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SO_Stats : ScriptableObject
{
    [Header("Normal Stats")]
    [SerializeField] public float hp = 100;
    [SerializeField] public float sp = 100;
    [SerializeField] public float str = 1;
    [SerializeField] public float agl = 1;
    [SerializeField] public float def = 1;
    [SerializeField] public float reg = 1;
    [SerializeField] public float rec = 1;
}
