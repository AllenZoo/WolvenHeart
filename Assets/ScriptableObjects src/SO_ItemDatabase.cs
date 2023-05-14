using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new item database", menuName ="SO/database/item database")]
public class SO_ItemDatabase : ScriptableObject
{
    [SerializeField] private List<SO_Item> items;

    private void allocateUniqueID()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetID(i);
        }
    }
    private void OnValidate()
    {
        allocateUniqueID();
    }
}
