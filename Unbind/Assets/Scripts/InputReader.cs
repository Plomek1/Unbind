using System;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Unbind
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Settings/Input Reader", order = 0)]
    public class InputReader : ScriptableObject, InputMapping.IPlayerActions, InputMapping.IUIActions
    {
        public Action<Vector2> PlayerMove;
        public Action<Vector2> PlayerLook;
        public Action PlayerJump;

        public Action PlayerInteract;
        public Action PlayerManageTraits;

        public Action UISubmit;
        public Action UIOpenDevConsole;

        public List<Action> UIBackCallbacks { get; private set; }

        private InputMapping inputActions;

        public void EnablePlayerActions()
        {
            if (inputActions == null)
            {
                inputActions = new InputMapping();
                inputActions.Player.SetCallbacks(this);
                EnableKeyboard();
            }
            inputActions.Enable();
        }

        public void DisablePlayerActions()
        {
            inputActions?.Disable();
        }

        public void EnablePlayerInput() => inputActions.Player.Enable();
        public void DisablePlayerInput() => inputActions.Player.Disable();

        public void EnableUIInput() => inputActions.UI.Enable();
        public void DisableUIInput() => inputActions.UI.Disable();

        public void EnableKeyboard() => InputSystem.EnableDevice(Keyboard.current);
        public void DisableKeyboard() => InputSystem.DisableDevice(Keyboard.current);

        public void ResetCallbacks()
        {
            PlayerMove = null;
            PlayerLook = null;
            PlayerJump = null;

            PlayerInteract = null;
            PlayerManageTraits = null;

            UISubmit = null;
            UIOpenDevConsole = null;
            UIBackCallbacks = new List<Action>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed || context.canceled)
                PlayerMove?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            if (context.performed || context.canceled)
                PlayerLook?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                PlayerJump?.Invoke();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
                PlayerInteract?.Invoke();
        }

        public void OnManageTraits(InputAction.CallbackContext context)
        {
            if (context.performed)
                PlayerManageTraits?.Invoke();
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
        }




        #region User Interface
        public void OnNavigate(InputAction.CallbackContext context)
        {
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            if (context.performed)
                UISubmit?.Invoke();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
        }

        public void OnClick(InputAction.CallbackContext context)
        {
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
        }

        public void OnBack(InputAction.CallbackContext context)
        {
            if (context.performed && UIBackCallbacks.Count > 0)
                UIBackCallbacks[UIBackCallbacks.Count - 1].Invoke();
        }

        public void OnDevConsole(InputAction.CallbackContext context)
        {
            if (context.performed)
                UIOpenDevConsole?.Invoke();
        }
        #endregion
    }
}
