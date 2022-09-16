using System;
using System.Collections;
using System.Collections.Generic;
using HCB.CollectableSystem;
using HCB.Utilities;
using UnityEngine;

public class Collectable : CollectableBase
{
   public Renderer VisualRenderer;
   public TrailRenderer TrailRenderer;
   public List<Color> CollectableColors = new List<Color>();

   private MaterialPropertyBlock PropertyBlock;

   private void Awake()
   {
      SetColor();
   }

   private void SetColor()
   {
      CollectableColors.Shuffle();
      Color color = CollectableColors[0];

      PropertyBlock = new MaterialPropertyBlock();
      PropertyBlock.SetColor("_Color", color);
      VisualRenderer.SetPropertyBlock(PropertyBlock);

      TrailRenderer.startColor = color;
      TrailRenderer.endColor = color;
   }
}
