using UnityEngine;
using UnityEngine.Events;

public interface IAgentInput
{
    UnityEvent OnFire { get; set; }
    UnityEvent OnFireStop { get; set; }
    UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    UnityEvent<Vector2> OnPointerPositionChange { get; set; }
}