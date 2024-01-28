using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingMood : MonoBehaviour
{
    [SerializeField] Slider moodSlider;
    [SerializeField] Image fillImage;
    [SerializeField] float tickTime = 2f;
    float tickTimer = 0;
    List<Image> allImages;
    [SerializeField] SceneLoad sceneLoader;

    bool off = false;
    public static KingMood Instance { get; private set; }
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
        allImages = new List<Image>(GetComponentsInChildren<Image>());
    }
    private void Update()
    {
        if (!off && GameStateMachine.Instance.state != GameStateMachine.GameState.Gameplay)
        {
            DisableAllImages();
            off = true;
            return;
        }
        else if (off && GameStateMachine.Instance.state == GameStateMachine.GameState.Gameplay)
        {
            EnableAllImages();
            off = false;
        }

        tickTimer += Time.deltaTime;
        if (tickTimer > tickTime)
        {
            tickTimer = 0;
            Tick();
        }
    }

    private void EnableAllImages()
    {
        for (int i = 0; i < allImages.Count; i++)
        {
            allImages[i].enabled = true;
        }
    }

    private void DisableAllImages()
    {
        for (int i = 0; i < allImages.Count; i++)
        {
            allImages[i].enabled = false;
        }
    }


    private void Tick()
    {
        moodSlider.value -= 1;
        fillImage.color = new Color(fillImage.color.r, moodSlider.value / 100f, fillImage.color.b);

        if(moodSlider.value <= 0)
        {
            GameStateMachine.Instance.ChangeToPerformance();
            sceneLoader.LoadEnd();
        }
    }

    public void AddMood(int amount)
    {
        moodSlider.value += amount;
        fillImage.color = new Color(fillImage.color.r, moodSlider.value / 100f, fillImage.color.b);
    }
}
