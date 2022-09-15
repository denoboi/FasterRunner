using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;

    public Animator Animator => _animator == null ? _animator = GetComponent<Animator>() : _animator;

    private PlayerAnimationSpeed _playerAnimationSpeed;

    public PlayerAnimationSpeed PlayerAnimationSpeed => _playerAnimationSpeed == null
        ? _playerAnimationSpeed =  GetComponentInParent<PlayerAnimationSpeed>()
        : _playerAnimationSpeed;

    public void SetSpeed(string id,float value)
    {
        Animator.SetFloat(id, value);
    }

    private void Update()
    {
       SetSpeed("Speed", PlayerAnimationSpeed.CurrentSpeed);
    }

    public void TriggerAnimation(string animname)
    {
        Animator.SetTrigger(animname);
    }
}
