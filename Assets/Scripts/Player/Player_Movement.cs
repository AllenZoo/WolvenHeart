using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    private Player_Animation playerAnimation;
    private Rigidbody2D rb;

    // Set default dir to downwards (0, -1)
    private Vector2 curDir = Vector2.down;

    // Tracks the last dir where player faced
    private Vector2 lastDir = Vector2.down;

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
    private void Awake()
    {
        playerAnimation = GetComponent<Player_Animation>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    /* -------------------------------------------------------------------------- */

    /// <summary>
    /// Moves player by (<paramref name="x"/>,<paramref name="y"/>) pixels,
    /// multiplied by <paramref name="speed"/>.
    /// </summary>
    /// <param name="x">+right, -left</param>
    /// <param name="y">+up, -down</param>
    /// <param name="speed">multiplier</param>
    public void MovePlayer(float x, float y, float speed)
    {
        if (x == 1 || y == 1)
        {
            lastDir = new Vector2(x, y);
        } else if (x == 0 && y == 0)
        {
            curDir = lastDir;
        }

        float moveX = x * speed;
        float moveY = y * speed;
        this.transform.Translate(new Vector3(moveX, moveY, 0));
    }

    /// <summary>
    /// Dashes the player in the direction specified by <paramref name="dir"/>
    /// by <paramref name="range"/> pixels.
    /// </summary>
    /// <param name="range">number of pixels to dash forward</param>
    /// <param name="dir">dash direction (forward = 1, backward = -1)</param>
    public void Dash(float range, float dir)
    {
        if (dir == 1)
        {
            // dash forward
            Debug.Log("Dashing forwards " + range + " pixels");
            MovePlayer(playerAnimation.getXDir(), playerAnimation.getYDir(), range);
            // rb.AddForce(new Vector2(range * dir, 0f), ForceMode2D.Impulse);

        } else if (dir == -1)
        {
            // dash backwards
            MovePlayer(-1 * playerAnimation.getXDir(), -1 * playerAnimation.getYDir(), range);
        }
    }
}
