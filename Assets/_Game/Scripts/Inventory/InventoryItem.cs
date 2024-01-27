using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : ITEM
{
    public Sprite inventorySprite;
    public bool interactable;
    [SerializeField] NPCConversation pickDialogue;
    [SerializeField] NPCConversation jokeDialogue;
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

    private void PickUp()
    {
        InventoryManager.Instance.AddItem(this);
        gameObject.SetActive(false);
        if(pickDialogue!=null)
            ConversationManager.Instance.StartConversation(pickDialogue);
        ChangeStateToDialogue();
    }
}
