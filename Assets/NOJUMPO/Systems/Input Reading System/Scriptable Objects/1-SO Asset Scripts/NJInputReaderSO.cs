using UnityEngine;
using UnityEngine.InputSystem;

namespace Nojumpo.InputSystem
{
    [CreateAssetMenu(fileName = "NewInputReader", menuName = "Nojumpo/Scriptable Objects/Game Input/New Input Reader")]
    public class NJInputReaderSO : ScriptableObject, NJInputActions.IPlayerActions, NJInputActions.IUIActions
    {

#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string _developerDescription = "CREATE ONE FOR EACH PLAYER (e.g. IF THERE ARE TWO PLAYERS CREATE TWO AND BIND THEIR OWN)";

#endif
        // -------------------------------- FIELDS ---------------------------------
        NJInputActions _njInputActions;

        public Vector2 MouseDelta { get; private set; }
        public Vector2 MoveInput { get; private set; }
        
        public delegate void OnMovementInputPressed(Vector2 movementVector);
        public OnMovementInputPressed onMovementInputPressed;
        
        public delegate void OnInteractionInputPressed();
        public event OnInteractionInputPressed onInteractionInputPressed;
        
        public delegate void OnInteractionInputReleased();
        public event OnInteractionInputReleased onInteractionInputReleased;
        
        public delegate void OnJumpInputPressed();
        public event OnJumpInputPressed onJumpInputPressed;
        
        public delegate void OnJumpInputReleased();
        public event OnJumpInputReleased onJumpInputReleased;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
            if (_njInputActions == null)
            {
                _njInputActions = new NJInputActions();

                _njInputActions.Player.SetCallbacks(this);
                _njInputActions.UI.SetCallbacks(this);

                SetPlayerInput();
            }
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void OnMove(InputAction.CallbackContext context) {
            MoveInput = context.ReadValue<Vector2>();
            onMovementInputPressed?.Invoke(MoveInput);
        }

        public void OnLook(InputAction.CallbackContext context) {
            MouseDelta = context.ReadValue<Vector2>();
        }

        public void OnInteractButton(InputAction.CallbackContext context) {
            if (context.phase == InputActionPhase.Performed)
            {
                onInteractionInputPressed?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                onInteractionInputReleased?.Invoke();
            }
        }

        public void OnResumeGame(InputAction.CallbackContext context) {
            // throw new System.NotImplementedException();
        }

        public void SetPlayerInput() {
            _njInputActions.UI.Disable();
            _njInputActions.Player.Enable();
        }

        public void SetUIInput() {
            _njInputActions.Player.Disable();
            _njInputActions.UI.Enable();
        }

        public void SetInspectionInput() {
            _njInputActions.Player.Disable();
            _njInputActions.UI.Disable();
        }
    }
}
