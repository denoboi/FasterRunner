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
        EventManager.OnClick.RemoveListener(UpdateTexts);
        SceneController.Instance.OnSceneLoaded.RemoveListener(SetInitialText);

    }
    
    
    
    void UpdateTexts()
    {
        for (int i = 0; i < TextMeshProUGUIS.Count; i++)
        {
          
            
            TextMeshProUGUIS[i].text = (ClickManager.Instance.Speed * i).ToString();
            
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
