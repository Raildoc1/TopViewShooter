using UnityEngine;

namespace TopViewShooter.Core
{
    public class BattleField : MonoBehaviour
    {
        [SerializeField] private float _fieldWidth = 35.0f;
        [SerializeField] private float _fieldHeight = 35.0f;

        public float FieldWidth => _fieldWidth;
        public float FieldHeight => _fieldHeight;

        public Vector3 ClampOnFieldPosition(Vector3 position)
        {
            var fieldPosition = transform.position;
            var clampedX = Mathf.Clamp(position.x, fieldPosition.x - _fieldWidth * 0.5f, fieldPosition.x + _fieldWidth * 0.5f);
            var clampedZ = Mathf.Clamp(position.z, fieldPosition.z - _fieldHeight * 0.5f, fieldPosition.z + _fieldHeight * 0.5f);
            return new Vector3(clampedX, position.y, clampedZ);
        }

        public bool IsPositionOnField(Vector3 position)
        {
            var fieldPosition = transform.position;

            if (position.x < fieldPosition.x - _fieldWidth * 0.5f || position.x > fieldPosition.x + _fieldWidth * 0.5f)
            {
                return false;
            }

            if (position.z < fieldPosition.z - _fieldHeight * 0.5f || position.z > fieldPosition.z + _fieldHeight * 0.5f)
            {
                return false;
            }

            return true;
        }

#if UNITY_EDITOR
        [Header("Debug")]
        [SerializeField] private float _debugFieldBoundHeight = 5.0f;

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(
                transform.position + Vector3.up * _debugFieldBoundHeight * 0.5f,
                new Vector3(_fieldWidth, _debugFieldBoundHeight, _fieldHeight)
                );
        }
#endif
    }
}