using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector3.zero;
        aiMovementData.PointOfInterest = enemyBrain.Target.transform.position;

        enemyBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);

        aiActionData.Attack = true;
        enemyBrain.Attack();
    }
}
