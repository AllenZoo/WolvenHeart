using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_MovementHandler : MovementHandler
{
    private Vector2 lastDir;

    /* -------------------------------------------------------------------------- */
    /*                                    INIT                                    */
    /* -------------------------------------------------------------------------- */
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lastDir = Vector2.down;
    }

    /* -------------------------------------------------------------------------- */


    // This functions moves the player by adjusting the transform position of rigidbody.
    public override void Move(Vector2 direction, float speed)
    {
        if (direction.x != 0 || direction.y != 0)
        {
            lastDir = direction.normalized;
        }
        rb.velocity = direction.normalized * speed;

    }

    // This functions makes the player dash by adjusting the transform position. Essentially the same as Move() however with heightened
    // speed. Also uses MovePosition() instead of increasing rb.velocity.
    public override void Dash(Vector2 direction, float dashSpeed)
    {
        Vector2 calculatedVector = direction * dashSpeed;
        rb.MovePosition(rb.position + calculatedVector * Time.fixedDeltaTime);
    }

    // This functions makes the player dash by adjusting the transform position. Essentially the same as Move() however with heightened
    // speed. Also uses MovePosition() instead of increasing rb.velocity.
    public override void Dash(float directionMod, float dashSpeed)
    {
        Vector2 calculatedVector = lastDir * dashSpeed * directionMod;
        rb.MovePosition(rb.position + calculatedVector * Time.fixedDeltaTime);
    }


    /* -------------------------------------------------------------------------- */
    /*                                  OLD                                       */
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
            // lastDir = new Vector2(x, y).normalized;
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
    public void DashOld(float range, float dir)
    {
        if (dir == 1)
        {
            // dash forward
            // Debug.Log("Dashing forwards " + range + " pixels" + " in dir: (" + lastDir.x * dir + ", " + lastDir.y * dir + ")");
            // MovePlayer(lastDir.x * dir, lastDir.y * dir, range);

        }
        else if (dir == -1)
        {
            // dash backwards
            // Debug.Log("Dashing backwards " + range + " pixels" + " in dir: (" + lastDir.x * dir + ", " + lastDir.y * dir + ")");
            // MovePlayer(lastDir.x * dir, lastDir.y * dir, range);
        }
        else
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
        return new Vector2();
        //return lastDir.normalized;
    }
}
