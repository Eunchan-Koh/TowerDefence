using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammerEnemy : EnemyMove
{
    public GameObject JamExplosion;
    bool called;
    void Start(){
        called = false;
    }
    public override void DeathCall(){
        if(!called){
            Instantiate(JamExplosion, transform.position, Quaternion.identity);
        }
    }
}
