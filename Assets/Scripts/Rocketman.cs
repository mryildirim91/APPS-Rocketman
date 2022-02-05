using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketman : MonoBehaviour
{
    [SerializeField] private float _force, _speed;
    [SerializeField] private Stick _stick;
    private Rigidbody _rigidbody;
    
    public static bool IsLaunched { get; private set; }
    public static bool IsFloating { get; private set; }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        EventManager.OnRocketmanLaunched += Launch;
    }

    private void OnDisable()
    {
        EventManager.OnRocketmanLaunched -= Launch;
    }

    private void Update()
    {
        if(GameManager.Instance.IsGameOver) return;
        
        Float();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Ground"))
            GameManager.Instance.GameOver();
    }
    
    private void Launch()
    {
        IsLaunched = true;
        
        if(transform.parent != null)
            transform.SetParent(null);

        _rigidbody.isKinematic = false;
        var direction = new Vector3(0, 1, 0.5f) * _force * _stick.Force;
        _rigidbody.AddForce(direction, ForceMode.Impulse);
    }

    private void Float()
    {
        if(!IsLaunched) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            IsFloating = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            IsFloating = false;
        }
        
        if (IsFloating)
        {
            transform.Translate(transform.forward*Time.deltaTime*_speed);
        }
    }
}
