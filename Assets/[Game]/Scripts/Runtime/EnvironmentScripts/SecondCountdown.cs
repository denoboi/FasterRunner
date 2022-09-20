using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondCountdown : MonoBehaviour
{
    public static SecondCountdown Instance;
   
    public float CountDownTime { get; private set; }

    private const float MAX_COUNTDOWN = 30;

    public TextMeshProUGUI CdownText;
    
    public bool IsOver { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EventManager.OnFirstCountDownEnded.AddListener(StartCountdown);
    }

    private void OnDisable()
    {
        EventManager.OnFirstCountDownEnded.RemoveListener(StartCountdown);

    }

    void StartCountdown()
    {
        //UI bir kez yuklendigi icin.
        CountDownTime = MAX_COUNTDOWN; //Ui bir kez yuklendigi icin. 
        StartCoroutine(CountdownTimerCo());
    }

    private IEnumerator CountdownTimerCo()
    {
        while (CountDownTime > 0)
        {
            IsOver = false;
            float milliseconds = Mathf.FloorToInt(CountDownTime % 1000);
            CdownText.gameObject.SetActive(true);
            CdownText.text = CountDownTime.ToString();
            yield return new WaitForSeconds(1);
            CountDownTime--;
            
        }

        IsOver = true;
        CdownText.gameObject.SetActive(false);
        EventManager.OnSecondCountDownEnded.Invoke();
    }

}
