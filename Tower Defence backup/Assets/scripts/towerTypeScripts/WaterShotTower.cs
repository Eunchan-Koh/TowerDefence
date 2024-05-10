using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShotTower : TowerScript
{
    public override void SetDamage(){
        dmg = 10;
    }
    public override void SetShootingSpeed(){
        shootingSpeed = 3f;
    }
    public override void GiveDamage(){
        // detection?.primaryEnemy?.enemyObject.GetDamage(dmg);
        if(detection?.primaryEnemy!= null && jamTime<=0){
            // detection.primaryEnemy.enemyObject.GetDamage(dmg);
            bullet.enemy = detection.primaryEnemy.enemyObject.gameObject;
            bullet.towerPos = towerLocation;
            Instantiate(bullet, transform.position, Quaternion.identity);
            Invoke("GiveDamage", shootingSpeed);
        }else{
            Invoke("GiveDamage", 0.1f);
        }
    }
}
