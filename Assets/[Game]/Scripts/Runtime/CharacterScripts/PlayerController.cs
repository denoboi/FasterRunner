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
    

    private float _speedMultiplier = 5f;
    private float _speedDenominator = 0.2f;

    public bool IsControlable { get; set; }


    private void OnEnable()
    {
        LevelManager.Instance.OnLevelStart.AddListener(OnLevelStart);
        EventManager.OnCountDownEnded.AddListener(OnCountDownEnded);
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnLevelStart.RemoveListener(OnLevelStart);
        EventManager.OnCountDownEnded.RemoveListener(OnCountDownEnded);
    }

    private void OnLevelStart()
    {
        IsControlable = false; //baslangicta hareket etmemeliyim.
    }

    private void OnCountDownEnded()
    {
        IsControlable = true;
    }

    public float SpeedMultiplier
    {
        get => _speedMultiplier;
        private set { _speedMultiplier = value; }
    }

    public float SpeedDenominator
    {
        get { return _speedDenominator; }

        set { _speedDenominator = value; }
    }

    private void Update()
    {
        
        SpeedIncrease();
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
            Runner.followSpeed += SpeedMultiplier;
            Debug.Log(Runner.followSpeed);
        }
       
    }

    

    private void SpeedDecrease()
    {
        Runner.followSpeed -= SpeedDenominator * Time.deltaTime;
        if (Runner.followSpeed <= 0)
            Runner.followSpeed = 0;
    }

    public float RunnerSpeed()
    {
        float speed = Runner.followSpeed;
        return speed;
    }

    public void Ezgi()
    {
        Debug.Log("InayiEzgi");
    }
}