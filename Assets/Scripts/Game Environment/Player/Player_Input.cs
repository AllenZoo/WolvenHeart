using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Input : MonoBehaviour
{

    // Request Move Vector2. (normalized)
    public event Action<Vector2> OnRequestMove;

    public event Action OnRequestInteract;

    public event Action<KeyCode> OnRequestAbility;

    /* -------------------------------------------------------------------------- */
    /*                                CALL UPDATES                                */
    /* -------------------------------------------------------------------------- */
    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        // HandleMovementInput();
        HandleInteractInput();
        HandleAbilityInput();
    }

    /* -------------------------------------------------------------------------- */
   
    
    /// <summary>
    /// Handles object interact inputs.
    /// </summary>
    private void HandleInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnRequestInteract?.Invoke();
        }
    }

    /// <summary>
    /// Handles ability inputs.
    /// </summary>
    private void HandleAbilityInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnRequestAbility?.Invoke(KeyCode.Space);
        } else if (Input.GetKeyDown(KeyCode.K))
        {
            OnRequestAbility?.Invoke(KeyCode.K);
        } else if (Input.GetKeyDown(KeyCode.J))
        {
            OnRequestAbility.Invoke(KeyCode.J);
        }
    }


    //---------------------------- Deprecated ---------------------------------//
    /// NOTE: using this method may result in clunky movement, thus functionality of handling input of
    /// moving player has been moved to Player_Controller.cs
    /// 
    /// Would be ideal to have this method in Player_Input.cs to stick with SRP design principles.
    /// 
    /// <summary>
    /// Handles movement inputs (WASD, Arrow Keys, etc.).
    /// Calls OnRequestMove event with normalized direction vector.
    /// </summary>
    private void HandleMovementInput()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        yInput *= Time.fixedTime;
        xInput *= Time.fixedTime;

        xInput = Mathf.Clamp(xInput, -1, 1);
        yInput = Mathf.Clamp(yInput, -1, 1);

        Vector2 direction = new Vector2(xInput, yInput);

        // todo: remove this, this is a fix for making the movement smoother.
        // OnRequestMove?.Invoke(direction);
    }
}
