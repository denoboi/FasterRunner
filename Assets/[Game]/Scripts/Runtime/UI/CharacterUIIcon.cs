using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Utilities;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterUIIcon : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField] private List<RoadLayout> RoadLayouts = new List<RoadLayout>();

    private const float MIN_VAL2 = 2000;
    private const float MAX_VAL2 = 4200;

    private const float MINVAL = 0;
    private const float MAXVAL = 2000;

    private const float MIN_VAL3 = 4200;
    private const float MAX_VAL3 = 5600;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        // transform.position = new Vector3(transform.position.x, StartPos.position.y);
    }

    private void Update()
    {
        if (DistanceCheck.Instance == null)
            return;
        CheckDistance();
    }

    private void DistanceToMove(Transform startPoint, Transform endPoint, float minValue,
        float maxValue)
    {
      
        float distanceToGo = HCBUtilities.Remap(DistanceCheck.Instance.CurrentDistance, minValue,
            maxValue, startPoint.position.x, endPoint.position.x);
        
        
        Vector3 characterPosition = _rectTransform.position;
        //characterPosition.x = Mathf.Lerp(_rectTransform.position.x, distanceToGo, Time.deltaTime * 10);
        characterPosition.y = startPoint.position.y;
        characterPosition.x = distanceToGo;
        _rectTransform.position = characterPosition;
    }

    private void CheckDistance()
    {
        float minValue = MINVAL;
        float maxValue = MAXVAL;
        
        Transform startPoint = RoadLayouts[0].StartPoint;
        Transform endPoint = RoadLayouts[0].EndPoint;


        if (DistanceCheck.Instance.CurrentDistance >= MIN_VAL2 && DistanceCheck.Instance.CurrentDistance < MAX_VAL2)
        {
            minValue = MIN_VAL2;
            maxValue = MAX_VAL2;

          
            startPoint = RoadLayouts[1].StartPoint;
            endPoint = RoadLayouts[1].EndPoint;

       
        }

        else if (DistanceCheck.Instance.CurrentDistance >= MIN_VAL3 &&
                 DistanceCheck.Instance.CurrentDistance < MAX_VAL3)
        {
            minValue = MIN_VAL3;
            maxValue = MAX_VAL3;

           
            startPoint = RoadLayouts[2].StartPoint;
            endPoint = RoadLayouts[2].EndPoint;
        }


        DistanceToMove(startPoint, endPoint, minValue, maxValue);
    }
}