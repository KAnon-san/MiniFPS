using UnityEditor;
using UnityEngine;

namespace MiniFPS
{
    public class PlayerBullet : Bullet
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.EnemyTag))
            {
                Destroy(other.gameObject);
            }

            base.OnTriggerEnter(other);
        }
    }
}