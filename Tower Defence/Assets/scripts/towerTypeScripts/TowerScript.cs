using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TowerScript : MonoBehaviour
{
    public TowerDetect detection;
    public float attackTimeDelay;
    public float dmg;
    public bulletMove bullet;
    public float shootingSpeed;
    public Vector3 towerLocation;
    public int towerPrice;
    public bool isBuffed;
    public float jamTime;
    
    // Start is called before the first frame update
    void Start()
    {
        isBuffed= false;
        SetDamage();
        SetShootingSpeed();
        GiveDamage();
        
    }

    // Update is called once per frame
    void Update()
    {  
        if(bullet!=null){
            bullet.dmg = dmg;
            bullet.isBuffed = isBuffed;
            towerLocation = transform.position;
            if(detection?.primaryEnemy!=null && detection.primaryEnemy.enemyObject != null){//조준프로세스 - 정확히는 총구 방향 맞추는 작업. 실제 조준은 아니고 그렇게 보이게 하는 작업
                transform.right = (detection.primaryEnemy.enemyObject.transform.position - transform.position).normalized;
                
            }
        }
        if(jamTime>0){
            jamTime -= Time.deltaTime;
        }else{
            jamTime = 0;
        }
        
    }
    public virtual void SetDamage(){
        dmg = 10;
    }
    public virtual void SetShootingSpeed(){
        shootingSpeed = 1f;
    }
    public virtual void GiveDamage(){
        // detection?.primaryEnemy?.enemyObject.GetDamage(dmg);
        if(detection?.primaryEnemy!= null && jamTime<=0){
            // detection.primaryEnemy.enemyObject.GetDamage(dmg);
            bullet.enemy = detection.primaryEnemy.enemyObject.gameObject;
            bullet.towerPos = towerLocation;
            Instantiate(bullet, transform.position, Quaternion.identity);
            Invoke("GiveDamage", shootingSpeed);
        }else{
            Invoke("GiveDamage", 0.1f);
        }
    }
}
