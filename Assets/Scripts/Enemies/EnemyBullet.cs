using UnityEditor;
using UnityEngine;

namespace MiniFPS
{
    public class EnemyBullet : Bullet
    {
        [SerializeField]
        private float _pushPower;

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.PlayerTag))
            {
                PushPlayer(other.gameObject);
            }

            base.OnTriggerEnter(other);
        }

        private void PushPlayer(GameObject player)
        {
            var movementController = player.GetComponent<PlayerMovementController>();

            if (!movementController)
                return;

            var pushDirection = movementController.transform.position - transform.position;
            var pushVector = pushDirection.normalized * _pushPower;

            movementController.Push(pushVector);
        }
    }
}