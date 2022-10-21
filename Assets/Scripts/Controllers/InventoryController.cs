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
        
        UIInventoryPage.ResetAllItems();
        foreach (var item in obj)
        {
            //Debug.Log("Updating inventory from controller!");
            UIInventoryPage.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
        }
    }

    private void PrepareUIInventoryPage()
    {
        int size = SOInventory.Size;
        Debug.Log("SO Inventory size: " + size);
        UIInventoryPage.InitInventoryUI(size);
        UIInventoryPage.OnSwapItems += HandleSwapItems;
        UIInventoryPage.OnStartDragging += HandleDragging;
    }

    private void HandleDragging(int itemIndex)
    {
        InventoryItem item = SOInventory.GetItemAt(itemIndex);

        if (item.IsEmpty) return;

        UIInventoryPage.CreateDraggedItem(item.item.ItemImage, item.quantity);
    }

    private void HandleSwapItems(int index1, int index2)
    {
        SOInventory.SwapItems(index1, index2);
    }
}
