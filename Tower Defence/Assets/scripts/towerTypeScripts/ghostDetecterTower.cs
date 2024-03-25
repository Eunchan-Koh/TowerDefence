using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostDetecterTower : TowerScript
{
    // Start is called before the first frame update
    public override void SetDamage(){
        dmg = 0;
    }
    public override void SetShootingSpeed(){
        shootingSpeed = 0f;
    }
    public override void GiveDamage(){
        
    }
}
