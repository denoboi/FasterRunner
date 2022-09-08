using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        foreach (var text in TextMeshProUGUIS)
        {
            text.text = ClickManager.Instance.Speed.ToString();
        }
    }


}
