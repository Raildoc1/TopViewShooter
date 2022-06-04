using TopViewShooter.Core;
using UnityEngine;

namespace TopViewShooter.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class CharacterMover : MonoBehaviour
    {
        [SerializeField] private BattleField _battleField;
        [SerializeField] private float _speed = 0.5f;

        private CharacterController _characterController;
        private Vector3 _direction;

        protected virtual void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        protected void SetDirection(Vector2 direction)
        {
            _direction = new Vector3(direction.x, 0.0f, direction.y).normalized;
        }

        protected void Update()
        {
            Move();
        }

        private void Move()
        {
            _characterController.Move(_direction * _speed * Time.deltaTime);
            transform.position = _battleField.ClampOnFieldPosition(transform.position);
        }
    }
}