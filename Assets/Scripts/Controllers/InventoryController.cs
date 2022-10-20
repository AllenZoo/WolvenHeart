using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private SO_Inventory SOInventory;
    [SerializeField] private UI_InventoryPage UIInventoryPage;


    [SerializeField] public List<InventoryItem> initialItems;

    public void Start()
    {
        PrepareUIInventoryPage();
        PrepareSOInventory();
    }

    private void PrepareSOInventory()
    {
        if (SOInventory == null)
        {
            throw new System.Exception("SQInventory is NULL");
        }

        SOInventory.Initialize();
        SOInventory.OnInventoryUpdated += HandleInventoryUpdate;

        foreach (InventoryItem item in initialItems)
        {
            if (item.IsEmpty) continue;
            SOInventory.AddItem(item);
        }
    }

    private void HandleInventoryUpdate(Dictionary<int, InventoryItem> obj)
    {
        Debug.Log("Updating inventory from controller!");
        int count = 0;
        UIInventoryPage.ResetUIItemData();
        foreach (var item in obj)
        {
            if (item.Value.IsEmpty) continue;
            // item.key is index, item.value is InventoryItem to be converted into ui inventory item
            UIInventoryPage.SetUIItemData(item.Key, item.Value.item.ItemImage, item.Value.quantity, count);
            count++;
        }
    }

    private void PrepareUIInventoryPage()
    {
        int size = SOInventory.Size;
        Debug.Log("SO Inventory size: " + size);
        UIInventoryPage.InitInventoryUI(size);
        UIInventoryPage.OnSwapItems += HandleSwapItems;
    }

    private void HandleSwapItems(int index1, int index2)
    {
        SOInventory.SwapItems(index1, index2);
    }
}
