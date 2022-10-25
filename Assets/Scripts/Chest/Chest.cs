using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChestEventHandler))]
public class Chest : MonoBehaviour
{
    private ChestEventHandler chestEventHandler;

    private void Awake()
    {
        chestEventHandler = GetComponent<ChestEventHandler>();
    }

    private void Start()
    {
        chestEventHandler.onInteract += HandleInteract;      
    }

    private void HandleInteract(int obj)
    {
        Debug.Log("Player just interacted with chest!");
    }
}
