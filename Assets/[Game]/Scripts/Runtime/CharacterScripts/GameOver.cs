using System;
using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private PlayerController _playerController;
    
    public PlayerController PlayerController
    {
        get
        {
            return _playerController == null ? _playerController = GetComponent<PlayerController>() : _playerController;
        }
    }
    private void OnEnable()
    {
       EventManager.OnSecondCountDownEnded.AddListener(Over);
    }

    private void OnDisable()
    {
        EventManager.OnSecondCountDownEnded.AddListener(Over);
    }

    private void Over()
    {
        PlayerController.Runner.follow = false; //yavasca duracak.
        GameManager.Instance.CompeleteStage(true);
        //Particle
        //Animation
    }

    // IEnumerator OverCo()
    // {
    //     PlayerController.Runner.followSpeed 
    // }
}
