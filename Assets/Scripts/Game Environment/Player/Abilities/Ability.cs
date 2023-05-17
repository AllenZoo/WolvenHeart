using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    protected SO_Ability data;
    protected AnimationHandler aHandler;
    protected List<Ability> stackedAbilities;

    public Ability(SO_Ability data, GameObject abilityHolder)
    {
        this.data = data;
        this.aHandler = abilityHolder.GetComponent<AnimationHandler>();
        stackedAbilities = new List<Ability>();

        foreach (SO_Ability so_ability in data.stackedAbilities)
        {
            stackedAbilities.Add(so_ability.GenerateAbilityRef(abilityHolder));
        }
    }

    // Triggerrs the request to start the process of activating the ability
    public void Trigger(AbilityHandler abilityHolder)
    {
        if (VerifyConstraints())
        {
            Activate();
            abilityHolder.StartCoroutine(StartCooldown());
            aHandler.PlayAnimation(data.animation.name);
        } else
        {
            throw new ViolatedAbilityConstraints("Entity doesn't fit the requirment of activating ability.");
        }
    }

    // The actual implementation of the ability
    protected abstract void Activate();

    // Starts the cooldown of the ability
    protected IEnumerator StartCooldown()
    {
        data.isOnCooldown = true;
        Debug.Log("Starting cooldown!");
        yield return new WaitForSeconds(data.cooldown);
        Debug.Log("Cooldown finished!");
        data.isOnCooldown = false;
    }

    // Verifies if the ability can be activated
    // Currently only checks stat constrains
    // TODO: Add constraints for environment + cost constraints
    protected bool VerifyConstraints()
    {
        Debug.Log("Is off cd: " + !data.isOnCooldown);
        return !data.isOnCooldown;
    }


}

[Serializable]
public class ViolatedAbilityConstraints : Exception
{
    public ViolatedAbilityConstraints() : base() { }
    public ViolatedAbilityConstraints(string message) : base(message) { }
    public ViolatedAbilityConstraints(string message, Exception inner) : base(message, inner) { }
}