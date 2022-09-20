using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using HCB.Core;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    private Runner _runner;
    public Runner Runner => _runner == null ? _runner = GetComponent<Runner>() : _runner;

    private DistanceCheck _distanceCheck;

    public DistanceCheck DistanceCheck => _distanceCheck == null
        ? _distanceCheck = GetComponentInChildren<DistanceCheck>()
        : _distanceCheck;
    
    
    public Sprite CharacterIcon;
    private bool IsControlable { get; set; }
    
    
    private float _minAiSpeed ;
    private float _maxAISpeed;
    private float _aiSpeed;

    private void Start()
    {
        EventManager.OnCharacterSpawned.Invoke(DistanceCheck, CharacterIcon);

    }

    private void OnEnable()
    {
        LevelManager.Instance.OnLevelStart.AddListener(OnLevelStart);
        EventManager.OnFirstCountDownEnded.AddListener(OnCountDownEnded);
        GameManager.Instance.OnStageSuccess.AddListener(OnLevelStart);
        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        LevelManager.Instance.OnLevelStart.RemoveListener(OnLevelStart);
        EventManager.OnFirstCountDownEnded.RemoveListener(OnCountDownEnded);
        GameManager.Instance.OnStageSuccess.RemoveListener(OnLevelStart);
    }
    
    private void OnLevelStart()
    {
        IsControlable = false;
        Runner.follow = false; //when first countdown player shouldn't move
    }

    private void Update()
    {
        AIFollowSpeed();
    }

    void OnCountDownEnded()
    {
        StartCoroutine(OnCountDownEndedCo());
    }
    IEnumerator OnCountDownEndedCo()
    {
        yield return new WaitForSeconds(0f);
        IsControlable = true;
        Runner.follow = true;
        CalculateAISpeed();
        //MaxSpeed = SpeedMultiplier * (SpeedOMeterTexts.Instance.TextMeshProUGUIS.Count - 1);
    }

    void AIFollowSpeed()
    {
        if (!IsControlable)
            return;
        if (!Runner.follow)
            return;
       
        Runner.followSpeed += _aiSpeed * Time.deltaTime * 0.1f;
        if (Runner.followSpeed >= PlayerController.Instance.MaxSpeed / 3 )
        {
            Runner.followSpeed = PlayerController.Instance.Runner.followSpeed / 1.3f ;
        }
        
    }

    void CalculateAISpeed()
    {
        _minAiSpeed = PlayerController.Instance.SpeedMultiplier;
        _maxAISpeed = PlayerController.Instance.MaxSpeed / 20;
        _aiSpeed = Random.Range(_minAiSpeed, _maxAISpeed);
    }
    
   

   
    
          
    
}
