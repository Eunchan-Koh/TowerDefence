using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotTower : TowerScript
{
    public override void SetDamage(){
        dmg = 8;
    }
    public override void SetShootingSpeed(){
        shootingSpeed = 0.5f;
    }
    public override void GiveDamage(){
        // detection?.primaryEnemy?.enemyObject.GetDamage(dmg);
        if(detection?.primaryEnemy!= null){
            // detection.primaryEnemy.enemyObject.GetDamage(dmg);
            bullet.enemy = detection.primaryEnemy.enemyObject.gameObject;
            Instantiate(bullet, transform.position, Quaternion.identity);
            Invoke("GiveDamage", shootingSpeed);
        }else{
            Invoke("GiveDamage", 0.1f);
        }
    }
}
