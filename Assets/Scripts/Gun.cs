using System.Collections;
using UnityEngine;

namespace MiniFPS
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private Transform _shotSource;

        [SerializeField]
        private GameObject _bulletPrefab;

        [SerializeField]
        private float _bulletSpeed = 1f;

        public void Shot(Transform target)
        {
            var bulletDirection = (target.position - _shotSource.position).normalized;

            Shot(bulletDirection);
        }

        public void Shot(Vector3 direction)
        {
            var bullet = Instantiate(_bulletPrefab)
                .GetComponent<Bullet>();
            bullet.transform.position = _shotSource.position;

            bullet.SetSpeed(_bulletSpeed);
            bullet.SetDirection(direction);
        }
    }
}