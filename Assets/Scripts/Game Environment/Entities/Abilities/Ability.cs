using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    protected SO_Ability data;
    protected AnimationHandler aHandler;
    protected StatsHandler sHandler;

    protected List<Ability> stackedAbilities;

    public Ability(SO_Ability data, GameObject abilityHolder)
    {
        this.data = data;
        this.aHandler = abilityHolder.GetComponent<AnimationHandler>();
        this.sHandler = abilityHolder.GetComponent<StatsHandler>();

        stackedAbilities = new List<Ability>();

        foreach (SO_Ability so_ability in data.stackedAbilities)
        {
            stackedAbilities.Add(so_ability.GenerateAbilityRef(abilityHolder));
        }
    }

    // Triggers the request to start the process of activating the ability
    // Will check the constraints of the ability before activating it
    public void Trigger(AbilityHandler abilityHolder)
    {
        if (VerifyConstraints())
        {
            SpendAbilityCost();
            Activate();
            abilityHolder.StartCoroutine(StartCooldown());

            if (data.animation != null)
            {
                Debug.Log("Playing animation: " + data.animation.name);
                aHandler.PlayAnimation(data.animation.name);
            }
            

            // TODO: Make sure animation isn't overwritten but particles are rendered.
            foreach (Ability stackedAbility in stackedAbilities)
            {
                // No need to check constraints for stacked abilities
                stackedAbility.Activate();
            }
        } else
        {
            throw new ViolatedAbilityConstraints("Entity doesn't fit the requirment of activating ability.");
        }
    }

    public void Trigger(AbilityHandler abilityHolder, bool isContinuous)
    {
        Trigger(abilityHolder);
        throw new NotImplementedException();
    }


    // The actual implementation of the ability
    protected abstract void Activate();

    // Starts the cooldown of the ability
    protected IEnumerator StartCooldown()
    {
        data.isOnCooldown = true;
        Debug.Log("Starting cooldown for " + data.name);
        yield return new WaitForSeconds(data.cooldown);
        Debug.Log("Cooldown finished for " + data.name);
        data.isOnCooldown = false;
    }

    // Verifies if the ability can be activated
    // Currently only checks stat constrains
    // TODO: Add constraints for environment
    protected bool VerifyConstraints()
    {
        // Check if the ability is on cooldown and if the entity can pay the cost
        if (data.isOnCooldown || !VerifyAbilityCost())
        {
            return false;
        }

        return true;
    }

    // Checks if the entity can pay the cost of the ability
    protected bool VerifyAbilityCost()
    {
        AbilityCost abilityCost = data.cost;

        foreach (StatCost statCost in abilityCost.statCosts)
        {
            if (!VerifyStatCost(statCost))
            {
                return false;
            }
        }

        return true;
    }

    // Checks if the entity can pay a stat cost
    protected bool VerifyStatCost(StatCost statCost)
    {
        if (sHandler.GetStatValue(statCost.statType) < statCost.value)
        {
            return false;
        }
        return true;
    }

    // Spends the cost of the ability
    protected void SpendAbilityCost()
    {
        AbilityCost abilityCost = data.cost;
        foreach (StatCost statCost in abilityCost.statCosts)
        {
            SpendStatCost(statCost);
        }
    }

    // Spends a stat cost
    protected void SpendStatCost(StatCost statCost)
    {
        sHandler.DecreaseStat(statCost.statType, statCost.value);
    }
}

[Serializable]
public class ViolatedAbilityConstraints : Exception
{
    public ViolatedAbilityConstraints() : base() { }
    public ViolatedAbilityConstraints(string message) : base(message) { }
    public ViolatedAbilityConstraints(string message, Exception inner) : base(message, inner) { }
}