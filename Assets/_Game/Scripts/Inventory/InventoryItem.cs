using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItem : ITEM
{
    public Sprite inventorySprite;
    public bool interactable;
    [SerializeField] NPCConversation pickDialogue;
    [SerializeField] NPCConversation jokeDialogue;
    [SerializeField] UnityEvent OnPickup;
    public void OnUse()
    {
        
    }
    private void OnMouseDown()
    {
        if (!CheckDistanceToPlayer())
            return;
        if (GameStateMachine.Instance.state == GameStateMachine.GameState.Gameplay)
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        OnPickup?.Invoke();
        InventoryManager.Instance.AddItem(this);
        gameObject.SetActive(false);
        if(pickDialogue!=null)
            ConversationManager.Instance.StartConversation(pickDialogue);
        ChangeStateToDialogue();
    }
    public void RemoveFromInventory()
    {
        InventoryManager.Instance.RemoveItem(this);
    }
}
