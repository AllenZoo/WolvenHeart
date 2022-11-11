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

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
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

    /* -------------------------------------------------------------------------- */


    /* -------------------------------------------------------------------------- */
    /*                                  INPUT                                     */
    /* -------------------------------------------------------------------------- */

    /// <summary>
    /// Prepares input requests.
    /// </summary>
    private void PrepareInput()
    {
        input.OnRequestMove += HandleMovementRequest;
        input.OnRequestInteract += HandleInteraction;
        input.OnRequestAbility += HandleAbilityRequest;
    }

    /// <summary>
    /// Handles collision object interactions.
    /// </summary>
    private void HandleInteraction()
    {
        cm.Interact();
    }

    /* -------------------------------------------------------------------------- */

    /* -------------------------------------------------------------------------- */
    /*                                  ABILITIES                                 */
    /* -------------------------------------------------------------------------- */
    /// <summary>
    /// Prepares ability requests.
    /// </summary>
    private void PrepareAbilities()
    {
        ah.OnAbilityActionRequest += HandleAbilityAction;
    }

    /// <summary>
    /// Handler for requests to use an ability on key.
    /// </summary>
    /// <param name="k">trigger key</param>
    private void HandleAbilityRequest(KeyCode k)
    {
        ah.TryTriggerAbility(k, stats.GetPlayerStats());
    }

    /// <summary>
    /// Handler for ability actions.
    /// </summary>
    /// <param name="abilityAction">ability action</param>
    private void HandleAbilityAction(AbilityAction abilityAction)
    {
        switch (abilityAction.actionType)
        {
            case AbilityActionType.DashAbility:
                Debug.Log("Handling Dash Ability");

                // TODO: Make this code better so we don't have to cast
                DashAbilityAction ab = (DashAbilityAction) abilityAction;
                HandleDashRequest(ab);
                break;
            default:
                Debug.Log("Unimplemented Action type requested");
                break;
        }
    }

    /* -------------------------------------------------------------------------- */

    /* -------------------------------------------------------------------------- */
    /*                                  MOVEMENT                                  */
    /* -------------------------------------------------------------------------- */
    /// <summary>
    /// Handles requests for player movement (both physics and animation).
    /// </summary>
    /// <param name="x">+right, -left</param>
    /// <param name="y">+up, -down</param>
    private void HandleMovementRequest(float x, float y)
    {
        Vector3 movementVector = new Vector3(x, y, 0).normalized;
        movement.MovePlayer(x, y, stats.GetMovementSpeed());
        animator.HandlePlayerMovement(movementVector);
    }

    /// <summary>
    /// Requests player to dash <paramref name="range"/> pixels
    /// forwards or backwards depending on <paramref name="dir"/>.
    /// </summary>
    /// <param name="range">number of pixels to dash forward</param>
    /// <param name="dir">dash direction (forward = 1, backward = -1)</param>
    private void HandleDashRequest(float range, float dir)
    {
        movement.Dash(range, dir);
    }

    private void HandleDashRequest(DashAbilityAction daa)
    {
        movement.Dash(daa.range, daa.dir);
        stats.SpendStamina(daa.cost);
        ah.StartCooldown(daa.soAbility);
    }

    /// <summary>
    /// Prepares movements.
    /// </summary>
    private void PrepareMovement()
    {
        
    }


    /* -------------------------------------------------------------------------- */


    /* -------------------------------------------------------------------------- */
    /*                                  STATS                                     */
    /* -------------------------------------------------------------------------- */

    private void HandleAbilityCost()
    {

    }



    /* -------------------------------------------------------------------------- */
}
