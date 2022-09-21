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
    private SplineCharacterClampController _splineCharacterClampController;
    public SplineCharacterClampController SplineCharacterClampController => _splineCharacterClampController == null ? _splineCharacterClampController = GetComponentInChildren<SplineCharacterClampController>() : _splineCharacterClampController;

    [Space]
    [Header("AIRightLeftSettings")]
    [SerializeField] private float _leanSpeed;
    [SerializeField] [Range(0f, 20f)] private float timeToMove;
    
    private float _xPos;
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
        if (GameManager.Instance.IsStageCompleted)
            return;
    
        //surekli timer guncelliyoruz.
        _timer += Time.deltaTime;
    
        Graphic.transform.localPosition = Vector3.Lerp(Graphic.transform.localPosition, _desiredPos, Time.deltaTime * _leanSpeed);
            
        ClampPosition();
        
        if (_timer >= timeToMove)
        {
           
            // if (Vector3.Distance(Graphic.transform.localPosition, _desiredPos) <= 0.01f)
            {
                _xPos = Random.Range(-SplineCharacterClampController.ClampData.MovementWidth, SplineCharacterClampController.ClampData.MovementWidth);
                _desiredPos = new Vector3(_xPos, Graphic.transform.localPosition.y, Graphic.transform.localPosition.z);
            }
    
            _timer = 0;
        }
    }

    void ClampPosition()
    {
        Vector3 clampPosition = Graphic.transform.position; //dunya uzerindeki pozisyonunu clamplememiz gerek.
        clampPosition.x = Mathf.Clamp(clampPosition.x, -SplineCharacterClampController.ClampData.MovementWidth / 2,
            SplineCharacterClampController.ClampData.MovementWidth / 2);

        Graphic.transform.position = clampPosition;
    }
}
