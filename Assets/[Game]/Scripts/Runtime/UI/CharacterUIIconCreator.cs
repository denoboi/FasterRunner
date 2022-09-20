using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIIconCreator : MonoBehaviour
{
   public CharacterUIIcon CharacterUIIconTemplate;
   private void OnEnable()
   {
      EventManager.OnCharacterSpawned.AddListener(CreateIcon);
   }

   private void OnDisable()
   {
      EventManager.OnCharacterSpawned.RemoveListener(CreateIcon);

   }

   private void CreateIcon(DistanceCheck distanceCheck, Sprite icon)
   {
      CharacterUIIcon characterUIIcon = Instantiate(CharacterUIIconTemplate, CharacterUIIconTemplate.transform.parent);
      characterUIIcon.gameObject.SetActive(true);
      characterUIIcon.Setup(distanceCheck, icon);
   }
}
