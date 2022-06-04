using UnityEngine;

namespace TopViewShooter.Characters
{
    public class CharacterRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1.0f;

        private Vector3 _desiredForward;

        protected virtual void Start()
        {
            _desiredForward = transform.forward;
        }

        protected virtual void Update()
        {
            transform.forward = Vector3.RotateTowards(
                transform.forward,
                _desiredForward,
                _rotationSpeed * Time.deltaTime,
                0.0f);
        }

        public void LookInDirection(Vector3 desiredForward)
        {
            _desiredForward = desiredForward;
            _desiredForward.y = 0.0f;
            _desiredForward.Normalize();
        }
    }
}