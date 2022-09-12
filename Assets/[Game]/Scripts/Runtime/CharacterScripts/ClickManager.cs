
using System;
using HCB.Core;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
   public static ClickManager Instance;
   private float _clickCount;
   private float _speed = 1;

   public float Speed { get; set; }
   public float SpeedIncrease { get; set; }

   private bool _isSpeedUpgrading = true;
 
   private void Awake()
   {
      Instance = this;
   }
   
   private void OnEnable()
   {
      EventManager.OnCountDownEnded.AddListener(OnCountDownEnded); //when first countdown ends, stop speed upgrading
   }

   private void OnDisable()
   {
      if (Managers.Instance == null)
         return;
      EventManager.OnCountDownEnded.RemoveListener(OnCountDownEnded);
   }

   
   private void Update()
   {
      UpgradeSpeed();
   }

   void OnCountDownEnded()
   {
      _isSpeedUpgrading = false;
   }


   void UpgradeSpeed()
   {
      if(!_isSpeedUpgrading)
         return;
      if (Input.GetMouseButtonDown(0))
      {
         Speed += 1;
         EventManager.OnClick.Invoke(); //To update texts.
      }
   }

  
   
   
}
