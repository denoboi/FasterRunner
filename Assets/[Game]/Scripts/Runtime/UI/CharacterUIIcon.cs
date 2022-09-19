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

       // transform.position = new Vector3(transform.position.x, StartPos.position.y);
    }

    private void Update()
    {
       DistanceToMove(2000);
    }

    private void DistanceToMove(float currentTotalDistance)
    {
        float distanceToGo = HCBUtilities.Remap(DistanceCheck.Instance.CurrentDistance, 0,
            currentTotalDistance, StartPos.position.x, FinishPos.position.x);
        
        Vector3 characterPosition = _rectTransform.position;
        characterPosition.x = Mathf.Lerp(_rectTransform.position.x, distanceToGo, Time.deltaTime * 10);

        _rectTransform.position = characterPosition;
        
        
    }

    
}
