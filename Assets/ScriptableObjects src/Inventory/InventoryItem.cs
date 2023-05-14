using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem 
{
    public int quantity;
    public SO_Item item;
    public bool IsEmpty => item == null;

    public InventoryItem()
    {
        item = null;
        quantity = 0;
    }

    public InventoryItem(int quantity, SO_Item item)
    {
        this.item = item;
        this.quantity = quantity;
    }
    
    public static InventoryItem GetEmptyInventoryItem()
    {
        return new InventoryItem();
    }

    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }
}
