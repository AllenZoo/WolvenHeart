using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public abstract class SO_Item : ScriptableObject
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public bool IsStackable { get; set; }
    [field: SerializeField] int MaxStackSize { get; set; } = 1;
    [field: SerializeField] public int ID { get; set; }
    [field: SerializeField] public Sprite ItemImage { get; set; }
    [field: SerializeField] [field: TextArea] public string Description { get; set; }

    public void SetID(int id)
    {
        ID = id;
    }
}
