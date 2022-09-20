using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using HCB.Utilities;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIIcon : MonoBehaviour
{
    public Image CharacterImage;
    private RectTransform _rectTransform;

    private DistanceCheck _distanceCheck;

    [SerializeField] private List<RoadLayout> RoadLayouts = new List<RoadLayout>();

    private const float MIN_VAL2 = 2000;
    private const float MAX_VAL2 = 4200;

    private const float MINVAL = 0;
    private const float MAXVAL = 2000;

    private const float MIN_VAL3 = 4200;
    private const float MAX_VAL3 = 5600;

    private void OnEnable()
    {
        LevelManager.Instance.OnLevelFinish.AddListener(()=> Destroy(gameObject));
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnLevelFinish.RemoveListener(()=> Destroy(gameObject));

    }


    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        // transform.position = new Vector3(transform.position.x, StartPos.position.y);
    }

    private void Update()
    {
        if (_distanceCheck == null)
            return;
        CheckDistance();
    }

    public void Setup(DistanceCheck distanceCheck, Sprite icon)
    {
        _distanceCheck = distanceCheck;
        CharacterImage.sprite = icon;
    }

    private void DistanceToMove(Transform startPoint, Transform endPoint, float minValue,
        float maxValue)
    {
      
        float distanceToGo = HCBUtilities.Remap(_distanceCheck.CurrentDistance, minValue,
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


        if (_distanceCheck.CurrentDistance >= MIN_VAL2 && _distanceCheck.CurrentDistance < MAX_VAL2)
        {
            minValue = MIN_VAL2;
            maxValue = MAX_VAL2;

          
            startPoint = RoadLayouts[1].StartPoint;
            endPoint = RoadLayouts[1].EndPoint;

       
        }

        else if (_distanceCheck.CurrentDistance >= MIN_VAL3 &&
                 _distanceCheck.CurrentDistance < MAX_VAL3)
        {
            minValue = MIN_VAL3;
            maxValue = MAX_VAL3;

           
            startPoint = RoadLayouts[2].StartPoint;
            endPoint = RoadLayouts[2].EndPoint;
        }


        DistanceToMove(startPoint, endPoint, minValue, maxValue);
    }
}