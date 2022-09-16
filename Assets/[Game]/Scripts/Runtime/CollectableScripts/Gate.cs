using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using HCB.IncrimantalIdleSystem;
using UnityEngine;

public class Gate : IdleStatObjectBase
{
   private void OnTriggerEnter(Collider other)
   {
      PlayerController player = other.GetComponent<PlayerController>();
      
      if(player != null)
         GameManager.Instance.PlayerData.CurrencyData[HCB.ExchangeType.Coin] += (float)IdleStat.CurrentValue;
      
   }


   public override void UpdateStat(string id)
   {
      throw new NotImplementedException();
   }
}
