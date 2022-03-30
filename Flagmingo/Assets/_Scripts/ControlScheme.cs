using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum ControlSchemes
{
    Gamepad,
    KeyboardMouse
}

public class ControlScheme : MonoBehaviour
{
    public ControlSchemes controlScheme;
    private bool schemeIsSet = false;

    [Space(20)]

    [SerializeField] private Text_ControlSchemeDependentDataSO text_XBox;
    [SerializeField] private Text_ControlSchemeDependentDataSO text_KeyboardMouse;

    [field: SerializeField] public UnityEvent<Text_ControlSchemeDependentDataSO> OnSetControlScheme { get; set; }

    public void SetControlScheme(InputAction.CallbackContext context)
    {
        if (!schemeIsSet)
        {
            switch (context.control.name)
            {
                // KEYBOARD & MOUSE
                case "space":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.KeyboardMouse;
                        OnSetControlScheme?.Invoke(text_KeyboardMouse);
                        break;
                    }
                case "position":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.KeyboardMouse;
                        OnSetControlScheme?.Invoke(text_KeyboardMouse);
                        break;
                    }
                case "w":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.KeyboardMouse;
                        OnSetControlScheme?.Invoke(text_KeyboardMouse);
                        break;
                    }
                case "a":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.KeyboardMouse;
                        OnSetControlScheme?.Invoke(text_KeyboardMouse);
                        break;
                    }
                case "s":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.KeyboardMouse;
                        OnSetControlScheme?.Invoke(text_KeyboardMouse);
                        break;
                    }
                case "d":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.KeyboardMouse;
                        OnSetControlScheme?.Invoke(text_KeyboardMouse);
                        break;
                    }

                // GAMEPAD / CONTROLLER
                case "buttonSouth":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.Gamepad;
                        OnSetControlScheme?.Invoke(text_XBox);
                        break;
                    }
                case "rightStick":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.Gamepad;
                        OnSetControlScheme?.Invoke(text_XBox);
                        break;
                    }
                case "leftStick":
                    {
                        schemeIsSet = true;
                        controlScheme = ControlSchemes.Gamepad;
                        OnSetControlScheme?.Invoke(text_XBox);
                        break;
                    }
                default:
                    {
                        schemeIsSet = false;
                        break;
                    }
            }

            Debug.Log(Colorize.Input($"Control Scheme set to: {controlScheme}"));
        }
    }
}
