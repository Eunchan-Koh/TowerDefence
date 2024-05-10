using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyInLaser{
    public GameObject thisEnemy;
    public EnemyInLaser nextEnemy;
    public EnemyInLaser(GameObject enemy){
        thisEnemy = enemy;
        nextEnemy = null;
    }
    public EnemyInLaser(GameObject enemy, EnemyInLaser next){
        thisEnemy = enemy;
        nextEnemy = next;
    }
    public EnemyInLaser(EnemyInLaser next){
        nextEnemy = next;
    }
}
public class laserBullet : bulletMove
{
    public bool canGiveDmg;
    public EnemyInLaser primaryEnemyInLaser;
    void Start()
    {
        MovementSpeedSet();
        canGiveDmg = true;
        if(enemy!=null){
            targetPos = enemy.transform.position;
        }
        transform.right = (targetPos - towerPos).normalized;
        Invoke("GiveDamage", 0.5f);
        Invoke("Destroyer", 2f);
    }
    protected override void Update()
    {
        // if(enemy!=null){
        //     targetPos = enemy.transform.position;
        // }
        
    }
    public override void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 7){
                collision.gameObject.GetComponent<EnemyMove>().GetDamage(dmg);
                if(primaryEnemyInLaser == null){//no one in laser yet, first enemy entered
                    primaryEnemyInLaser = new EnemyInLaser(collision.gameObject);
                }else{//there already is a primary enemy, +2 enemys found
                    EnemyInLaser temp = primaryEnemyInLaser;
                    while(temp.nextEnemy!=null){
                        temp = temp.nextEnemy;
                    }
                    EnemyInLaser temp2 = new EnemyInLaser(collision.gameObject);
                    temp.nextEnemy = temp2;
                }
                
            
            // Destroy(this.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.layer == 7){
            EnemyInLaser temp = primaryEnemyInLaser;
            EnemyInLaser temp2 = temp;
            if(primaryEnemyInLaser.nextEnemy == null){//if there was only one enemy
                primaryEnemyInLaser.thisEnemy = null;
                primaryEnemyInLaser = null;
            }else{//more than two enemy
                //if primary is exiting
                if(primaryEnemyInLaser.thisEnemy == collision.gameObject){
                    primaryEnemyInLaser.thisEnemy = null;
                    EnemyInLaser temp3 =  primaryEnemyInLaser;
                    primaryEnemyInLaser = primaryEnemyInLaser.nextEnemy;
                    temp3.nextEnemy = null;
                }else{//if else is exiting
                    while(collision.gameObject != temp.thisEnemy){//temp2 -> temp = found enemy -> other nodes on next of found enemy
                        temp2 = temp;
                        temp = temp.nextEnemy;
                    }
                    if(temp.thisEnemy != collision.gameObject){
                        Debug.Log("Error! found enemy is not this enemy! line 69, laserBullet.cs");
                    }
                    if(temp2 != temp){
                        temp2.nextEnemy = temp.nextEnemy;
                        temp.thisEnemy = null;
                    }
                }
            
                
                
            }
            
        }
    }

    void GiveDamage(){
        EnemyInLaser temp = primaryEnemyInLaser;
        while(temp!=null && temp.thisEnemy != null){
            temp.thisEnemy.GetComponent<EnemyMove>().GetDamage(dmg);
            temp = temp.nextEnemy;
        }
        
        Invoke("GiveDamage",0.5f);
    }
    public override void MovementSpeedSet(){
        movementSpeed = 0;
    }

    void Destroyer(){
        Destroy(gameObject);
    }
}
