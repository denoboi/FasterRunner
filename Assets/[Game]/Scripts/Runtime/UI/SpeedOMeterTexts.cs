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
    private List<float> _multipliers = new List<float>{2, 1.5f, 1.33f, 1.25f, 1.20f};


    private void Awake()
    {
        Instance = this;
    }

    public List<float> Multipliers => _multipliers;
    private void OnEnable()
    {
        EventManager.OnClick.AddListener(UpdateTexts); 
        SceneController.Instance.OnSceneLoaded.AddListener(SetInitialText);
    }
    
    private void OnDisable()
    {
        EventManager.OnClick.RemoveListener(UpdateTexts);
        SceneController.Instance.OnSceneLoaded.RemoveListener(SetInitialText);

    }
    
    
    
    void UpdateTexts()
    {
        for (int i = 1; i < TextMeshProUGUIS.Count; i++)
        {
            int multiplierIndex = Mathf.Min(i - 1, _multipliers.Count - 1);
            float multiplier = _multipliers[multiplierIndex];
            
            TextMeshProUGUIS[i].text = (ClickManager.Instance.Speed * multiplier).ToString();
            
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
