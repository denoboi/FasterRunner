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

        Runner.followSpeed += _aiSpeed * Time.deltaTime * Random.Range(0.05f, 0.1f);
        if (Runner.followSpeed >= PlayerController.Instance.MaxSpeed * Random.Range(0.01f, 5f))
        {
            Runner.followSpeed -= PlayerController.Instance.Runner.followSpeed / Random.Range(10f,100f) ;
        }
        
    }

    void CalculateAISpeed()
    {
        _minAiSpeed = PlayerController.Instance.SpeedMultiplier * Random.Range(3f, 5f);
        _maxAISpeed = PlayerController.Instance.MaxSpeed / Random.Range(40f, 120f);
        _aiSpeed = Random.Range(_minAiSpeed, _maxAISpeed);
    }
    
   

   
    
          
    
}
