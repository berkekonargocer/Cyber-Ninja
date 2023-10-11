using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public abstract class Agent : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public float MovementSpeed { get; private set; } = 5.0f;

        protected CharacterController _agentCharacterController;
        protected Animator _characterAnimator;

        protected Vector3 _movementVelocity;
        protected float _verticalVelocity;
        protected float _gravity;

        protected static readonly int _movementSpeedAnimatorHash = Animator.StringToHash("MovementSpeed");
        protected static readonly int _airborneAnimatorHash = Animator.StringToHash("Airborne");


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected void Awake() {
            SetComponents();
        }

        protected virtual void FixedUpdate() {
            CalculateAgentMovement();
            CalculateAgentRotation();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected virtual void SetComponents() {
            _agentCharacterController = GetComponent<CharacterController>();
            _characterAnimator = GetComponent<Animator>();
            _gravity = Physics.gravity.y * 2;
        }

        protected virtual void CalculateAgentMovement() {

        }

        protected virtual void CalculateAgentRotation() {

        }
    }
}