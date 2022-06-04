using System;
using UnityEngine;

namespace TopViewShooter.Characters
{
    public class Health : MonoBehaviour
    {
        public event Action Die;

        public void ApplyDamage()
        {
            Die?.Invoke();
        }
    }
}