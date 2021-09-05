using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private Vector3 _moveDirection;


    private void Start()
    {
        _moveDirection = Vector3.back;  // cos transform.z looks to panzer`s ass :D
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);  // When -transform--> always use Time.deltaTime
    }


    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }

        if (otherCollider.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.forward + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, 1), _bounceRadius);
    }
}
