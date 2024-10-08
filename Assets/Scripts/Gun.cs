using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gun : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _bulletPrefab;

    private Transform _target;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        bool isWork = enabled;
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (isWork)
        {
            var bulletDirection = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + bulletDirection, Quaternion.identity).GetComponent<Rigidbody>();

            newBullet.transform.up = bulletDirection;
            newBullet.velocity = bulletDirection * _speed;

            yield return delay;
        }
    }
}