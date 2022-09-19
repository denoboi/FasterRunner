using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Utilities;
using UnityEngine;

public class CharacterUIIcon : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField] private Transform StartPos;
    [SerializeField] private Transform FinishPos;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
       DistanceToMove();
    }

    private void DistanceToMove()
    {
        float distanceToGo = HCBUtilities.Remap(DistanceCheck.Instance.CurrentDistance, 0,
            DistanceCheck.TOTAL_DISTANCE, StartPos.position.x, FinishPos.position.x);
        
        Vector3 characterPosition = _rectTransform.position;
        characterPosition.x = Mathf.Lerp(_rectTransform.position.x, distanceToGo, Time.deltaTime * 10);

        _rectTransform.position = characterPosition;
    }
}
