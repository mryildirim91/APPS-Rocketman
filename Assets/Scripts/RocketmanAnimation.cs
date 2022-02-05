using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketmanAnimation : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(GameManager.Instance.IsGameOver) return;
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if(!Rocketman.IsLaunched && !Rocketman.IsFloating) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(Open);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetTrigger(Close);
        }
    }
}
