
using System;
using HCB.Core;
using HCB.IncrimantalIdleSystem;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
   public static ClickManager Instance;
   
  

   public float Speed { get; set; }
 

   private bool _isSpeedUpgrading = true;
 
   private void Awake()
   {
      Instance = this;
   }
   
   private void OnEnable()
   {
      EventManager.OnFirstCountDownEnded.AddListener(OnCountDownEnded); //when first countdown ends, stop speed upgrading
   }

   private void OnDisable()
   {
      if (Managers.Instance == null)
         return;
      EventManager.OnFirstCountDownEnded.RemoveListener(OnCountDownEnded);
   }
   
   private void Update()
   {
      UpgradeSpeed();
   }

   void OnCountDownEnded()
   {
      _isSpeedUpgrading = false; //countdown bittiginde speed upgrade duracak.
   }


   void UpgradeSpeed()
   {
      if(!_isSpeedUpgrading)
         return;
      if (Input.GetMouseButtonDown(0))
      {
         Speed += (float)ClickUpgrade.Instance.IdleStat.CurrentValue;
         EventManager.OnClick.Invoke(); //To update texts.
      }
   }
   
  

  
   
   
}
