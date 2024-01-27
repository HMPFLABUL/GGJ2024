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
    [SerializeField] protected NPCConversation pickDialogue;
    [SerializeField] protected NPCConversation jokeDialogue;
    [SerializeField] protected UnityEvent OnPickup;
    public virtual void OnUse()
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
        transform.localPosition = new Vector3(0,-1000f,0);
        if(pickDialogue!=null)
            ConversationManager.Instance.StartConversation(pickDialogue);
        ChangeStateToDialogue();
    }
    public void RemoveFromInventory()
    {
        InventoryManager.Instance.RemoveItem(this);
    }
}
