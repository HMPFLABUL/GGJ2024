using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Sprite inventorySprite;
    public bool interactable;
    [SerializeField] Dialogue dialogue;
    public void OnUse()
    {
        Debug.Log("Used");
    }
}
