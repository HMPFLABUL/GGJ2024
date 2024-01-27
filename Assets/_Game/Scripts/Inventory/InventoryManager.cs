using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviourSingleton<InventoryManager>
{
    [SerializeField] RectTransform Inventory;
    [SerializeField] List<InventoryItemSlot> Slots;
    List<InventoryItem> Items;

    [SerializeField] InventoryItem testItem;

    private void Start()
    {
        if(Items==null)
            Items = new List<InventoryItem>();
        CloseInventory();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            OpenInventory();
        if (Input.GetKeyDown(KeyCode.Z))
            AddItem(testItem);
    }
    void AddItem(InventoryItem item)
    {
        Items.Add(item);
        Slots[Items.Count - 1].button.interactable = Items[Items.Count - 1].interactable;
        Slots[Items.Count - 1].button.onClick.RemoveAllListeners();
        if (!Items[Items.Count - 1].interactable)
            return;
        Slots[Items.Count-1].itemSprite = Items[Items.Count - 1].inventorySprite;
        Slots[Items.Count - 1].button.onClick.AddListener(() => RemoveItem(Items[Items.Count - 1]));
        Slots[Items.Count - 1].button.onClick.AddListener(() => CloseInventory());
    }
    void RemoveItem(InventoryItem item)
    {
        item.OnUse();
        Items.RemoveAt(Items.IndexOf(item));
    }
    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
        SetupSlots();
    }
    void CloseInventory()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].gameObject.SetActive(false);
        }
        Inventory.gameObject.SetActive(false);
    }
    void SetupSlots()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            Slots[i].gameObject.SetActive(true);
        }
    }
}
