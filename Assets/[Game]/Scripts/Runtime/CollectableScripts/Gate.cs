using System;

using HCB.Core;
using HCB.IncrimantalIdleSystem;
using UnityEngine;

public class Gate : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      PlayerController player = other.GetComponentInParent<PlayerController>();
      Debug.Log("Collide " + other);
      if (player != null)
      {
         EventManager.OnMoneyEarned.Invoke();
         GameManager.Instance.PlayerData.CurrencyData[HCB.ExchangeType.Coin] += IncomeUpgrade.Instance.IdleStat.CurrentValue;
         HCB.Core.EventManager.OnPlayerDataChange.Invoke();
      }
      
   }


  
}
