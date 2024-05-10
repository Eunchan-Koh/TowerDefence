using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : TowerScript
{
    public override void SetDamage(){
        dmg = 1000;
    }
    public override void SetShootingSpeed(){
        shootingSpeed = 10f;
    }
    public override void GiveDamage(){
        // detection?.primaryEnemy?.enemyObject.GetDamage(dmg);
        if(detection?.primaryEnemy!= null && jamTime<=0){
            // detection.primaryEnemy.enemyObject.GetDamage(dmg);
            bullet.enemy = detection.primaryEnemy.enemyObject.gameObject;
            Instantiate(bullet, transform.position, Quaternion.identity);
            Invoke("GiveDamage", shootingSpeed);
        }else{
            Invoke("GiveDamage", 0.1f);
        }
    }
}
