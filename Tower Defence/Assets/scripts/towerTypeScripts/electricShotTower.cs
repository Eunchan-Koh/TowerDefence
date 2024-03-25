using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricShotTower : TowerScript
{
    public override void SetDamage(){
        dmg = 10;
    }
    public override void SetShootingSpeed(){
        shootingSpeed = 1f;
    }
    
}
