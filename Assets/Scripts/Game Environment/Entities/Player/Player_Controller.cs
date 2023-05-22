using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
 * 
 * Player Controller class that connects everything together.
 * Acts like an API of sorts.
 * 
 */
[RequireComponent (typeof(Player_MovementHandler), typeof(Player_Input), typeof(Player_Animation))]
[RequireComponent(typeof(Player_StatsHandler), typeof(Player_CollisionManager), typeof(Player_Animation))]
[RequireComponent(typeof(Player_AbilityHandler), typeof(Player_ParticleHandler))]

public class Player_Controller : MonoBehaviour
{
    private Player_MovementHandler movement;
    private Player_Input input;
    private Player_Animation animator;
    private Player_StatsHandler stats;
    private Player_CollisionManager cm;
    private Player_AbilityHandler ah;
    private Player_ParticleHandler ph;

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
    public void Awake()
    {
        movement = GetComponent<Player_MovementHandler>();
        input = GetComponent<Player_Input>();
        animator = GetComponent<Player_Animation>();
        stats = GetComponent<Player_StatsHandler>();
        cm = GetComponent<Player_CollisionManager>();
        ah = GetComponent<Player_AbilityHandler>();
        ph = GetComponent<Player_ParticleHandler>();
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
        // ah.OnAbilityActionRequest += HandleAbilityAction;
    }

    /// <summary>
    /// Handler for requests to use an ability on key.
    /// </summary>
    /// <param name="k">trigger key</param>
    private void HandleAbilityRequest(KeyCode k)
    {
        ah.RequestAbilityTrigger(k);
    }


    /* -------------------------------------------------------------------------- */

    /* -------------------------------------------------------------------------- */
    /*                                  MOVEMENT                                  */
    /* -------------------------------------------------------------------------- */

    /// NOTE: this violates the SRP, but it is required to maintain smooth movement
    ///         - method is also called in Update.
    /// <summary>
    /// Handles requests for player movement (both physics and animation).
    /// </summary>
    /// <param name="dir">normalized direction vector</param>
    private void HandleMovementInput_Updated()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Move(dir, stats.GetMovementSpeed());
        animator.HandlePlayerMovement(dir);
    }

    /// <summary>
    /// Handles requests for player movement (both physics and animation).
    /// </summary>
    /// <param name="dir">normalized direction vector</param>
    private void HandleMovementRequest(Vector2 dir)
    {
        //movement.Move(dir, stats.GetMovementSpeed());
        //animator.HandlePlayerMovement(dir);
    }


    /* -------------------------------------------------------------------------- */

    /* -------------------------------------------------------------------------- */
    /*                                 CONTROLLER                                 */
    /* -------------------------------------------------------------------------- */

   

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





    /* -------------------------------------------------------------------------- */

    private void Update()
    {
        HandleMovementInput_Updated();
    }
}
