using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using UnityEngine;
using UnityEngine.UI;

public class SpeedHandler : MonoBehaviour
{
    public Slider Slider;
    public PlayerSpeed PlayerSpeed;
    
    private void OnSceneLoad()
    {
        Slider = GetComponent<Slider>();
        PlayerSpeed = FindObjectOfType<PlayerSpeed>();
    }

    private void OnEnable()
    {
        SceneController.Instance.OnSceneLoaded.AddListener(OnSceneLoad);
    }


    private void OnDisable()
    {
        SceneController.Instance.OnSceneLoaded.RemoveListener(OnSceneLoad);
    }


    private void Update()
    {
        UpdateSliderValue();
    }

    void UpdateSliderValue()
    {
        if (Slider == null)
            return;

       
        // if (Slider.value > 4)
        // {
        //     PlayerSpeed.SpeedDenominator += 0.1f;
        // }
        // else
            Slider.value = PlayerSpeed.RunnerSpeed();

    }
}
