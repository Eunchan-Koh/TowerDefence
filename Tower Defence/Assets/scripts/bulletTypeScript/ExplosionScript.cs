using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public float radius;
    public float dmg;
    void Awake()
    {
        
        RadiusSet();
        // DamageSet();
        Invoke("Destroyer", 1.1f);

    }
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.layer == 7){
            collision.gameObject.GetComponent<EnemyMove>().GetDamage(dmg);
        }
        
    }

    public void RadiusSet(){
        radius = 3f;
        transform.localScale = new Vector3(radius*2,radius*2,1);
    }
    // public void DamageSet(){
    //     dmg = 20;
    // }
    public void Destroyer(){
        Destroy(gameObject);
    }
}
