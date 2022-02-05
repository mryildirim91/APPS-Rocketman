using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketman : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Stick _stick;
    private Rigidbody _rigidbody;
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

    private void Launch()
    {
        if(transform.parent != null)
            transform.SetParent(null);

        _rigidbody.isKinematic = false;
        var direction = new Vector3(0, 1, 1) * _force * _stick.Force;
        _rigidbody.AddForce(direction, ForceMode.Impulse);
    }
}
