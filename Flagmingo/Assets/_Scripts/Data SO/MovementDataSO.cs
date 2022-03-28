using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/Movement Data")]
public class MovementDataSO : ScriptableObject
{
    [Range(1, 10)]
    public float maxSpeed = 5;

    [Range(1, 10)]
    public float flagSpeed = 3;

    [Range(0.1f, 100)]
    public float acceleration = 50, deceleration = 50;
}
