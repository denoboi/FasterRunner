using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using UnityEngine;
using UnityEngine.UI;

public class SpeedHandler : MonoBehaviour
{
    public Slider Slider;
    public PlayerController PlayerController;

    private void OnSceneLoad()
    {
        Slider = GetComponent<Slider>();
        PlayerController = FindObjectOfType<PlayerController>();
    }

    private void OnEnable()
    {
        //SceneController.Instance.OnSceneLoaded.AddListener(OnSceneLoad);
        EventManager.OnFirstCountDownEnded.AddListener(OnSceneLoad);
    }


    private void OnDisable()
    {
        EventManager.OnFirstCountDownEnded.AddListener(OnSceneLoad);
        //SceneController.Instance.OnSceneLoaded.RemoveListener(OnSceneLoad);
    }


    private void Update()
    {
        UpdateSliderValue();
    }

    void UpdateSliderValue()
    {
        if (Slider == null)
            return;

        //Slider.value = PlayerController.RunnerSpeed();
    }
}