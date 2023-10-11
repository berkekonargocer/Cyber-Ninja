using Nojumpo.InputSystem;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Player : Agent
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public NJInputReaderSO PlayerInputReader { get; private set; }

        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        protected override void FixedUpdate() {
            base.FixedUpdate();
            ApplyPlayerMovement();
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

        
        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        protected override void CalculateAgentMovement() {
            _movementVelocity.Set(PlayerInputReader.MoveInput.x, 0.0f, PlayerInputReader.MoveInput.y);
            _movementVelocity.Normalize();
            _movementVelocity = Quaternion.Euler(0, -45.0f, 0) * _movementVelocity;
            _movementVelocity *= MovementSpeed * Time.fixedDeltaTime;
            
            _characterAnimator.SetFloat(_movementSpeedAnimatorHash, _movementVelocity.magnitude);
            _characterAnimator.SetBool(_airborneAnimatorHash, !_agentCharacterController.isGrounded);
        }

        protected override void CalculateAgentRotation() {
            if (_movementVelocity != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(_movementVelocity);
            }
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ApplyPlayerMovement() {
            if (_agentCharacterController.isGrounded == false)
            {
                _verticalVelocity = _gravity;
            }
            else
            {
                _verticalVelocity = _gravity * 0.3f;
            }

            _movementVelocity += Vector3.up * (_verticalVelocity * Time.fixedDeltaTime);

            _agentCharacterController.Move(_movementVelocity);
        }
    }
}