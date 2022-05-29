using UnityEngine;
using UnityEngine.InputSystem;

namespace TopViewShooter.Characters
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMover : CharacterMover
    {
        private const string MoveActionName = "Move";

        private PlayerInput _playerInput;
        private InputActionMap _inputActionMap;

        private InputAction _moveAction;

        protected override void Awake()
        {
            base.Awake();
            _playerInput = GetComponent<PlayerInput>();
            _inputActionMap = _playerInput.currentActionMap;
            _moveAction = _inputActionMap.FindAction(MoveActionName);
        }

        private void OnEnable()
        {
            _moveAction.performed += OnMoveActionPerformed;
            _moveAction.canceled += OnMoveActionCanceled;
        }

        private void OnDisable()
        {
            _moveAction.performed -= OnMoveActionPerformed;
            _moveAction.canceled -= OnMoveActionCanceled;
        }

        private void OnMoveActionPerformed(InputAction.CallbackContext context)
        {
            SetDirection(context.action.ReadValue<Vector2>());
        }

        private void OnMoveActionCanceled(InputAction.CallbackContext context)
        {
            SetDirection(Vector2.zero);
        }
    }
}
