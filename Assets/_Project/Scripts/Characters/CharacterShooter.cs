using TopViewShooter.Shooting;
using UnityEngine;

namespace TopViewShooter.Characters
{
    public class CharacterShooter : MonoBehaviour
    {
        [SerializeField] protected Transform _bulletSpawnPoint;
        [SerializeField] protected BulletsPool _bulletsPool;
        [SerializeField] private float _shootDelay = 0.5f;

        private float timer = 0.0f;

        private void Awake()
        {
            if (!_bulletsPool)
            {
                _bulletsPool = FindObjectOfType<BulletsPool>();
            }

            if (!_bulletsPool)
            {
                Debug.LogError("Cannot find BulletsPool!");
            }
        }

        private void Update()
        {
            timer -= Time.deltaTime;
        }

        public void Shoot()
        {
            if (timer > 0.0f)
            {
                return;
            }
            _bulletsPool.SpawnBullet(_bulletSpawnPoint);
            timer = _shootDelay;
        }
    }
}