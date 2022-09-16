using System;
using System.Collections;
using System.Collections.Generic;
using HCB.IncrimantalIdleSystem;
using HCB.IncrimantalIdleSystem.Examples;
using UnityEngine;

public class IncomeUpgrade : IdleUpgradeButton
{
    public static IncomeUpgrade Instance;

    private void Awake()
    {
        Instance = this;
    }
    
}
