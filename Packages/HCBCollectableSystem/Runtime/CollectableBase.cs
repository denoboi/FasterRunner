﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCB.Core;

namespace HCB.CollectableSystem
{
    public abstract class CollectableBase : MonoBehaviour, ICollectable
    {
      
        public GameObject CollectEffectPrefab;
        public bool IsCollected { get; set; }
        public Transform T => transform;

        public virtual void Collect(Collector collector)
        {
            if (IsCollected)
                return;
            IsCollected = true;
            if (CollectEffectPrefab != null)
            {
                
                ParticleSystem collectEffect = Instantiate(CollectEffectPrefab, transform.position, transform.rotation).GetComponent<ParticleSystem>();
                var main = collectEffect.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
            }
            HapticManager.Haptic(HapticTypes.RigidImpact);
        }
    }
}
