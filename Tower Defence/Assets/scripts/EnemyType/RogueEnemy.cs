using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueEnemy : EnemyMove
{
    public override void HpSet(){
        hp = 50+enemyLevel*25;
    }
    public override void MovementSpeedSet(){
        movementSpeed = 3;
    }
}
