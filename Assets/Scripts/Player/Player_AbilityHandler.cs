using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Player_AbilityHandler : MonoBehaviour
{
    [SerializeField] private List<SO_AbilityInputPair> abilities;
    private Dictionary<KeyCode, SO_Ability> abilityDict;

    public Action<AbilityAction> OnAbilityActionRequest;

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
    private void Awake()
    {
        abilityDict = new Dictionary<KeyCode, SO_Ability>();
    }

    private void Start()
    {
        // Initialize Ability Dict
        foreach (SO_AbilityInputPair p in abilities)
        {
            abilityDict.Add(p.keyCode, p.ability);
        }
    }

    /* -------------------------------------------------------------------------- */

    /// <summary>
    /// Tests if the trigger key corresponds to an ability.
    /// </summary>
    /// <param name="input">trigger key</param>
    public void TryTriggerAbility(KeyCode input)
    {
        if (abilityDict.ContainsKey(input))
        {
            Debug.Log("Using ability: " + abilityDict[input].abilityName);
            OnAbilityActionRequest?.Invoke(abilityDict[input].Trigger());
        } else
        {
            Debug.Log("Player doesn't have that ability input bounded to ability");
        }
    }

}
