using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : EnemyMove
{
    public override void HpSet(){
        hp = 200+enemyLevel*100;
    }
    public override void GetDamage(float dmg){
        if(movementSpeed!=0){
            hp -= dmg;
        }else{//if stopped, getting less dmg
            hp -= dmg/3f;
        }
        
        if(hp<=0){
            isDead = true;
        }
    }
    public override void MovementSpeedSet(){
        if(movementSpeed == 0){
            movementSpeed = 0.8f;
            Invoke("MovementSpeedSet",3);
        }else{
            movementSpeed = 0;
            Invoke("MovementSpeedSet", 5);
        }
    }
}
