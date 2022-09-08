using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using UnityEngine;
using UnityEngine.UI;

public class SpeedHandler : MonoBehaviour
{
    public Slider Slider;
    public SpeedUpgraderClicker SpeedUpgraderClicker;

    

    private void OnSceneLoad()
    {
 
        Slider = GetComponent<Slider>();
        SpeedUpgraderClicker = FindObjectOfType<SpeedUpgraderClicker>(); 
        //Slider.maxValue = SpeedUpgraderClicker.MaxSpeed;
        //Slider.minValue = 0;

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
        if (Slider == null)
            return;

        Slider.value = SpeedUpgraderClicker.Speed;
    }
}
