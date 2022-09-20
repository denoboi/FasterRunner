using System.Collections;
using System.Collections.Generic;
using Dreamteck.Forever;
using HCB.IncrimantalIdleSystem;
using UnityEngine;

public class AISpeedUpgrader : IdleStatObjectBase
{
     private Runner _runner;
    
        public Runner Runner { get { return _runner == null ? _runner = GetComponent<Runner>() : _runner; } }
    
        public override void UpdateStat(string id)
        {
            Runner.followSpeed = (float)IdleStat.CurrentValue + Random.Range(15, 88f);
        }
}
