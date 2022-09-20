using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyImageTween : MonoBehaviour
{
    private Tween _punchTween;

    private void OnEnable()
    {
        EventManager.OnMoneyEarned.AddListener(MoneyPunch);
    }

    private void OnDisable()
    {
        EventManager.OnMoneyEarned.RemoveListener(MoneyPunch);
    }

    void MoneyPunch()
    {
        // DOTween.Complete(_punchTween);
        if (_punchTween != null) //to prevent punchtween
            _punchTween.Kill(true);
        _punchTween = transform.DOPunchScale(Vector3.one * 0.05f, 0.9f);
    }
}
