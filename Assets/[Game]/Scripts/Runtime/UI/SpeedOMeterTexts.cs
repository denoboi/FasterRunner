using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using HCB.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedOMeterTexts : MonoBehaviour
{
    public static SpeedOMeterTexts Instance;
    public List<TextMeshProUGUI> TextMeshProUGUIS = new List<TextMeshProUGUI>();
    public const float SPEED_MULTIPLIER = 0.15f;


    private void Awake()
    {
        Instance = this;
    }

    
    private void OnEnable()
    {
        EventManager.OnClick.AddListener(UpdateTexts); 
        SceneController.Instance.OnSceneLoaded.AddListener(SetInitialText);
    }
    
    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnClick.RemoveListener(UpdateTexts);
        SceneController.Instance.OnSceneLoaded.RemoveListener(SetInitialText);

    }
    
    
    
    void UpdateTexts()
    {
        for (int i = 0; i < TextMeshProUGUIS.Count; i++)
        {
          
            
            TextMeshProUGUIS[i].text = ((int)(ClickManager.Instance.Speed * i * SPEED_MULTIPLIER)).ToString();
            
        }
    }

    void SetInitialText()
    {
        for (int i = 0; i < TextMeshProUGUIS.Count; i++)
        {
           
            
            TextMeshProUGUIS[i].text = i.ToString();
            
        } 
    }
    
}
