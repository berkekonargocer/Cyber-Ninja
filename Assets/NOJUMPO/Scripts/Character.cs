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


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            SetComponents();
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void FixedUpdate() {
            CalculateCharacterMovement();
            _playerCharacterController.Move(_movementVelocity);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _playerCharacterController = GetComponent<CharacterController>();
        }

        void CalculateCharacterMovement() {
            _movementVelocity.Set(PlayerInputReader.MoveInput.x, 0.0f, PlayerInputReader.MoveInput.y);
            _movementVelocity.Normalize();
            _movementVelocity = Quaternion.Euler(0, -45.0f, 0) * _movementVelocity;
            _movementVelocity *= MovementSpeed * Time.fixedDeltaTime;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
    }
}