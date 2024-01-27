using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviourSingleton<InventoryManager>
{
    [SerializeField] RectTransform Inventory;
    [SerializeField] List<InventoryItemSlot> Slots;
    List<InventoryItem> Items;

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
    }
    public void AddItem(InventoryItem item)
    {
        Items.Add(item);
        Slots[Items.Count - 1].button.interactable = Items[Items.Count - 1].interactable;
        Slots[Items.Count - 1].button.onClick.RemoveAllListeners();
        Slots[Items.Count - 1].SetSprite(Items[Items.Count - 1].inventorySprite);
        if (!Items[Items.Count - 1].interactable)
            return;
        //Slots[Items.Count - 1].button.onClick.AddListener(() => RemoveItem(Items[Items.Count - 1]));
        Slots[Items.Count - 1].button.onClick.AddListener(() => CloseInventory());
        Slots[Items.Count - 1].button.onClick.AddListener(() => Items[Items.Count - 1].OnUse());
    }
    public void RemoveItem(InventoryItem item)
    {
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
