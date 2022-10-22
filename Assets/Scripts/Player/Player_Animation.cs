using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Player_Animation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandlePlayerMovement(Vector3 vector)
    {
        HandlePlayerMovement(vector.x, vector.y);
    }

    public void HandlePlayerMovement(float x, float y) 
    {
        animator.SetFloat("xDir", x);
        animator.SetFloat("yDir", y);
    }
}
