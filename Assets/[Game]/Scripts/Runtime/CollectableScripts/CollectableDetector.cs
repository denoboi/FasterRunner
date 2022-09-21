using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HCB.CollectableSystem;
using HCB.PoolingSystem;
using HCB.SplineMovementSystem;
using TMPro;
using UnityEngine;

public class CollectableDetector : Collector
{
   public List<Transform> CollectablePoints = new List<Transform>();
   private const float POSITION_TWEEN_DURATION = 0.2f;
   private List<ICollectable> _collectables = new List<ICollectable>();
   public bool IsAi;
   private SplineCharacterClampController _splineCharacterClampController;
   
   public SplineCharacterClampController SplineCharacterClampController { get { return _splineCharacterClampController == null ? _splineCharacterClampController = GetComponentInChildren<SplineCharacterClampController>() : _splineCharacterClampController; } }
   
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

      if (IsAi)
         return;
      SecondCountdown.Instance.CountDownTime += 1;
      // CreateFloatingText("Freeze "  + "+1", Color.white, 0.5f);
   }
   
   // public void CreateFloatingText(string s, Color color, float delay)
   // {
   //    TextMeshPro text = PoolingSystem.Instance.InstantiateAPS("text", SplineCharacterClampController.gameObject.transform.position + Vector3.up * 6).GetComponent<TextMeshPro>();
   //    text.transform.LookAt(Camera.main.transform);
   //    text.SetText(s);
   //    text.DOFade(1, 0);
   //    text.color = color;
   //    text.transform.DOMoveY(text.transform.position.z + 6f, delay);
   //    text.DOFade(0, delay / 2)
   //       .SetDelay(delay / 2)
   //       .OnComplete(() => PoolingSystem.Instance.DestroyAPS(text.gameObject));
   // }

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
