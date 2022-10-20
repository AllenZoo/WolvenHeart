using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventoryItem : MonoBehaviour, IPointerClickHandler,
        IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI numText;
    [SerializeField] private Image border;
    [SerializeField] private Image container;

    public bool isEmpty = true;

    public int index;

    public event Action<UI_InventoryItem> OnItemClicked,
            OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
            OnRightMouseBtnClick;

    public void Start()
    {
        border.enabled = false;
    }

    public void Select()
    {
        border.enabled = true;
    }

    public void DeSelect()
    {
        border.enabled = false;
    }

    public void ResetItem()
    {
        isEmpty = true;
        itemImage.gameObject.SetActive(false);
    }

    public void SetItem(Sprite sprite, int quantity)
    {
        itemImage.gameObject.SetActive(true);

        itemImage.sprite = sprite;
        numText.text = quantity.ToString();
        isEmpty = false;
    }

    public void SetItem(Sprite sprite, int quantity, int count)
    {
        itemImage.gameObject.SetActive(true);

        itemImage.sprite = sprite;
        numText.text = quantity.ToString();
        isEmpty = false;
        index = count;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        } else if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnItemClicked?.Invoke(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging!");
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

}
