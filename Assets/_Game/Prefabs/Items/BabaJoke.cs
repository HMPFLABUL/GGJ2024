using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaJoke : InventoryItem
{
    [SerializeField] Transform KING;
    [SerializeField] NPCConversation notusablehere;
    override public void OnUse()
    {
        if (CheckDistanceToKing())
        {
            GameStateMachine.Instance.ChangeToDialogue();
            ConversationManager.Instance.StartConversation(jokeDialogue);
            KingMood.Instance.AddMood(30);
        }
        else
        {
            GameStateMachine.Instance.ChangeToDialogue();
            ConversationManager.Instance.StartConversation(notusablehere);
        }
        
    }
    bool CheckDistanceToKing()
    {
        if (Vector3.Distance(KING.position, Player.Instance.transform.position) < 4)
            return true;
        return false;
    }
}