using System.Collections;
using UnityEngine;

namespace MiniFPS
{
    public class EnemyShootController : MonoBehaviour
    {
        [SerializeField]
        private Gun _gun;

        [SerializeField]
        private float _shotPeriodicity;

        private LevelService _levelSystem;
        private Transform _target;

        private void Start()
        {
            _levelSystem = LevelService.Instance;

            _target = _levelSystem.Player;
            StartCoroutine(ShotRoutine());
        }

        private IEnumerator ShotRoutine()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_shotPeriodicity);

                _gun.Shot(_target);
            }
        }
    }
}