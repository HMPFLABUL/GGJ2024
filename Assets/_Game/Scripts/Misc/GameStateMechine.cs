using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        state = GameState.Gameplay;
        //NextState();
    }
    [SerializeField] public enum GameState
    {
        Gameplay,
        Dialogue,
        Inventory,
        Performance,
    }
    

    public GameState state;

    IEnumerator GameplayState()
    {
        Debug.Log("Gameplay: Enter");
        while (state == GameState.Gameplay)
        {
            yield return 0;
        }
        Debug.Log("Gameplay: Exit");
        NextState();
    }

    IEnumerator DialogueState()
    {
        CursorManager.Instance.SetDefaultCursor();
        Debug.Log("Dialogue: Enter");
        while (state == GameState.Dialogue)
        {
            yield return 0;
        }
        Debug.Log("Dialogue: Exit");
        NextState();
    }

    IEnumerator InventoryState()
    {
        Debug.Log("Inventory: Enter");
        while (state == GameState.Inventory)
        {
            yield return 0;
        }
        Debug.Log("Inventory: Exit");
    }
    IEnumerator PerformanceState()
    {
        Debug.Log("Performance: Enter");
        while (state == GameState.Performance)
        {
            yield return 0;
        }
        Debug.Log("Performance: Exit");
    }


    public void NextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    public void ChangeState(GameState state)
    {
        this.state = state;
    }
    public void ChangeToGameplay()
    {
        state = GameState.Gameplay;
    }
    public void ChangeToDialogue()
    {
        state = GameState.Dialogue;
    }
    public void ChangeToInventory()
    {
        state = GameState.Inventory;
    }
    public void ChangeToPerformance()
    {
        state = GameState.Performance;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}