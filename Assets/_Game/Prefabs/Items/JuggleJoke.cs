using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class JuggleJoke : InventoryItem
{
    [SerializeField] PlayableDirector jugglingCutscene;
    [SerializeField] NPCConversation praise;
    [SerializeField] NPCConversation notusablehere;
    [SerializeField] List<InventoryItem> apples;
    [SerializeField] Transform KING;
    override public void OnUse()
    {
        if (CheckDistanceToKing())
        {
            StartCoroutine(OnUseE());
        }
        else
        {
            ConversationManager.Instance.StartConversation(notusablehere);
        }
    }
    bool CheckDistanceToKing()
    {
        if (Vector3.Distance(KING.position, Player.Instance.transform.position) < 4)
            return true;
        return false;
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
