using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossEnemy : EnemyMove
{
    public override void HpSet(){
        hp = 5000;
    }
    public override void GetDamage(float dmg){
        hp -= dmg;
        if(hp<=0){
            isDead = true;
        }
    }
    public override void MovementSpeedSet(){
        movementSpeed = 0.8f;
    }
}
