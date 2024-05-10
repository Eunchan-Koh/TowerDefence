using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTower : TowerScript
{
    public override void SetDamage(){
        dmg = 0;
    }
    public override void SetShootingSpeed(){
        shootingSpeed = 1f;
    }
    public override void GiveDamage(){
        
    }
}
