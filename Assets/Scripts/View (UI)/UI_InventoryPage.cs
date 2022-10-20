using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryPage : MonoBehaviour
{

    [SerializeField] private UI_InventoryItem uiItemPfb;
    [SerializeField] private RectTransform contentPanel;


    public event Action<int> OnStartDragging;
    public event Action<int, int> OnSwapItems;

    private List<UI_InventoryItem> uiItems = new List<UI_InventoryItem>();
    private int indexOfCurSelectedItem = -1;

    public void Start()
    {
        //uiItems = new List<UI_InventoryItem>();
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
        //Debug.Log("Updating UI");
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

    private void DeslsectAllItems()
    {
        foreach (UI_InventoryItem item in uiItems)
        {
            item.DeSelect();
        }
    }

    private void HandleDisplayRightClickOptions(UI_InventoryItem obj)
    {
        // TODO: Generate Clickable Actions
    }

    private void HandleEndDrag(UI_InventoryItem uiItem)
    {
        // TODO: 
        indexOfCurSelectedItem = -1;
    }

    private void HandleSwap(UI_InventoryItem uiItem)
    {

        int index = uiItems.IndexOf(uiItem);
        //int index = uiItem.index;
        Debug.Log("swapping items! index1 : " + index  + " index2: " + indexOfCurSelectedItem);
        if (indexOfCurSelectedItem == -1) return;


        Debug.Log("actually swapping items!");
        OnSwapItems?.Invoke(index, indexOfCurSelectedItem);

    }

    private void HandleItemSelection(UI_InventoryItem uiItem)
    {
        // TODO: Generate pop-up window that displays description.
        int index = uiItems.IndexOf(uiItem);
        if (index == -1)
            return;
        // OnPopUpRequested?.Invoke(index)
    }

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
