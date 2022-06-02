using Newtonsoft.Json.Bson;
using System.Collections;
using UnityEngine;

namespace MiniFPS
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _explosionEffect;

        private float _speed;
        private Vector3 _direction;

        private void FixedUpdate()
        {
            transform.Translate(_direction * _speed);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);

            PlayEffect();
        }

        public void SetSpeed(float speed) => _speed = speed;

        public void SetDirection(Vector3 direction) => _direction = direction;

        private void PlayEffect()
        {
            var effect = Instantiate(_explosionEffect);
            effect.transform.position = transform.position;
            effect.Play();
        }
    }
}