using System;
using TopViewShooter.Characters;
using UnityEngine;

namespace TopViewShooter.Core
{
    public class GameScore : MonoBehaviour
    {
        private int _playerScore = 0;
        private int _enemyScore = 0;

        [SerializeField] private Health PlayerHealth;
        [SerializeField] private Health EnemyHealth;

        public int PlayerScore => _playerScore;
        public int EnemyScore => _enemyScore;

        public event Action ScoreChanged;

        private void Awake()
        {
            PlayerHealth.Die += IncreaseEnemyScore;
            EnemyHealth.Die += IncreasePlayerScore;
        }

        private void OnDestroy()
        {
            PlayerHealth.Die -= IncreaseEnemyScore;
            EnemyHealth.Die -= IncreasePlayerScore;
        }

        private void IncreasePlayerScore()
        {
            _playerScore++;
            ScoreChanged?.Invoke();
        }

        private void IncreaseEnemyScore()
        {
            _enemyScore++;
            ScoreChanged?.Invoke();
        }
    }
}