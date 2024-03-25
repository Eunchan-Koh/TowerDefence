using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBullet : bulletMove
{
    public ElectricBulletDmg bulletDmg;
    void Start()
    {
        MovementSpeedSet();
        if(enemy!=null){
            targetPos = enemy.transform.position;
        }
        transform.right = (targetPos - towerPos).normalized;
        bulletDmg.enemy = enemy;
        bulletDmg.dmg = dmg;
        // bulletDmg.transform.localScale = new Vector3(Mathf.Sqrt(
        //         Mathf.Pow(Mathf.Abs(enemy.transform.position.x-towerPos.x),2) +
        //         Mathf.Pow(Mathf.Abs(enemy.transform.position.y-towerPos.y),2)
        //                                               ), bulletDmg.transform.localScale.y, 1);
        Invoke("Destroyer", 1f);
    }
    protected override void Update()
    {
        if(enemy!=null&&!enemy.GetComponent<EnemyMove>().isDead){
            targetPos = enemy.transform.position;
            // transform.right = (targetPos - towerPos).normalized;
        }else{
            Destroy(this.gameObject);
        }
        
    }
    public override void OnTriggerEnter2D(Collider2D collision){//enter한 enemy들 싹다 node나 array에 넣어서(array로 만들어도 무관할듯) destroyer에서 destroy되기 전에 array에 있는 enemy들 isElectric값 false로 만들어주기
    //혹은 하나에서 전체 확인하는게 아니라 좌우로 가장 가까운 하나만 체크하는 방식으로, enter에서 값들을 확인 후 array에서 각 enemy들의 위치를 체크, 비교해서 가장 가까이 있는 적 좌우로 하나씩 총 두개 확인해서 그 둘에게만
    //추가로 더 연결되게끔 만들기, 그리고 그 enemy에서 다시 확인후 연결해나가는 방식으로
    
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
