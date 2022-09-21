using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using HCB.SplineMovementSystem;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AIRightLeft : MonoBehaviour
{
    private SplineClampData _clampData;
    public SplineClampData ClampData => _clampData == null ? _clampData = GetComponentInChildren<SplineClampData>() : _clampData;

    [Space]
    [Header("AIRightLeftSettings")]
    [SerializeField] private float _xPos;
    [SerializeField] private float _leanSpeed;
    [SerializeField] [Range(0f, 5f)] private float timeToMove;
    
    private float _timer = 0;
    private Vector3 _desiredPos;
    
    public GameObject Graphic;


    private void Update()
    {
        AIRightLeftMove();
    }

    void AIRightLeftMove()
    {
        if (!LevelManager.Instance.IsLevelStarted)
            return;
        if (!PlayerController.Instance.IsControlable)
            return;
        if (!PlayerController.Instance.Runner.follow)
            return;
    
        //surekli timer guncelliyoruz.
        _timer += Time.deltaTime;
    
        Graphic.transform.localPosition = Vector3.Lerp(Graphic.transform.localPosition, _desiredPos, Time.deltaTime * _leanSpeed);
    
        if (_timer >= timeToMove)
        {
           
            if (Vector3.Distance(Graphic.transform.localPosition, _desiredPos) <= 0.01f)
            {
                _xPos = Random.Range(-ClampData.MovementWidth /2, ClampData.MovementWidth / 2);
                _desiredPos = new Vector3(_xPos, Graphic.transform.localPosition.y, Graphic.transform.localPosition.z);
            }
    
            _timer = 0;
        }
    }
}
