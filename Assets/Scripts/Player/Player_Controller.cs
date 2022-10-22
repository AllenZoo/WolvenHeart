using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Player_Movement), typeof(Player_Input), typeof(Player_Animation))]
[RequireComponent(typeof(Player_Stats), typeof(Player_Input), typeof(Player_Animation))]
public class Player_Controller : MonoBehaviour
{
    private Player_Movement movement;
    private Player_Input input;
    private Player_Animation animator;
    private Player_Stats stats;

    public void Awake()
    {
        movement = GetComponent<Player_Movement>();
        input = GetComponent<Player_Input>();
        animator = GetComponent<Player_Animation>();
        stats = GetComponent<Player_Stats>();
    }

    public void Start()
    {
        PrepareInput();
        PrepareMovement();

    }

    private void PrepareInput()
    {
        input.OnRequestMove += HandleMovementRequest;
    }

    private void HandleMovementRequest(float x, float y)
    {
        movement.MovePlayer(x, y, stats.GetMovementSpeed());
    }

    private void PrepareMovement()
    {
        
    }
}
