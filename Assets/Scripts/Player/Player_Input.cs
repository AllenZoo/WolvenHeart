using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{

    // Request Move x and y. (normalized)
    public event Action<float, float> OnRequestMove;
    // Start is called before the first frame update

    public void FixedUpdate()
    {
        HandleMovementInput();
    }

    public void HandleMovementInput()
    {
        float yInput =  Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        yInput *= Time.fixedDeltaTime;
        xInput *= Time.fixedDeltaTime;

        OnRequestMove?.Invoke(xInput, yInput);
    }
}
