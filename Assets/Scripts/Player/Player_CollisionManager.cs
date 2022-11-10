using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player_CollisionManager : MonoBehaviour
{
    private IInteractable curInteractable;

    /// <summary>
    /// Interact with current interactable object if it exists, else do nothing.
    /// </summary>
    public void Interact()
    {
        if (curInteractable != null)
        {
            curInteractable.Interact();
        } else
        {
            Debug.LogWarning("Interacting with nothing");
        }
        
    }

    /// <summary>
    /// Triggered when collider enters another collider.
    /// </summary>
    /// <param name="collider">collider of collided object</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<IInteractable>() != null)
        {
            //Debug.Log("Collided with something interactable!");
            curInteractable = collider.GetComponent<IInteractable>();
        }
    }

    /// <summary>
    /// Triggered when collider exits another collider.
    /// </summary>
    /// <param name="collider">collider of collided object</param>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<IInteractable>() != null)
        {
            //Debug.Log("Leaving something interactable!");
            curInteractable = null;
        }
    }
}
