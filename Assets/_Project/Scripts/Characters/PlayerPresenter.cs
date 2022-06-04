using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInputManager = TopViewShooter.Input.PlayerInputManager;

namespace TopViewShooter.Characters
{
    [RequireComponent(typeof(CharacterMover))]
    [RequireComponent(typeof(CharacterRotator))]
    [RequireComponent(typeof(CharacterShooter))]
    [RequireComponent(typeof(PlayerInputManager))]
    public class PlayerPresenter : MonoBehaviour
    {
        private CharacterMover _characterMover;
        private CharacterRotator _characterRotator;
        private CharacterShooter _characterShooter;
        private PlayerInputManager _playerInputManager;
        private Camera _mainCamera;

        private void Awake()
        {
            Debug.Log("Awake");
            _characterMover = GetComponent<CharacterMover>();
            _characterRotator = GetComponent<CharacterRotator>();
            _characterShooter = GetComponent<CharacterShooter>();
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.Init();
            _mainCamera = Camera.main;
        }
        private void OnEnable()
        {
            Debug.Log("OnEnable");
            _playerInputManager.MoveAction.performed += OnMoveActionPerformed;
            _playerInputManager.MoveAction.canceled += OnMoveActionCanceled;
            _playerInputManager.LookAction.performed += OnLookActionPerformed;
            _playerInputManager.ShootAction.performed += OnShootActionPerformed;
        }

        private void OnDisable()
        {
            _playerInputManager.MoveAction.performed -= OnMoveActionPerformed;
            _playerInputManager.MoveAction.canceled -= OnMoveActionCanceled;
            _playerInputManager.LookAction.performed -= OnLookActionPerformed;
            _playerInputManager.ShootAction.performed -= OnShootActionPerformed;
        }

        private void OnMoveActionPerformed(InputAction.CallbackContext context) => _characterMover.SetDirection(context.action.ReadValue<Vector2>());
        private void OnMoveActionCanceled(InputAction.CallbackContext _) => _characterMover.SetDirection(Vector2.zero);
        private void OnShootActionPerformed(InputAction.CallbackContext _) => _characterShooter.Shoot();

        private void OnLookActionPerformed(InputAction.CallbackContext context)
        {
            var rotateTo = _mainCamera.ScreenToWorldPoint(context.action.ReadValue<Vector2>());
            var direction = (rotateTo - transform.position).normalized;
            _characterRotator.LookInDirection(direction);
        }
    }
}