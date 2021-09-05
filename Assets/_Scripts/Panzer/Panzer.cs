using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panzer : MonoBehaviour
{

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _delayBetweenShots;

    private float _timeAfterShot;


    private void Update()
    {
        _timeAfterShot += Time.deltaTime;

        if (Input.GetMouseButton(0))  // Also can read with this touch.
        {
            if (_timeAfterShot > _delayBetweenShots)
            {
                Shoot();
                _timeAfterShot = 0;
            }
        }
    }


    private void Shoot()
    {
        Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
    }

}
