using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

namespace Game.Dialogues
{
    public class KingDialogue : NPC
    {
        [SerializeField] NPCConversation KingDialogue0;
        private void OnMouseDown()
        {
            if (!CheckDistanceToPlayer())
                return;
            if (GameStateMachine.Instance.state == GameStateMachine.GameState.Gameplay)
            {
                ConversationManager.Instance.StartConversation(KingDialogue0);
                ChangeStateToDialogue();
            }
        }

       
    }
}
