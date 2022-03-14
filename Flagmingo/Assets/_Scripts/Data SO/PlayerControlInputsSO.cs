using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Player/ControlInputs")]
public class PlayerControlInputsSO : ScriptableObject
{
    [Header("Move")]
    [SerializeField] public InputAction Move;
}
