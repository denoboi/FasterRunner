using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
   private float _speed;

   private void Start()
   {
      throw new NotImplementedException();
   }

   private void Update()
   {
      throw new NotImplementedException();
   }


   private void SpeedIncrease()
   {
      if (Input.GetMouseButtonDown(0))
      {
         _speed++;
         Debug.Log(_speed);
      }
   }
   
   
}
