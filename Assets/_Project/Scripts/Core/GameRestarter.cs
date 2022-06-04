using System.Collections.Generic;
using TopViewShooter.Characters;
using UnityEngine;

namespace TopViewShooter.Core
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private List<Health> _healths;

        private void OnEnable()
        {
            foreach (var health in _healths)
            {
                health.Die += Restart;
            }
        }

        private void OnDisable()
        {
            foreach (var health in _healths)
            {
                health.Die -= Restart;
            }
        }

        private void Restart()
        {
            Debug.Log("Restart");
        }
    }
}
