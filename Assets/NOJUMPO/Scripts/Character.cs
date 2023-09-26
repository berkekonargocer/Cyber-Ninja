using Nojumpo.InputSystem;
using UnityEngine;

namespace Nojumpo
{
    public class Character : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public float MovementSpeed { get; private set; } = 5.0f;
        [field: SerializeField] public NJInputReaderSO PlayerInputReader { get; private set; }

        CharacterController _playerCharacterController;

        Vector3 _movementVelocity;
        float _verticalVelocity;
        float _gravity;

        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void FixedUpdate() {
            CalculateCharacterMovement();
            CalculateCharacterRotation();

            if (_playerCharacterController.isGrounded == false)
            {
                _verticalVelocity = _gravity;
            }
            else
            {
                _verticalVelocity = _gravity * 0.3f;
            }

            _movementVelocity += _verticalVelocity * Vector3.up * Time.fixedDeltaTime;

            _playerCharacterController.Move(_movementVelocity);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _playerCharacterController = GetComponent<CharacterController>();
            _gravity = Physics.gravity.y;
        }

        void CalculateCharacterMovement() {
            _movementVelocity.Set(PlayerInputReader.MoveInput.x, 0.0f, PlayerInputReader.MoveInput.y);
            _movementVelocity.Normalize();
            _movementVelocity = Quaternion.Euler(0, -45.0f, 0) * _movementVelocity;
            _movementVelocity *= MovementSpeed * Time.fixedDeltaTime;
        }

        void CalculateCharacterRotation() {
            if (_movementVelocity != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(_movementVelocity);
            }
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
    }
}