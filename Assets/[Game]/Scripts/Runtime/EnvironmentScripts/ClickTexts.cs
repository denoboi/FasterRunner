using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickTexts : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProUGUI;
    
   
    // private void OnDisable()
    // {
    //     EventManager.OnFirstCountDownEnded.RemoveListener(DestroyObject);
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TextMeshProUGUI.text = "+1 +1 +1 +1 +1";
        }
    }

    private void DestroyObject()
    {
        
    }
    
    
}
