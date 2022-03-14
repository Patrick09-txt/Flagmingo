using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/ControlInputs")]
public class PlayerControlInputsSO : ScriptableObject
{
    [Header("Move")]
    [SerializeField] public KeyCode MoveHorizontal;
    [SerializeField] public KeyCode MoveVertical;
}
