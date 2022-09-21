using System;
using HCB.Core;
using HCB.IncrimantalIdleSystem;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private bool _isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();
        Debug.Log("Collide " + other);
        
        if (player == null)
            return;
        if (_isTriggered)
            return;
        
        _isTriggered = true;
        HapticManager.Haptic(HapticTypes.RigidImpact);
        EventManager.OnMoneyEarned.Invoke();
        GameManager.Instance.PlayerData.CurrencyData[HCB.ExchangeType.Coin] +=
            IncomeUpgrade.Instance.IdleStat.CurrentValue;
        HCB.Core.EventManager.OnPlayerDataChange.Invoke();
    }
}