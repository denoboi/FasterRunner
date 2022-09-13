using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondCountdown : MonoBehaviour
{
    public float CountDownTime;

    public TextMeshProUGUI CdownText;

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
        StartCoroutine(CountdownTimerCo());
    }

    private IEnumerator CountdownTimerCo()
    {
        while (CountDownTime > 0)
        {
            CdownText.text = CountDownTime.ToString();
            yield return new WaitForSeconds(1);
            CountDownTime--;
            
        }

        
        CdownText.gameObject.SetActive(false);
        EventManager.OnSecondCountDownEnded.Invoke();
    }

}
