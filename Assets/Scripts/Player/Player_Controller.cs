using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Player_Movement), typeof(Player_Input), typeof(Player_Animation))]
[RequireComponent(typeof(Player_Stats), typeof(Player_CollisionManager), typeof(Player_Animation))]
[RequireComponent(typeof(Player_AbilityHandler))]
public class Player_Controller : MonoBehaviour
{
    private Player_Movement movement;
    private Player_Input input;
    private Player_Animation animator;
    private Player_Stats stats;
    private Player_CollisionManager cm;
    private Player_AbilityHandler ah;

    /* INIT ***********************************************************/
    public void Awake()
    {
        movement = GetComponent<Player_Movement>();
        input = GetComponent<Player_Input>();
        animator = GetComponent<Player_Animation>();
        stats = GetComponent<Player_Stats>();
        cm = GetComponent<Player_CollisionManager>();
        ah = GetComponent<Player_AbilityHandler>();
    }
    public void Start()
    {
        PrepareInput();
        PrepareMovement();
        PrepareAbilities();
    }
    /********************************************************************/

    private void PrepareInput()
    {
        input.OnRequestMove += HandleMovementRequest;
        input.OnRequestInteract += HandleInteraction;
        input.OnRequestAbility += HandleAbilityRequest;
    }
    private void HandleInteraction()
    {
        cm.Interact();
    }

    /* ABILITIES ********************************************************/
    private void PrepareAbilities()
    {
        ah.OnAbilityActionRequest += HandleAbilityAction;
    }
    private void HandleAbilityRequest(KeyCode k)
    {
        ah.TryTriggerAbility(k);
    }
    private void HandleAbilityAction(AbilityAction abilityAction)
    {
        switch (abilityAction.actionType)
        {
            case AbilityActionType.DashAbility:
                Debug.Log("Handling Dash Ability");
                // TODO: Make this code better so we don't have to cast
                DashAbilityAction ab = (DashAbilityAction)abilityAction;
                HandleDashRequest(ab.range, ab.dir);
                break;
            default:
                Debug.Log("Unimplemented Action type requested");
                break;
        }
    }
    /********************************************************************/

    /* MOVEMENT ********************************************************/
    private void HandleMovementRequest(float x, float y)
    {
        Vector3 movementVector = new Vector3(x, y, 0).normalized;
        movement.MovePlayer(x, y, stats.GetMovementSpeed());
        animator.HandlePlayerMovement(movementVector);
    }

    // Requests Player to dash _range_ pixels forwards or backwards depending on _dir_  (dir = 1 -> go forwards, dir = -1 -> go backwards)
    private void HandleDashRequest(float range, float dir)
    {
        movement.Dash(range, dir);
    }

    private void PrepareMovement()
    {
        
    }
}
