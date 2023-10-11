using UnityEngine;
using UnityEngine.AI;

namespace Nojumpo.AgentSystem
{
    public class Enemy : Agent
    {
        // -------------------------------- FIELDS ---------------------------------
        Transform _playerTransform;
        NavMeshAgent _enemyNavMeshAgent;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void SetComponents() {
            base.SetComponents();
            _enemyNavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            _playerTransform = GameObject.FindWithTag("Player").transform;
            _enemyNavMeshAgent.speed = MovementSpeed;
        }

        protected override void CalculateAgentMovement() {
            if (Vector3.Distance(_playerTransform.position, transform.position) >= _enemyNavMeshAgent.stoppingDistance)
            {
                _enemyNavMeshAgent.SetDestination(_playerTransform.position);
                _characterAnimator.SetFloat(_movementSpeedAnimatorHash, 0.2f);
            }
            else
            {
                
                _characterAnimator.SetFloat(_movementSpeedAnimatorHash, 0.0f);
            }
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}