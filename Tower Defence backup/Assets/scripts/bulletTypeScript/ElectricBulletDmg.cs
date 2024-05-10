using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBulletDmg : bulletMove
{
    public GameObject ElectricChain;
    public override void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 7 && collision.gameObject == enemy){
            // enemy.GetComponent<EnemyMove>().GetDamage(dmg);
            Instantiate(ElectricChain, collision.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
