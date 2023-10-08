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
        Animator _playerAnimator;

        Vector3 _movementVelocity;
        float _verticalVelocity;
        float _gravity;

        static readonly int _movementSpeed = Animator.StringToHash("MovementSpeed");


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

            _movementVelocity += Vector3.up * (_verticalVelocity * Time.fixedDeltaTime);

            _playerCharacterController.Move(_movementVelocity);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _playerCharacterController = GetComponent<CharacterController>();
            _playerAnimator = GetComponent<Animator>();
            _gravity = Physics.gravity.y;
        }

        void CalculateCharacterMovement() {
            _movementVelocity.Set(PlayerInputReader.MoveInput.x, 0.0f, PlayerInputReader.MoveInput.y);
            _movementVelocity.Normalize();
            _movementVelocity = Quaternion.Euler(0, -45.0f, 0) * _movementVelocity;
            _movementVelocity *= MovementSpeed * Time.fixedDeltaTime;
            _playerAnimator.SetFloat(_movementSpeed, _movementVelocity.magnitude);
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