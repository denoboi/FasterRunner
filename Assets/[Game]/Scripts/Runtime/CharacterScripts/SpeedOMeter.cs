using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using HCB.Core;
using UnityEngine;
using UnityEngine.UI;
using HCB.Utilities;

public class SpeedOMeter : MonoBehaviour
{
    public GameObject Indicator;

    private RectTransform _rectTransform;
    public float Result;

    public const float MAX_ANGLE = 180f;
    public const float MIN_ANGLE = 0f; //eulerangles'lar eksi dereceye dusemiyor.

    private void OnEnable()
    {
        SceneController.Instance.OnSceneLoaded.AddListener(ResetIndicator);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        SceneController.Instance.OnSceneLoaded.RemoveListener(ResetIndicator);
    }


    private void Start()
    {
        _rectTransform = Indicator.GetComponent<RectTransform>();
    }


    private void Update()
    {
        UpdateSliderValue();
    }


    void UpdateSliderValue()
    {
        if (PlayerController.Instance == null)
            return;
        if (Indicator == null || PlayerController.Instance.Runner == null)
            return;
       
        
        float eulerAngleZ = HCBUtilities.Remap(PlayerController.Instance.Runner.followSpeed, 0,
            PlayerController.Instance.MaxSpeed, MIN_ANGLE, MAX_ANGLE); //hiz 0'ken minangle'a 

        float lerpEulerAngleZ = Mathf.Lerp(Indicator.transform.localEulerAngles.z, eulerAngleZ, Time.deltaTime *5);

        Indicator.transform.localEulerAngles = new Vector3(Indicator.transform.localEulerAngles.x,
            Indicator.transform.localEulerAngles.y, lerpEulerAngleZ);
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

    private void ResetIndicator()
    {
        Indicator.transform.localEulerAngles = Vector3.zero;
    }
}