
using System;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
   public static ClickManager Instance;
   private float _clickCount;
   private float _speed = 1;

   public float Speed { get; set; }
   public float SpeedIncrease { get; set; }
   private void Awake()
   {
      Instance = this;
   }
   
   private void Update()
   {
      UpgradeSpeed();
   }


   void UpgradeSpeed()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Speed += 1;
         EventManager.OnClick.Invoke(); //To update texts.
      }
   }

  
   
   
}
