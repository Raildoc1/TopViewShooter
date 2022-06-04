using TopViewShooter.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace TopViewShooter.Shooting
{
    public class BulletsPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private BattleField _battleField;

        private IObjectPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Bullet>(
                CreateBullet,
                OnTakeFromPool,
                OnReturnedToPool,
                OnDestroyPoolObject,
                true,
                50,
                200);
        }

        public void SpawnBullet(Transform spawnPoint)
        {
            var bullet = _pool.Get();
            var bulletTransform = bullet.transform;
            bulletTransform.position = spawnPoint.position;
            bulletTransform.forward = spawnPoint.forward;
            bullet.Init(this, _battleField);
        }

        public void Release(Bullet bullet)
        {
            _pool.Release(bullet);
        }

        private Bullet CreateBullet()
        {
            var bullet = Instantiate(
                _bulletPrefab,
                transform.position,
                Quaternion.identity,
                transform);
            return bullet;
        }

        private void OnReturnedToPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnTakeFromPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }
    }
}
