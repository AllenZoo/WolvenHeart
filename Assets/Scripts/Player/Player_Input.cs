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

    private void FixedUpdate()
    {
        HandleMovementInput();
    }

    private void Update()
    {
        HandleInteractInput();
        HandleAbilityInput();
    }

    private void HandleMovementInput()
    {
        float yInput =  Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        yInput *= Time.fixedDeltaTime;
        xInput *= Time.fixedDeltaTime;

        OnRequestMove?.Invoke(xInput, yInput);
    }

    private void HandleInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnRequestInteract?.Invoke();
        }
    }

    private void HandleAbilityInput()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnRequestAbility?.Invoke(KeyCode.K);
        }
    }

}
