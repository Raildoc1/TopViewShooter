using TopViewShooter.Shooting;
using UnityEngine;

namespace TopViewShooter.Characters
{
    public class CharacterShooter : MonoBehaviour
    {
        [SerializeField] protected Transform _bulletSpawnPoint;
        [SerializeField] protected BulletsPool _bulletsPool;

        protected virtual void Awake()
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

        public void Shoot()
        {
            _bulletsPool.SpawnBullet(_bulletSpawnPoint);
        }
    }
}