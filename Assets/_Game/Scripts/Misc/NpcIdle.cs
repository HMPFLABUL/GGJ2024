using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIdle : MonoBehaviour
{
    Sequence boop;
    Vector3 top;
    Vector3 bottom;
    [SerializeField] float boopSpeed = .6f;
    [SerializeField] float idleDelay = 0f;
    bool started = false;

    private void Awake()
    {
        top = transform.localScale;
        bottom = new Vector3(top.x, .9f * top.y, top.z);
        started = true;
        Invoke("SetupBoop",idleDelay);
    }

    private void SetupBoop()
    {
        boop = DOTween.Sequence();
        boop.Append(transform.DOScale(bottom, boopSpeed));
        boop.Append(transform.DOScale(top, boopSpeed));
        boop.Append(transform.DOScale(bottom, boopSpeed/5));
        boop.Append(transform.DOScale(top, boopSpeed/5));
        boop.Append(transform.DOScale(bottom, boopSpeed / 5));
        boop.Append(transform.DOScale(top, boopSpeed / 5));
        boop.Append(transform.DOScale(top, 3f));
        boop.Append(transform.DOLocalRotate(transform.localEulerAngles + new Vector3(0, 60, 0), boopSpeed));
        boop.Append(transform.DOScale(top, .5f));
        boop.Append(transform.DOLocalRotate(transform.localEulerAngles + new Vector3(0, -60, 0), boopSpeed*2));
        boop.Append(transform.DOScale(top, .5f));
        boop.Append(transform.DOLocalRotate(transform.localEulerAngles + new Vector3(0, 0, 0), boopSpeed));
        boop.Append(transform.DOScale(top, 3f));      
        boop.SetLoops(-1);
        
    }

    private void Update()
    {
        if (started && GameStateMachine.Instance.state != GameStateMachine.GameState.Gameplay)
            StopBoop();
        if (!started && GameStateMachine.Instance.state == GameStateMachine.GameState.Gameplay)
            StartBoop();
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
