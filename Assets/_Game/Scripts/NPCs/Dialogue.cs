using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : ENTITY
{
    [SerializeField] NPCConversation[] Dialogues;
    int currentDialogue = 0;
    private void OnMouseDown()
    {
        if (!CheckDistanceToPlayer())
            return;
        if (GameStateMachine.Instance.state == GameStateMachine.GameState.Gameplay)
        {
            Use();
        }
    }
    public void Use()
    {
        if (Dialogues != null)
        {
            ConversationManager.Instance.StartConversation(Dialogues[currentDialogue]);
            ChangeStateToDialogue();
        }
    }
    public void NextDialogue()
    {
        currentDialogue++;
    }
    public void SetDialogue(int i)
    {
        currentDialogue = i;
    }
}
