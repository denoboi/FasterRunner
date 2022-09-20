using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HCB.CollectableSystem;
using UnityEngine;

public class CollectableDetector : Collector
{
   public List<Transform> CollectablePoints = new List<Transform>();
   private const float POSITION_TWEEN_DURATION = 0.2f;
   private List<ICollectable> _collectables = new List<ICollectable>();

   protected override void OnCollect(ICollectable collectable)
   {
      if (_collectables.Contains(collectable))
         return;
      base.OnCollect(collectable);
      _collectables.Add(collectable);
      
      

      int collectablePointIndex = Mathf.Min(CollectablePoints.Count-1 , _collectables.Count-1);

      Transform parent = CollectablePoints[collectablePointIndex];
      collectable.T.SetParent(parent);
      
      SetPosition(collectable.T, Vector3.zero);
      SetScale(collectable.T, Vector3.one * 0.1f);
   }

   private void SetPosition(Transform targetTransform, Vector3 endValue)
   {
      string tweenId = targetTransform.gameObject.GetInstanceID() + "PositionTweenId";
      DOTween.Kill(tweenId);
      targetTransform.DOLocalMove(endValue, POSITION_TWEEN_DURATION).SetId(tweenId).SetEase(Ease.Linear);
      
   }
   
   private void SetScale(Transform targetTransform, Vector3 endValue)
   {
      string tweenId = targetTransform.gameObject.GetInstanceID() + "ScaleTweenId";
      DOTween.Kill(tweenId);
      targetTransform.DOScale(endValue, POSITION_TWEEN_DURATION).SetId(tweenId).SetEase(Ease.Linear);
      
   }
}
