using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TravelPoint : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Image fade; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Travel());
        }
    }

    private IEnumerator Travel()
    {
        GameStateMachine.Instance.ChangeState(GameStateMachine.GameState.Dialogue);
        fade.DOFade(1, .33f);
        yield return new WaitForSeconds(.33f);
        Player.Instance.transform.position = spawnPoint.position;
        Player.Instance.transform.rotation = spawnPoint.rotation;
        yield return new WaitForSeconds(.33f);
        fade.DOFade(0, .33f);
        yield return new WaitForSeconds(.33f);
        GameStateMachine.Instance.ChangeState(GameStateMachine.GameState.Gameplay);

    }
}
