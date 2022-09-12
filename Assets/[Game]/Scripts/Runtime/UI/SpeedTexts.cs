using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTexts : MonoBehaviour
{
    public List<TextMeshProUGUI> TextMeshProUGUIS = new List<TextMeshProUGUI>();
    
    private void OnEnable()
    {
        EventManager.OnClick.AddListener(UpdateTexts); 
    }
    
    private void OnDisable()
    {
        EventManager.OnClick.RemoveListener(UpdateTexts);
    }
    
    void UpdateTexts()
    {
        for (int i = 0; i < TextMeshProUGUIS.Count; i++)
        {
            TextMeshProUGUIS[i].text = (ClickManager.Instance.Speed + i).ToString();
        }
    }
    
}
