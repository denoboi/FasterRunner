using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using HCB.Core;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Runner _runner;
    public Runner Runner => _runner == null ? _runner = GetComponent<Runner>() : _runner;


    private float _speedMultiplier;
    private float _speedDenominator;

    public bool IsControlable { get; set; }

    public float SpeedMultiplier
    {
        get => _speedMultiplier = ClickManager.Instance.Speed;
       
    }

    public float SpeedDenominator
    {
        get => _speedDenominator = ClickManager.Instance.Speed;

        set { _speedDenominator = value; }
    }


    private void OnEnable()
    {
        LevelManager.Instance.OnLevelStart.AddListener(OnLevelStart);
        EventManager.OnFirstCountDownEnded.AddListener(OnCountDownEnded);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        LevelManager.Instance.OnLevelStart.RemoveListener(OnLevelStart);
        EventManager.OnFirstCountDownEnded.RemoveListener(OnCountDownEnded);
    }

    private void OnLevelStart()
    {
        IsControlable = false; //when first countdown player shouldn't move
    }

    private void OnCountDownEnded()
    {
        IsControlable = true;
    }


    private void Update()
    {
        SpeedIncrease();
        SpeedDecrease();
        SpeedDecreaseForGameOver();
    }


    private void SpeedIncrease()
    {
        if (!IsControlable) //oyun basinda
            return;
        if (CountdownTimer.Instance.IsCountDowning)
            return;
        if (!GameManager.Instance.IsGameStarted) return;
        if (Input.GetMouseButtonDown(0))
        {
            Runner.followSpeed += SpeedMultiplier * Time.deltaTime * 2;
            Debug.Log(Runner.followSpeed);
            Debug.Log(SpeedMultiplier);
        }
    }


    private void SpeedDecrease()
    {
        Runner.followSpeed -= SpeedDenominator * Time.deltaTime / 10;
        if (Runner.followSpeed <= 0)
            Runner.followSpeed = 0;
    }

    public void SpeedDecreaseForGameOver()
    {
        //IsOver alabilmek icin ikinci countdown instance yapildi!
        if (!SecondCountdown.Instance.IsOver) 
            return;
        Runner.followSpeed -= SpeedDenominator * Time.deltaTime;
        if (Runner.followSpeed <= 0)
            Runner.followSpeed = 0;
    }

    // public float RunnerSpeed()
    // {
    //     float speed = Runner.followSpeed;
    //     return speed;
    // }
}