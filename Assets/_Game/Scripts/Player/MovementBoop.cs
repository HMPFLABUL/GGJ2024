using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MovementBoop : MonoBehaviour
{
    Sequence boop;
    [SerializeField] Vector3 top = new Vector3(.4f,.4f,.4f);
    [SerializeField] Vector3 bottom = new Vector3(.45f, .35f, .4f);
    [SerializeField] float boopSpeed = .2f;
    bool started = false;

    private void Awake()
    {
        SetupBoop();
        transform.DOScale(top, 0.01f);
        
    }

    private void SetupBoop()
    {
        boop = DOTween.Sequence();
        boop.Append(transform.DOScale(top, boopSpeed));
        boop.Append(transform.DOScale(bottom, boopSpeed));
        boop.SetLoops(-1);
        boop.Pause();
    }

    private void Update()
    {
        if (GameStateMachine.Instance.state != GameStateMachine.GameState.Gameplay)
        {
            StopBoop();
            return;
        }
        bool check = Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0;
        if (!started && check)
        {
            StartBoop();
        }
        if(started && !check)
        {
            StopBoop();
        }

    }

    private void StopBoop()
    {
        started = false;
        boop.Pause();
        transform.DOScale(top, 0.01f);

    }

    private void StartBoop()
    {
        started = true;
        boop.Restart();
        boop.Play();
    }
}
