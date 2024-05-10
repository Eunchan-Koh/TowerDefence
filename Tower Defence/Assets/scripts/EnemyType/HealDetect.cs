using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDetect : MonoBehaviour
{
    EnemyMove thisEnemy;
    public LayerMask enemyLayer;
    List<GameObject> enemysInArea;
    public float healAmount;
    CircleCollider2D coll;
    public float radius;
    void Start(){
        thisEnemy = GetComponentInParent<EnemyMove>();
        enemysInArea = new List<GameObject>();
        healAmount = 50;
        coll = GetComponent<CircleCollider2D>();
        radius = 3;
        transform.localScale = new Vector3(radius*2, radius*2, 1);
        Healing();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(enemyLayer == 1<<collision.gameObject.layer){
            // Debug.Log("entered!");
            enemysInArea?.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(enemyLayer == 1<<collision.gameObject.layer){
            // Debug.Log("exited!");
            enemysInArea?.Remove(collision.gameObject);
        }
    }
    void Healing(){
        Debug.Log("healing!");
        thisEnemy.Heal(healAmount);
        foreach(GameObject enemy in enemysInArea){
            enemy?.GetComponent<EnemyMove>()?.Heal(healAmount);
        }
        Invoke("Healing", 3f);
    }
}
