using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is the interface for the movement handler for all moveable entities
 * 
 * @version 1.0.0
 */

[RequireComponent (typeof(Rigidbody))]
public abstract class MovementHandler : MonoBehaviour
{

    // The rigidbody of the entity to actually handle the physics of moving entity
    protected Rigidbody2D rb;

    /**
     * This method is called to move the entity
     * 
     * @param direction The direction to move the entity
     * @param speed The speed to move the entity
     */
    public abstract void Move(Vector2 direction, float speed);

    /**
     * This method is called to make the entity dash
     * 
     * @param direction The direction to dash the entity
     * @param speed The speed to dash the entity
     */
     public abstract void Dash(Vector2 direction, float speed);
}
