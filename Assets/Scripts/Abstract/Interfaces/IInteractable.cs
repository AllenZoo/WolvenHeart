using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public event Action<int> onInteract;
    abstract void Interact();
}
