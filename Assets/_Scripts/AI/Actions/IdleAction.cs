using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector2.zero;
        aiMovementData.PointOfInterest = transform.position;
        enemyBrain.EnemyMove(aiMovementData.Direction, aiMovementData.PointOfInterest);
    }
}
