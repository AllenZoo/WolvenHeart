using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new inventory", menuName ="SO/new inventory")]
public class SO_Inventory : ScriptableObject
{

    [SerializeField] private List<InventoryItem> inventoryItems;

    [field: SerializeField] public int Size { get; private set; }

    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

    /*   Summary: Initializes the scriptable object, filling list of inventory items with empty items. (default)   */
    public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyInventoryItem());
        }
    }

    /*   Returns the data of the inventory in form of <index, item>  */
    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> curState = new Dictionary<int, InventoryItem>();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty) continue;
            curState[i] = inventoryItems[i];
        }

        return curState;
    }

     /*
         Overloaded Function
     */
    public int AddItem(InventoryItem item)
    {
        return AddItem(item.item, item.quantity);
    }

    /*
        Summary: Adds an item to the inventory
        PRE: if item is stackable, find if item is already in list and then add.
        PRE: if item is not stackable, add item {quantity} times until all items have been added
             or inventory becomes full.
        POST: the item(s) should be added to the first empty inventory slot or stacked with another item.
     */
    public int AddItem(SO_Item item, int quantity)
    {
        if (!item.IsStackable)
        {
            // Item not stackable, therefore add items one by one until either inventory is full
            // or items are all added.
            int count = quantity;
            while (count > 0 && !IsInventoryFull())
            {
                // adding items 1 by 1
                AddItemToFirstEmptySlot(item, 1);
                count--;
            }
            InformAboutChange();
            return quantity;
        } else
        {
            // Item is stackable.
            AddStackableItem(item, quantity);
            InformAboutChange();
        }
        
        return quantity;
    }

    /*  Summary: Swaps items of inventory in index 1 and index 2.   */
    public void SwapItems(int itemIndex1, int itemIndex2)
    {
        InventoryItem tempItem = inventoryItems[itemIndex1];
        inventoryItems[itemIndex1] = inventoryItems[itemIndex2];
        inventoryItems[itemIndex2] = tempItem;
        InformAboutChange();
    }

    /*  Remove Item: removes {quantity} amount of items from index  */
    public void RemoveItem(int itemIndex, int quantity)
    {
        // check if index actually has something to remove
        if (inventoryItems[itemIndex].IsEmpty) return;

        // check if quantity to remove is greater than quantity possessed
        int remainder = inventoryItems[itemIndex].quantity - quantity;
        if (remainder > 0)
        {
            // if no, remove quantity amount from item.
            inventoryItems[itemIndex].SetQuantity(remainder);
        } else
        {
            // if yes, completely remove item and replace with empty item slot
            inventoryItems[itemIndex] = InventoryItem.GetEmptyInventoryItem();
        }
        InformAboutChange();
    }

    /*  Gets item in inventory at index*/
    public InventoryItem GetItemAt(int itemIndex)
    {
        return inventoryItems[itemIndex];
    }

    /*
        Summary: Adds an item to the first empty slot of inventory
        POST: If inventory is FULL, will return -1.
        Note: will add item with {quantity} amount even if not stackable.
     */
    private int AddItemToFirstEmptySlot(SO_Item item, int quantity)
    {
        InventoryItem newItem = new InventoryItem(quantity, item);

        // checks if inventory is full

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = newItem;
                return quantity;
            }
        }

        return -1;
    }
    /*  Overload Function */
    private int AddItemToFirstEmptySlot(InventoryItem item)
    {
        return AddItemToFirstEmptySlot(item.item, item.quantity);
    }

    private int AddStackableItem(SO_Item item, int quantity)
    {
        InventoryItem newItem = new InventoryItem(quantity, item);
        // Compares item id to match
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (!inventoryItems[i].IsEmpty && inventoryItems[i].item.ID == item.ID)
            {
                inventoryItems[i].quantity += quantity;
                return quantity;
            }
        }

        // Runs if could not find item of same type
        return AddItemToFirstEmptySlot(newItem);
    }

    /*  Summary: invokes events listening to object   */
    private void InformAboutChange()
    {
        OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
    }

    /*  Summary: returns true if inventory is full, false if it is not   */
    private bool IsInventoryFull()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                // Exists an empty slot
                return false;
            }
        }

        // No empty slots exist;
        return true;
    }
}
