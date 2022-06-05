using TopViewShooter.Core;
using UnityEngine;

namespace TopViewShooter.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private BattleField _battleField;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _speed = 0.5f;

        private CharacterController _characterController;
        private Vector3 _direction;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = new Vector3(direction.x, 0.0f, direction.y).normalized;
        }

        public void Setup()
        {
            _characterController.enabled = false;
            transform.position = _spawnPoint.position;
            _characterController.enabled = true;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _characterController.Move(_direction * _speed * Time.deltaTime);
            var position = transform.position;
            position = _battleField.ClampOnFieldPosition(position);
            position.y = 0.0f;
            transform.position = position;
        }
    }
}