using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Intro : MonoBehaviour
{
    [SerializeField] NPCConversation part1;
    bool part1done = false;
    [SerializeField] NPCConversation part2;
    bool part2done = false;
    [SerializeField] Camera IntroCam;
    [SerializeField] PlayableDirector HatAnim;
    bool introDone = false;
    [SerializeField] Transform hat;
    private void Start()
    {
        if(!introDone)
            StartCoroutine(IntroC());
    }

    private IEnumerator IntroC()
    {
        hat.localScale = new Vector3(.01f, .01f, .01f);
        yield return new WaitForSeconds(.1f);
        GameStateMachine.Instance.ChangeToPerformance();
        IntroCam.enabled = true;
        ConversationManager.Instance.StartConversation(part1);
        while (!part1done)
            yield return null;
        HatAnim.Play();
        yield return new WaitForFixedUpdate();        
        yield return new WaitForSeconds(1.5f);
        hat.localScale = Vector3.one;
        ConversationManager.Instance.StartConversation(part2);        
        while (!part2done)
            yield return null;
        
        IntroCam.enabled = false;
        GameStateMachine.Instance.ChangeToGameplay();
        GameStateMachine.Instance.NextState();
        introDone = true;
    }
    public void PartOneEnd() { part1done = true; }
    public void PartTwoEnd() { part2done = true; }
}
