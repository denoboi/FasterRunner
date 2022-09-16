using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTextSpawner : MonoBehaviour
{
   public GameObject ClickPrefab;
   private void OnEnable()
   {
      EventManager.OnClick.AddListener(SpawnTexts);
   }

   private void OnDisable()
   {
      EventManager.OnClick.RemoveListener(SpawnTexts);
   }

   void SpawnTexts()
   {
      Vector3 spawnPos = (Input.mousePosition);
     GameObject clickTextObject=  Instantiate(ClickPrefab, spawnPos, Quaternion.identity, transform);
     
     clickTextObject.GetComponentInChildren<ClickTexts>().Initialize();
   }
}
