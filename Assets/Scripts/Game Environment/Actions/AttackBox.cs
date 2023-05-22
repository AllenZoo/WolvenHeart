using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    [SerializeField] public float damage = 10f;
    [SerializeField] public List<TargetType> targets = new List<TargetType>();

    // TODO: Add attack modifiers
    // [SerializeField] List<AttackModifiers> modifiers;
}

public enum TargetType
{
    Player,
    Enemy,
    Neutral,
}

public enum AttackType
{
    Burst,
    ContinuousImpact,
    DOT
}