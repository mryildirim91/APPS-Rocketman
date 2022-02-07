using System;
using UnityEngine;

namespace Mryildirim.Core
{
    public class RocketmanAnimation : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");
        private static readonly int Idle = Animator.StringToHash("Idle");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            EventManager.OnRocketmanJumped += () =>
            {
                if(_animator != null)
                    _animator.SetTrigger(Idle);
            };
        }

        private void OnDisable()
        {
            EventManager.OnRocketmanJumped -= () =>
            {
                if(_animator != null)
                    _animator.SetTrigger(Idle);
            };
        }

        private void Update()
        {
            if(GameManager.Instance.IsGameOver) return;
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            if(!RocketmanMovement.IsLaunched && !RocketmanMovement.IsFloating) return;
            if(RocketmanMovement.HasJumped) return;

            if (Input.GetMouseButtonDown(0))
                _animator.SetTrigger(Open);

            if (Input.GetMouseButtonUp(0))
                _animator.SetTrigger(Close);
        }
    }
}

