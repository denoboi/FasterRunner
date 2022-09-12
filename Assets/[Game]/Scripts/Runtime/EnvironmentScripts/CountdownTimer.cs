using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public static CountdownTimer Instance;
    
    public int CountdownTime;
    public TextMeshProUGUI TMPro;

    public bool IsCountDowning { get; set; }
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        LevelManager.Instance.OnLevelStart.AddListener(StartCountDown);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        LevelManager.Instance.OnLevelStart.RemoveListener(StartCountDown);
    }

    void StartCountDown()
    {
        StartCoroutine(CountDownCo());
    }


    IEnumerator CountDownCo()
    {
        while (CountdownTime > 0)
        {
            TMPro.text = CountdownTime.ToString();

            yield return new WaitForSeconds(1);

            CountdownTime--;

            IsCountDowning = true;
        }

        IsCountDowning = false;
        TMPro.text = "Run!";
        yield return new WaitForSeconds(1);
        TMPro.gameObject.SetActive(false);

        EventManager.OnCountDownEnded.Invoke();
    }
    
}
