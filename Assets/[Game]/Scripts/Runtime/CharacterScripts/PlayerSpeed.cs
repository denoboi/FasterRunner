using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
   private Runner _runner;
   public Runner Runner => _runner == null ? _runner = GetComponent<Runner>() : _runner;
   
   

   private float _speedMultiplier = 5f;
   private float _speedDenominator = 0.2f;

   public float SpeedMultiplier
   {
      get => _speedMultiplier;
      private set
      {
         
            _speedMultiplier = value;
      } 
   }

   public float SpeedDenominator
   {
      get
      {
         return _speedDenominator;
      }

      set
      {
         _speedDenominator = value;
      }
   }


   private void Update()
   {
      SpeedIncrease();
      SpeedDecrease();
   }


   private void SpeedIncrease()
   {
      if (!Input.GetMouseButtonDown(0)) return;
      Runner.followSpeed += SpeedMultiplier * Time.deltaTime;
      Debug.Log(Runner.followSpeed);
   }

   private void SpeedDecrease()
   {
      Runner.followSpeed -= SpeedDenominator *  Time.deltaTime;
      if (Runner.followSpeed <= 0)
         Runner.followSpeed = 0;
      
   }

   public float RunnerSpeed()
   {
      float speed = Runner.followSpeed;
      return speed;
   }
   
   
}
