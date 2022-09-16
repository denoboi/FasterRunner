using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using HCB.Core;
using UnityEngine;
using UnityEngine.UI;

public class SpeedOMeter : MonoBehaviour
{
    public GameObject Indicator;

    private RectTransform _rectTransform;
    public float Result;

    public const float MAX_ANGLE = 95f;
    public const float MIN_ANGLE = -93f;
    
    private void Start()
    {
        _rectTransform = Indicator.GetComponent<RectTransform>();
    }


    private void FixedUpdate()
    {
        UpdateSliderValue();
    }


    void UpdateSliderValue()
    {
        if (PlayerController.Instance == null)
            return;
        if (Indicator == null || PlayerController.Instance.Runner == null)
            return;
        if (PlayerController.Instance.Runner.followSpeed == 0 || PlayerController.Instance.SpeedMultiplier == 0)
            return;
        
        Result = PlayerController.Instance.Runner.followSpeed / PlayerController.Instance.SpeedMultiplier;
        Result = Mathf.Clamp01(Result);

        var localEulerAngles = Indicator.transform.localEulerAngles;
        Vector3 rotateValueZ = new Vector3(localEulerAngles.x, localEulerAngles.y, 95f);
        
        Vector3 rotateValueDefault = new Vector3(localEulerAngles.x, localEulerAngles.y, -93);

        localEulerAngles = Vector3.Lerp(rotateValueDefault, rotateValueZ, (Result * 10f) * Time.deltaTime);
        
        Indicator.transform.localEulerAngles = localEulerAngles;

        Indicator.transform.eulerAngles = new Vector3(Indicator.transform.eulerAngles.x, Indicator.transform.eulerAngles.y, ClampAngle(Indicator.transform.eulerAngles.z, -93f, 95f));

        //Slider.value = PlayerController.RunnerSpeed();
    }

    public static float ClampAngle(float current, float min, float max)
    {
        float dtAngle = Mathf.Abs(((min - max) + 180) % 360 - 180);
        float hdtAngle = dtAngle * 0.5f;
        float midAngle = min + hdtAngle;

        float offset = Mathf.Abs(Mathf.DeltaAngle(current, midAngle)) - hdtAngle;
        if (offset > 0)
            current = Mathf.MoveTowardsAngle(current, midAngle, offset);
        return current;
    }
}