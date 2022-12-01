using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    // Set default dir to downwards (0, -1)
    private Vector2 curDir = Vector2.down;

    // Tracks the last dir where player faced while moving
    private Vector2 lastDir = Vector2.down;

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
    private void Awake()
    {
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
        if (x != 0 || y != 0)
        {
            lastDir = new Vector2(x, y).normalized;
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
            Debug.Log("Dashing forwards " + range + " pixels" + " in dir: (" + lastDir.x*dir + ", " + lastDir.y*dir + ")");
            MovePlayer(lastDir.x * dir, lastDir.y * dir, range);

        } else if (dir == -1)
        {
            // dash backwards
            Debug.Log("Dashing backwards " + range + " pixels" + " in dir: (" + lastDir.x*dir + ", " + lastDir.y*dir + ")");
            MovePlayer(lastDir.x * dir, lastDir.y * dir, range);
        } else
        {
            Debug.LogWarning("Invalid dir param");
        }
    }

    /// <summary>
    /// Gets the Direction of Player in which they will dash if requested.
    /// </summary>
    /// <returns> normlized direction vector </returns>
    public Vector2 GetDashDir()
    {
        return lastDir.normalized;
    }
}
