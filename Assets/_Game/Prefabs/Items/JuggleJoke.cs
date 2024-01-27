using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class JuggleJoke : InventoryItem
{
    [SerializeField] PlayableDirector jugglingCutscene;
    [SerializeField] NPCConversation praise;
    [SerializeField] List<InventoryItem> apples;
    [SerializeField] Camera main;
    override public void OnUse()
    {
        StartCoroutine(OnUseE());
    }
    IEnumerator OnUseE()
    {
        GameStateMachine.Instance.ChangeState(GameStateMachine.GameState.Performance);
        RemoveApples();
        jugglingCutscene.Play();
        yield return new WaitForSeconds(7f);
        ConversationManager.Instance.StartConversation(praise);
        InventoryManager.Instance.RemoveItem(this);

    } 
    void RemoveApples()
    {
        for (int i = 0; i < apples.Count; i++)
        {
            InventoryManager.Instance.RemoveItem(apples[i]);
        }
    }
}
