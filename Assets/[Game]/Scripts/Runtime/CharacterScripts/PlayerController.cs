using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using HCB.Core;
using HCB.Utilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private bool _isMouseButtonUp;

    private float _lastMouseUpTime;
    private const float SPEEDDOWN_THRESHOLD = 1.5f;

    private float _speedIncreaseMultiplier = 3;
    public float SpeedIncreaseMultiplier { get; set; }

    public DistanceCheck DistanceCheck;
    public Sprite CharacterIcon;

    private void Awake()
    {
        Instance = this;
    }

    private Runner _runner;
    public Runner Runner => _runner == null ? _runner = GetComponent<Runner>() : _runner;


    public int _directionValue;

    public float MaxSpeed { get; private set; }

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

    private void Start()
    {
        EventManager.OnCharacterSpawned.Invoke(DistanceCheck, CharacterIcon);
    }

    private void OnLevelStart()
    {
        IsControlable = false; //when first countdown player shouldn't move
    }

    private void OnCountDownEnded()
    {
        IsControlable = true;
        MaxSpeed = SpeedMultiplier * (SpeedOMeterTexts.Instance.TextMeshProUGUIS.Count - 1) * SpeedOMeterTexts.SPEED_MULTIPLIER;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _isMouseButtonUp = false;

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
            float speed = Runner.followSpeed + SpeedMultiplier * Time.deltaTime;
            speed = Mathf.Min(speed, MaxSpeed); //speed max'i gecerse max i al

            Runner.followSpeed = speed;
        }
    }


    private void SpeedDecrease()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isMouseButtonUp = true;
            _lastMouseUpTime = Time.time;
        }

        if (!_isMouseButtonUp)
            return;

        float decreaseMultiplier = Time.time > _lastMouseUpTime + SPEEDDOWN_THRESHOLD ? 2f : 0.1f;
        Runner.followSpeed -= decreaseMultiplier * SpeedDenominator * Time.deltaTime;
        if (Runner.followSpeed <= 0)
            Runner.followSpeed = 0;
    }

    public void SpeedDecreaseForGameOver()
    {
        //IsOver alabilmek icin ikinci countdown instance yapildi!
        if (!SecondCountdown.Instance.IsOver)
            return;
        Runner.followSpeed -= SpeedDenominator * Time.deltaTime * 30;
        if (Runner.followSpeed <= 0)
            Runner.followSpeed = 0;
    }
}