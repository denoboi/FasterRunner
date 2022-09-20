using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using UnityEngine;
using Random = UnityEngine.Random;

public class SuperAiController : MonoBehaviour
{
   private Runner _runner;
   public Runner Runner => _runner == null ? _runner = GetComponent<Runner>() : _runner;

   private void OnEnable()
   {
      EventManager.OnSupAIInstantiated.AddListener(Move);
   }

   private void OnDisable()
   {
      EventManager.OnSupAIInstantiated.RemoveListener(Move);
   }

   void Move()
   {
      Runner.followSpeed = Random.Range(50f, 500f);
   }
   
}
