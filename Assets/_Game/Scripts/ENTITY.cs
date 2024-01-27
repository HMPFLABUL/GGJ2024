using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENTITY : MonoBehaviour
{
    protected bool CheckDistanceToPlayer()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) < 4)
            return true;
        return false;
    }
    protected bool CheckForGameplayState()
    {
        if (GameStateMachine.Instance.state == GameStateMachine.GameState.Gameplay)
            return true;
        return false;
    }
    protected static void ChangeStateToDialogue()
    {
        GameStateMachine.Instance.ChangeState(GameStateMachine.GameState.Dialogue);
    }
}
