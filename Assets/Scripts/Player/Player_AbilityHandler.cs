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
    ///     1. Ability is available
    /// </summary>
    /// <param name="input">trigger key</param>
    public void TryTriggerAbility(KeyCode input, Stats stats)
    {
        if (abilityDict.ContainsKey(input))
        {
            SO_Ability ability = abilityDict[input];
            if (IsAbilityAvailable(ability, stats))
            {
                Debug.Log("Using ability: " + ability.abilityName);
                OnAbilityActionRequest?.Invoke(ability.Trigger());
            } else
            {
                Debug.Log("Ability is not available right now");
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
    ///     2. Player has enough resources (stamina, hp) to use ability
    /// Assume that he SO_Ability passed through is guranteed to be in list of abilities
    /// the player has equipped.
    /// </summary>
    /// <param ability="input">ability to check for availability</param>
    private bool IsAbilityAvailable(SO_Ability ability, Stats stats)
    {
        // TODO: implement
        return !abilityOnCD[ability] && stats.GetStatValue(Stats.Stat.curStamina) >= ability.cost;
    }

    /// <summary>
    /// Starts Cooldown. Refreshes ability availability once time passes.
    /// </summary>
    /// <param ability="input">ability to refresh</param>
    public void StartCooldown(SO_Ability ability)
    {
        StartCoroutine(RefreshCooldown(ability));
    }

    private IEnumerator RefreshCooldown(SO_Ability ability)
    {
        // set ability on cooldown
        abilityOnCD[ability] = true;

        Debug.Log("Starting " + ability.name + " cooldown " + " for " + ability.cooldown + " seconds");
        yield return new WaitForSeconds(ability.cooldown);

        // Sets the ability to not be on Cooldown
        abilityOnCD[ability] = false;

        Debug.Log(ability.cooldown + " Cooldown Refreshed!!");
    }

}
