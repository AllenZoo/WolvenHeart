using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEventHandler : MonoBehaviour, IInteractable
{
    public event Action<int> onInteract;

    public void Interact()
    {
        onInteract?.Invoke(0);
    }
}
