using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateText : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    private void Start()
    {
        TextMeshPro.text = ((int)IncomeUpgrade.Instance.IdleStat.CurrentValue) + "$";
    }
    
    
}
