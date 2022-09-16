using System;
using System.Collections;
using System.Collections.Generic;
using HCB.IncrimantalIdleSystem.Examples;
using UnityEngine;

public class ClickUpgrade : IdleUpgradeButton
{
   public static ClickUpgrade Instance;

   private void Awake()
   {
      Instance = this;
   }
}
