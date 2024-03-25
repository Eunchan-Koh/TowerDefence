using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterShotBullet : bulletMove
{
    // Start is called before the first frame update
    void Start()
    {
        MovementSpeedSet();
        if(enemy!=null){
            targetPos = enemy.transform.position;
        }
        transform.right = (targetPos - towerPos).normalized;
        Invoke("Destroyer", 2.3f);
    }

    protected override void Update()
    {
        
        
    }
    public override void OnTriggerEnter2D(Collider2D collision){
        // Debug.Log("aaaaa!");
        // if(collision.gameObject.layer == 7){
        //     collision.gameObject.GetComponent<EnemyMove>().GetDamage(dmg);
        //     collision.gameObject.GetComponent<EnemyMove>().isWet = true;
        //     Debug.Log(collision.gameObject + " is wet!");
        // }
    }
    public override void MovementSpeedSet(){
        movementSpeed = 0;
    }
    public override void Movement(){
        
    }
    public void Destroyer(){
        Destroy(gameObject);
    }
}
