using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFound{
    public EnemyFound nextEnemy;
    public EnemyMove enemyObject;
    public bool isHead;
    public EnemyFound(EnemyMove enemy, bool head){
        enemyObject = enemy;
        isHead = head;
    }
}

public class TowerDetect : MonoBehaviour
{
    public EnemyFound primaryEnemy;
    public EnemyFound lastEnemy;
    public int enemyCount;
    public EnemyMove curPrimary;
    public bool detectedEnemy;
    public GameObject visualizedCircle;
    CircleCollider2D circleCollider;
    public float radius;
    void Start(){
        enemyCount = 0;
        detectedEnemy = false;
        circleCollider = GetComponent<CircleCollider2D>();
        SetRadius();
    }
    public virtual void SetRadius(){
        radius = 3;
    }
    void Update(){
        if(primaryEnemy != null){
            curPrimary = primaryEnemy.enemyObject;
        }
        circleCollider.radius = radius;
        visualizedCircle.transform.localScale = new Vector3(radius*2,radius*2,1);
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 7){
            if(primaryEnemy == null){//first enemy detected
                primaryEnemy = new EnemyFound(collision.gameObject.GetComponent<EnemyMove>(), true);
                lastEnemy = primaryEnemy;
                Debug.Log("enemy found! " + primaryEnemy.enemyObject);
            }else{//second+ enemy detected
                lastEnemy.nextEnemy = new EnemyFound(collision.gameObject.GetComponent<EnemyMove>(), false);
                lastEnemy = lastEnemy.nextEnemy;
                Debug.Log("extra enemy found! " + lastEnemy.enemyObject);
            }
        }
        
    }
    //assuming - first in first out style game, all enemy has the same speed so second+ enemy never can leave the detected area first than the primary enemy
    void OnTriggerExit2D(Collider2D collision){
        EnemyFound temp = primaryEnemy;
        if(collision.gameObject.layer == 7){//re-target only in case primaryEnemy left
            if(collision?.gameObject == null || primaryEnemy?.enemyObject == null){
                // Debug.Log("collision with: " + collision.gameObject + ", primary Enemy is: " + primaryEnemy.enemyObject);
            }
            if(collision?.gameObject?.GetComponent<EnemyMove>() == primaryEnemy?.enemyObject){//primary enemy left
                // Debug.Log("first enemy left!");
                temp = primaryEnemy.nextEnemy;
                ResetNode(primaryEnemy);
                if(temp!=null){
                    primaryEnemy = temp;
                    primaryEnemy.isHead = true;
                }else{
                    primaryEnemy = null;
                }
            }else{//non-primary target left
                while(temp?.nextEnemy != null && temp?.nextEnemy?.enemyObject != collision?.gameObject.GetComponent<EnemyMove>()){//finding this(temp)->actual collisoin value->next(or null)
                    temp = temp.nextEnemy;
                }
                EnemyFound temp2;
                temp2 = temp?.nextEnemy;
                if(temp2!=null && temp?.nextEnemy?.nextEnemy != null){//error occurs here 보니까 몬스터 체력이 0이 되면 냅다 destroy해버려서 코드 작동 중에 에러나는것 같음, destroy하기 전에 얘는 삭제된다고 신호 주고 그걸 바탕으로 타겟팅 
                                                     //순서 고쳐서 아무도 해당 몬스터를 조준하고 있지 않을 때에 삭제해야 할듯, 그 전에 disable해놓거나 visible inside mask해서 투명으로 만들고
                                                     //----------아니면 적의 숫자가 2(primaryEnemy포함)일때에 문제가 생기는 듯. 지금 쓴 코드는 적의 숫자가 세명 이상일때를 상정했지 두명을 상정하는지는 애매함. 맞는지 체크할것
                                                     //아닌가? 그냥 collider가 사라진게 문제인가 모르겠음. 다만 collider가 사라지면 exit으로 판정나는걸로 앎. 확인 다시 해볼것.
                    temp.nextEnemy= temp.nextEnemy.nextEnemy;
                }else{
                    if(temp!=null){
                        temp.nextEnemy = null;
                    }
                    
                }
                if(temp2!=null){
                    ResetNode(temp2);
                }
                

            }
            // if(primaryEnemy.nextEnemy == null){//only one enemy left and it is leaving
            //     Debug.Log("enemy left! " + primaryEnemy.enemyObject);
            //     primaryEnemy.enemyObject = null;
            //     primaryEnemy.isHead = false;
            //     primaryEnemy = null;
            // }else{//more than one enemy is here and one is leaving
            //     Debug.Log("enemy left! " + primaryEnemy.enemyObject);
            //     EnemyFound temp = primaryEnemy;
            //     primaryEnemy.enemyObject = null;
            //     primaryEnemy.isHead = false;
            //     primaryEnemy = primaryEnemy.nextEnemy;
            //     primaryEnemy.isHead = true;
            //     temp.nextEnemy = null;
            // }
            
        }
    }
    void ResetNode(EnemyFound enemy){
        enemy.nextEnemy = null;
        enemy.enemyObject = null;
        enemy.isHead = false;
    }
}
