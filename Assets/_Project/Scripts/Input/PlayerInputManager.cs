using UnityEngine;
using UnityEngine.InputSystem;

namespace TopViewShooter.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputManager : MonoBehaviour
    {
        private const string ShootActionName = "Fire";
        private const string MoveActionName = "Move";
        private const string LookActionName = "Look";

        private PlayerInput _playerInput;

        public InputAction LookAction { get; private set; }
        public InputAction MoveAction { get; private set; }
        public InputAction ShootAction { get; private set; }

        public void Init()
        {
            _playerInput = GetComponent<PlayerInput>();
            MoveAction = _playerInput.currentActionMap.FindAction(MoveActionName);
            ShootAction = _playerInput.currentActionMap.FindAction(ShootActionName);
            LookAction = _playerInput.currentActionMap.FindAction(LookActionName);
        }
    }
}
