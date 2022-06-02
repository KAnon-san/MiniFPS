using System.Collections;
using UnityEngine;

namespace MiniFPS
{
    public class Enemy : MonoBehaviour
    {
        private LevelService _levelService;

        private void Start() => _levelService = LevelService.Instance;

        private void OnDestroy() => _levelService.NotifyEnemyRemoved();
    }
}