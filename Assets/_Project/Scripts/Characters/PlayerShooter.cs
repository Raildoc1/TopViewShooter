using UnityEngine;
using UnityEngine.InputSystem;

namespace TopViewShooter.Characters
{
    [RequireComponent(typeof(PlayerInput))]
    public sealed class PlayerShooter : CharacterShooter
    {
        private const string ShootActionName = "Fire";

        private PlayerInput _playerInput;
        private InputAction _shootAction;

        protected override void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _shootAction = _playerInput.currentActionMap.FindAction(ShootActionName);
        }

        private void OnEnable()
        {
            _shootAction.performed += OnMoveActionPerformed;
        }

        private void OnDisable()
        {
            _shootAction.performed -= OnMoveActionPerformed;
        }

        private void OnMoveActionPerformed(InputAction.CallbackContext context)
        {
            Shoot();
        }
    }
}
