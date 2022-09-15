using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FingerTap : MonoBehaviour
{
    private Tween _punchTween;

    private void OnEnable()
    {
        EventManager.OnFirstCountDownEnded.AddListener(DestroyObject);
    }

    private void OnDisable()
    {
       EventManager.OnFirstCountDownEnded.RemoveListener(DestroyObject);
    }

    void Start()
    {
        FingerPunch();
    }

    // Update is called once per frame
    void FingerPunch()
    {
        if (_punchTween != null) //to prevent punchtween too big 
            _punchTween.Kill(true);
        _punchTween = transform.DOPunchScale(Vector3.one * 0.03f, 0.2f).SetLoops(-1,LoopType.Restart);
    }

    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
