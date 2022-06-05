using UnityEngine;

namespace TopViewShooter.Characters
{
    public class EnemyRespawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        public void Respawn()
        {
            transform.position = _spawnPoint.position;
        }
    }
}