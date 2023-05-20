using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Enemy_CollisionManager : MonoBehaviour
{
    [SerializeField] private List<AttackBox> attacks = new List<AttackBox>();

    private Action OnAttacked;

    // Temp
    private StatsHandler statsHandler;

    private void Awake()
    {
        statsHandler = GetComponent<StatsHandler>();
    }

    private void Start()
    {
        OnAttacked += ProcessAttackBoxes;
    }

    /// <summary>
    /// Triggered when collider enters another collider.
    /// </summary>
    /// <param name="collider">collider of collided object</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<AttackBox>() != null)
        {
            //Debug.Log("Collided with something interactable!");
            attacks.Add(collider.GetComponent<AttackBox>());
            OnAttacked.Invoke();

            // TODO: Make AttackBox an interface with abstract function DealDamage(Stats).
            // eg. Burst attacks will run a Coroutine that deals damage once, and be gone.
            //     ContinuousImpact attacks will run a Coroutine that deals damage every frame, and be gone once leaving collision.
            //     DOT attacks will run a Coroutine that deals damage every frame for a certain duration.
            // 
        }
    }

    /// <summary>
    /// Triggered when collider exits another collider.
    /// </summary>
    /// <param name="collider">collider of collided object</param>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<AttackBox>() != null)
        {
            //Debug.Log("Leaving something interactable!");
            attacks.Remove(collider.GetComponent<AttackBox>());
        }
    }

    private void ProcessAttackBoxes()
    {
        foreach (AttackBox attack in attacks)
        {
            // Process attacks here.
            // if attack is burst
            if (attack.targets.Contains(TargetType.Enemy))
            {
                DealDamage(attack.damage);
            }
            
        }
    }

    private void DealDamage(float damage)
    {
        statsHandler.DecreaseStat(Stats.Stat.curHealth, damage);
    }
}
