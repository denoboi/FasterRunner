using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    public static DistanceCheck Instance;

    private void Awake()
    {
        Instance = this;
    }


    public float CurrentDistance { get; private set; }

    public const float TOTAL_DISTANCE = 5600f;
    private Vector3 _defaultPos;


    private void Start()
    {
        _defaultPos = transform.position;
    }

    private void Update()
    {
        CurrentDistance = Vector3.Distance(_defaultPos, transform.position);
    }
}