using TopViewShooter.Core;
using UnityEngine;

namespace TopViewShooter.Characters
{
    public class EnemyPresenter : MonoBehaviour
    {
        [SerializeField] private GameRestarter _gameRestarter;
        [SerializeField] private EnemyRespawner _enemyRespawner;

        private void Awake()
        {
            _gameRestarter.RestartGame += OnGameRestart;
        }

        private void OnDestroy()
        {
            _gameRestarter.RestartGame -= OnGameRestart;
        }

        private void OnGameRestart() => _enemyRespawner.Respawn();
    }
}