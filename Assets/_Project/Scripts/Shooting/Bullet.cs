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

        public void Init(BulletsPool pool, BattleField battleField)
        {
            _pool = pool;
            Velocity = transform.forward * _speed;
            _battleField = battleField;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _pool.Release(this);
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                _pool.Release(this);
            }

            Velocity = Vector3.Reflect(Velocity, collision.contacts[0].normal);
        }
    }
}
