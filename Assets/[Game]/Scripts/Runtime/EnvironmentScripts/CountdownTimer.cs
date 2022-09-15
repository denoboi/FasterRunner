using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public static CountdownTimer Instance;
    
    public float CountdownTime { get; private set; }
    public TextMeshPro TMPro;
    
    private const float MAX_CLICKCOUNTDOWN = 3;

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
        CountdownTime = MAX_CLICKCOUNTDOWN;
        StartCoroutine(CountDownCo());
    }


    IEnumerator CountDownCo()
    {
        while (CountdownTime > 0)
        {
            TMPro.gameObject.SetActive(true);
            TMPro.text = CountdownTime.ToString();

            yield return new WaitForSeconds(1);

            CountdownTime--;

            IsCountDowning = true;
        }

        EventManager.OnFirstCountDownEnded.Invoke();
        IsCountDowning = false; // for playercontroller script, in order to allow moving after countdown
        TMPro.text = "Run!";
        yield return new WaitForSeconds(1);
        TMPro.gameObject.SetActive(false);

        
    }
    
}
