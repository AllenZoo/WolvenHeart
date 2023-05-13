using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Player_Animation : MonoBehaviour
{
    private Animator animator;

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /* -------------------------------------------------------------------------- */

    /// <summary>
    /// Handles player movements given <paramref name="vector"/>.
    /// </summary>
    /// <param name="vector">direction to move (keep z=0)</param>
    public void HandlePlayerMovement(Vector2 vector)
    {
        HandlePlayerMovement(vector.x, vector.y);
    }

    /// <summary>
    /// Handles player movements given
    /// <paramref name="x"/> and <paramref name="y"/> coordinates.
    /// </summary>
    /// <param name="x">+right, -left</param>
    /// <param name="y">+up, -down</param>
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

    /// <summary>
    /// Gets the x-direction the player is facing.
    /// </summary>
    /// <returns>state of x direction</returns>
    public float getXDir()
    {
        return animator.GetFloat("xDir");
    }

    /// <summary>
    /// Gets the y-direction the player is facing.
    /// </summary>
    /// <returns>state of y direction</returns>
    public float getYDir()
    {
        return animator.GetFloat("yDir");
    }
}
