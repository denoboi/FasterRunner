using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownGate : MonoBehaviour
{
   private void OnEnable()
   {
     EventManager.OnFirstCountDownEnded.AddListener(DestroyGate);
   }

   private void OnDisable()
   {
      EventManager.OnFirstCountDownEnded.RemoveListener(DestroyGate);
   }

   void DestroyGate()
   {
      gameObject.SetActive(false);
   }
}
