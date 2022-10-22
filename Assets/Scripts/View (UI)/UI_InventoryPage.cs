using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryPage : MonoBehaviour
{

    [SerializeField] private UI_InventoryItem uiItemPfb;
    [SerializeField] private RectTransform contentPanel;

    [SerializeField] private MouseFollower itemFollower;
    [SerializeField] private UI_Inventory_PopUp popUpWindow;


    public event Action<int> OnStartDragging, OnPopUpRequested;
    public event Action<int, int> OnSwapItems;

    private List<UI_InventoryItem> uiItems = new List<UI_InventoryItem>();
    private int indexOfCurSelectedItem = -1;

    public void Awake()
    {
        Hide();
        itemFollower.Toggle(false);
    }

    public void InitInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UI_InventoryItem uiItem = Instantiate(uiItemPfb, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            uiItems.Add(uiItem);

            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleDisplayRightClickOptions;


        }

    }

    public void UpdateData(int index, Sprite sprite, int quantity)
    {
        if (uiItems.Count > index)
        {
            uiItems[index].SetItem(sprite, quantity);
        }
        
    }

    public void ResetAllItems()
    {
        foreach (var item in uiItems)
        {
            item.ResetData();
            item.DeSelect();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    /* Summary: Creates a mouse follower dragged item! */
    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        itemFollower.Toggle(true);
        itemFollower.SetData(sprite, quantity);
    }

    /* Summary: Creates a pop up at item */
    public void CreatePopUp(String name, String description)
    {
        Debug.Log("creating a pop up that displays item name: " + name + " and item description: " + description);
    }

    private void DeselectAllItems()
    {
        foreach (UI_InventoryItem item in uiItems)
        {
            item.DeSelect();
        }
    }

    /* Called when UI item is right clicked*/
    private void HandleDisplayRightClickOptions(UI_InventoryItem obj)
    {
        // TODO: Generate Clickable Actions
    }

    /* Called when drag action stops.
     * Summary: calls ResetDraggedItem  */
    private void HandleEndDrag(UI_InventoryItem uiItem)
    {
        // TODO: 
        ResetDraggedItem();
    }

    /* Summary: Resets dragged item index and hides mouse follower */
    private void ResetDraggedItem()
    {
        itemFollower.Toggle(false);
        indexOfCurSelectedItem = -1;
    }

    /* Called when something is dropped on top of a UI Item
     * Summary: tells controller to swap the items in SO Inventory */
    private void HandleSwap(UI_InventoryItem uiItem)
    {
        int index = uiItems.IndexOf(uiItem);
        if (indexOfCurSelectedItem == -1) return;
        OnSwapItems?.Invoke(index, indexOfCurSelectedItem);
    }

    /*  Called when UI Item is clicked 
     *  Summary: Displays border around selected item   */
    private void HandleItemSelection(UI_InventoryItem uiItem)
    {
        // TODO: Generate pop-up window that displays description.
        int index = uiItems.IndexOf(uiItem);
        if (index == -1)
            return;
        OnPopUpRequested?.Invoke(index);
    }

    /*  Called when UI Item begins being dragged 
     *  Summary: Invokes a call to controller that creates a mouse follower
     *           of the item being dragged                                */
    private void HandleBeginDrag(UI_InventoryItem uiItem)
    {
        int index = uiItems.IndexOf(uiItem);
        //int index = uiItem.index;
        if (index == -1) return;

        indexOfCurSelectedItem = index;
        HandleItemSelection(uiItem);
        OnStartDragging?.Invoke(indexOfCurSelectedItem);
    }
}
