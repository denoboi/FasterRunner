using System;
using System;
using System.Collections;
using System.Collections.Generic;
using HCB.Core;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private PlayerController _playerController;
    private CharacterAnimation _characterAnimation;

    public CharacterAnimation CharacterAnimation => _characterAnimation == null
        ? _characterAnimation = GetComponentInChildren<CharacterAnimation>()
        : _characterAnimation;
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
        StartCoroutine(OverCo());
    }

    IEnumerator OverCo()
    {
        yield return new WaitForSeconds(1.2f);
        CharacterAnimation.TriggerAnimation("RunningToTurn");
        CharacterAnimation.TriggerAnimation("SambaDance");
        
        GameManager.Instance.CompeleteStage(true);
       
           
    }
}
