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

        if (x != 0 || y != 0)
        {
            animator.SetFloat("curX", (x == 0) ? 0 : Mathf.Sign(x));
            animator.SetFloat("curY", Mathf.Sign(y));
        }
    }

    public float getXDir()
    {
        return animator.GetFloat("xDir");
    }

    public float getYDir()
    {
        return animator.GetFloat("yDir");
    }
}
