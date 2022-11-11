using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Player_AbilityHandler : MonoBehaviour
{
    [SerializeField] private List<SO_AbilityInputPair> abilities;

    // Keeps track of ability inputs assigned to abilities
    private Dictionary<KeyCode, SO_Ability> abilityDict;

    // Tracks whether ability is on cooldown or not
    private Dictionary<SO_Ability, bool> abilityOnCD;

    public Action<AbilityAction> OnAbilityActionRequest;

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
    private void Awake()
    {
        abilityDict = new Dictionary<KeyCode, SO_Ability>();
        abilityOnCD = new Dictionary<SO_Ability, bool>();
    }

    private void Start()
    {
        // Initialize Ability Dict
        foreach (SO_AbilityInputPair p in abilities)
        {
            abilityDict.Add(p.keyCode, p.ability);
            abilityOnCD.Add(p.ability, false);
        }
    }

    /* -------------------------------------------------------------------------- */

    /// <summary>
    /// Tests if the trigger key corresponds to an ability.
    /// If so, request ability trigger if:
    ///     1. Ability is not on cooldown
    ///     2. Player has enough resources (stamina, hp) to use ability.
    /// </summary>
    /// <param name="input">trigger key</param>
    public void TryTriggerAbility(KeyCode input)
    {
        if (abilityDict.ContainsKey(input))
        {
            if (IsAbilityAvailable(abilityDict[input]))
            {
                Debug.Log("Using ability: " + abilityDict[input].abilityName);
                OnAbilityActionRequest?.Invoke(abilityDict[input].Trigger());

                // set ability on cooldown
                abilityOnCD[abilityDict[input]] = true;

                // start cooldown timer
                StartCoroutine(StartCooldown(abilityDict[input]));
            }
            
        } else
        {
            Debug.Log("Player doesn't have that ability input bounded to ability");
        }
    }

    /// <summary>
    /// Returns the availability of ability
    /// An ability is available if:
    ///     1. It is not on cooldown
    /// Assume that he SO_Ability passed through is guranteed to be in list of abilities
    /// the player has equipped.
    /// </summary>
    /// <param ability="input">ability to check for availability</param>
    private bool IsAbilityAvailable(SO_Ability ability)
    {
        return !abilityOnCD[ability];
    }

    /// <summary>
    /// Starts Cooldown. Refreshes ability availability once time passes.
    /// </summary>
    /// <param ability="input">ability to refresh</param>
    private IEnumerator StartCooldown(SO_Ability ability)
    {
        Debug.Log("Starting " + ability.name + " cooldown " + " for " + ability.cooldown + " seconds");
        yield return new WaitForSeconds(ability.cooldown);

        // Sets the ability to not be on Cooldown
        abilityOnCD[ability] = false;

        Debug.Log(ability.cooldown  + " Cooldown Refreshed!!");

    }

}
