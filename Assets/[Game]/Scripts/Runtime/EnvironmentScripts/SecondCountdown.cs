using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using TMPro;
using UnityEngine;

public class SecondCountdown : MonoBehaviour
{
    public static SecondCountdown Instance;
    private Coroutine _countDownCoroutine;
    public float CountDownTime { get; set; }

    private const float MAX_COUNTDOWN = 25;

    public TextMeshProUGUI CdownText;
    
    public bool IsOver { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EventManager.OnFirstCountDownEnded.AddListener(StartCountdown);
        LevelManager.Instance.OnLevelFinish.AddListener(ResetCountDown);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnFirstCountDownEnded.RemoveListener(StartCountdown);
        LevelManager.Instance.OnLevelFinish.RemoveListener(ResetCountDown);


    }

    void StartCountdown()
    {
        ResetCountDown();
        //UI bir kez yuklendigi icin.
        CountDownTime = MAX_COUNTDOWN; //Ui bir kez yuklendigi icin. 
       _countDownCoroutine = StartCoroutine(CountdownTimerCo());
    }

    private IEnumerator CountdownTimerCo()
    {
        while (CountDownTime > 0)
        {
            IsOver = false;
           
            CdownText.gameObject.SetActive(true);
            CdownText.text = CountDownTime.ToString();
            yield return new WaitForSeconds(1);
            CountDownTime--;
            
        }

        IsOver = true;
        CdownText.gameObject.SetActive(false);
        EventManager.OnSecondCountDownEnded.Invoke();
    }

    private void ResetCountDown()
    {
        if(_countDownCoroutine != null)
            StopCoroutine(_countDownCoroutine);
        CdownText.gameObject.SetActive(false);
    }

}
