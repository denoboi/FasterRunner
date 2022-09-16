using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using ntw.CurvedTextMeshPro;
using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
using Vector3 = UnityEngine.Vector3;

public class ClickTexts : MonoBehaviour
{
    
    public TextMeshProUGUI TextMeshProUGUI;
    private const int TEXT_COUNT = 6;

    private string ScaleTweenId;
    private string FadeTweenId;

    private void Awake()
    {
        ScaleTweenId = GetInstanceID() + "ScaleTweenId";
        FadeTweenId = GetInstanceID() + "FadeTweenId";

    }

    private void OnDestroy()
    {
        DOTween.Kill(ScaleTweenId);
        DOTween.Kill(FadeTweenId);
    }

    public void Initialize()
    {
        Color color = TextMeshProUGUI.color;
        color.a = 0;
        TextMeshProUGUI.color = color;
        
        SetText();
        TextProOnACircle textProOnACircle = gameObject.AddComponent<TextProOnACircle>();
        textProOnACircle.ParametersHaveChanged();
        
        ScaleTween();
       
        FadeTween(1,0.1f, 0,()=>FadeTween(0,1f, 0, ()=> Destroy(gameObject)));

    }
    
    private void SetText()
    {
        string text = "";
        for (int i = 0; i < TEXT_COUNT; i++)
        {
            text += "+" + ClickUpgrade.Instance.IdleStat.CurrentValue; //bonbaa
        }

        TextMeshProUGUI.text = text;
    }

   

    private void ScaleTween()
    {
        DOTween.Kill(ScaleTweenId);
        transform.DOScale(Vector3.one * 2, 1).SetId(ScaleTweenId);
    }
    
    private void FadeTween(float endValue, float duration, float delay, Action onComplete = null)
    {
        
        DOTween.Kill(FadeTweenId);
        TextMeshProUGUI.DOFade(endValue, duration).SetDelay(delay).SetId(FadeTweenId).OnComplete(()=> onComplete ?.Invoke());
    }

}
