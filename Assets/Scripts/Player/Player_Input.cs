using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{

    // Request Move x and y. (normalized)
    public event Action<float, float> OnRequestMove;

    public event Action OnRequestInteract;

    public event Action<KeyCode> OnRequestAbility;

    /* -------------------------------------------------------------------------- */
    /*                                CALL UPDATES                                */
    /* -------------------------------------------------------------------------- */
    private void FixedUpdate()
    {
        HandleMovementInput();
    }

    private void Update()
    {
        HandleInteractInput();
        HandleAbilityInput();
    }

    /* -------------------------------------------------------------------------- */
    /// <summary>
    /// Handles movement inputs (WASD, Arrow Keys, etc.).
    /// </summary>
    private void HandleMovementInput()
    {
        float yInput =  Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        yInput *= Time.fixedDeltaTime;
        xInput *= Time.fixedDeltaTime;

        OnRequestMove?.Invoke(xInput, yInput);
    }
    
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
        }
    }

}
