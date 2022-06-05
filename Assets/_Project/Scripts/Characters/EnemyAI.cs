using UnityEngine;
using UnityEngine.AI;

namespace TopViewShooter.Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CharacterRotator))]
    public class EnemyAI : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Transform _player;
        private CharacterRotator _characterRotator;
        private CharacterShooter _characterShooter;

        private Vector3 PlayerDirection => (_player.position - transform.position).normalized;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _characterRotator = GetComponent<CharacterRotator>();
            _characterShooter = GetComponent<CharacterShooter>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            _characterRotator.LookInDirection(PlayerDirection);
            _agent.SetDestination(_player.position);
            if (SeePlayer())
            {
                _characterShooter.Shoot();
            }
        }

        private bool SeePlayer()
        {
            return SeePlayerFromPoint(transform.position + Vector3.up) &&
                   SeePlayerFromPoint(transform.position + Vector3.up + Vector3.right * 0.1f) &&
                   SeePlayerFromPoint(transform.position + Vector3.up - Vector3.right * 0.1f);
        }

        private bool SeePlayerFromPoint(Vector3 origin)
        {
            var hits = Physics.RaycastAll(origin, PlayerDirection);

            if (hits.Length == 0)
            {
                return false;
            }

            return hits[0].collider.gameObject.CompareTag("Player");
        }
    }
}