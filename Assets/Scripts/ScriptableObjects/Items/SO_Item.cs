using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Item : ScriptableObject
{
    [SerializeField] public bool IsStackable;
    [SerializeField] public int ID;

    public void SetID(int id)
    {
        ID = id;
    }
}
