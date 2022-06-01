using UnityEngine;
using UnityEngine.InputSystem;

namespace TopViewShooter.Characters
{
    [RequireComponent(typeof(PlayerInput))]
    public sealed class PlayerRotator : CharacterRotator
    {
        private const string LookActionName = "Look";

        private PlayerInput _playerInput;
        private InputActionMap _inputActionMap;
        private InputAction _lookAction;
        private Camera _mainCamera;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _inputActionMap = _playerInput.currentActionMap;
            _lookAction = _inputActionMap.FindAction(LookActionName);
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            _lookAction.performed += OnLookActionPerformed;
        }

        private void OnDisable()
        {
            _lookAction.performed -= OnLookActionPerformed;
        }

        private void OnLookActionPerformed(InputAction.CallbackContext context)
        {
            var rotateTo = _mainCamera.ScreenToWorldPoint(context.action.ReadValue<Vector2>());
            var direction = (rotateTo - transform.position).normalized;
            LookInDirection(direction);
        }
    }
}