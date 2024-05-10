using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MissileBullet : bulletMove
{
    public GameObject explosion;
    public float explosionDmg;
    protected override void Update()
    {
        explosionDmg = 20*(isBuffed?1.3f:1);
        explosion.GetComponent<ExplosionScript>().dmg = explosionDmg;
        if(enemy!=null&&!enemy.GetComponent<EnemyMove>().isDead){
            targetPos = enemy.transform.position;
            Movement();
        }else{
            Destroy(this.gameObject);
        }
        
        transform.right = (targetPos - transform.position).normalized;
    }
    public override void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 7 && collision.gameObject == enemy){
            enemy.GetComponent<EnemyMove>().GetDamage(dmg);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
