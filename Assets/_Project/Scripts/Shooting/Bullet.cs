using TopViewShooter.Characters;
using TopViewShooter.Core;
using UnityEngine;

namespace TopViewShooter.Shooting
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10.0f;

        private Vector3 _velocity = Vector3.zero;
        private Rigidbody _rigidbody;
        private BulletsPool _pool;
        private BattleField _battleField;
        private GameRestarter _gameRestarter;

        private Vector3 Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                _rigidbody.velocity = _velocity;
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!_battleField.IsPositionOnField(transform.position))
            {
                _pool.Release(this);
            }
        }

        public void Init(BulletsPool pool, BattleField battleField, GameRestarter gameRestarter)
        {
            _pool = pool;
            _battleField = battleField;
            _gameRestarter = gameRestarter;
            _gameRestarter.RestartGame += OnGameRestart;
        }

        public void Deinit()
        {
            _gameRestarter.RestartGame -= OnGameRestart;
        }

        public void Setup()
        {
            Velocity = transform.forward * _speed;
        }

        private void OnGameRestart() => TryReturnToPool();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Health>(out var health))
            {
                health.ApplyDamage();
                TryReturnToPool();
                return;
            }

            Velocity = Vector3.Reflect(Velocity, collision.contacts[0].normal);
        }

        private void TryReturnToPool()
        {
            if (gameObject.activeSelf)
            {
                _pool.Release(this);
            }
        }
    }
}
