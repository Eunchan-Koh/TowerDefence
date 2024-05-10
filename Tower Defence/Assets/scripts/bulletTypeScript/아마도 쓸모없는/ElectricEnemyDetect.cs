using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricEnemyDetect : MonoBehaviour
{
    public GameObject bullet;
    public ElectricBulletDmg bulletCheck;
    List<GameObject> inContactEnemy;
    CircleCollider2D circleCollider;
    bool calculating;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        inContactEnemy = new List<GameObject>();
        Invoke("CancelCollider", 0.5f);
        calculating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!circleCollider.enabled && !calculating){
            calculating = true;
            // Debug.Log("Successfully disabled!");
            Debug.Log("it has these in list: ");
            foreach(GameObject enemyA in inContactEnemy){
                // enemy.GetComponent<SpriteRenderer>().color = Color.black;
                // Debug.Log(enemy);
                
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 7 && collision.gameObject != bulletCheck.enemy){
            inContactEnemy.Add(collision.gameObject);
            // Debug.Log(collision.gameObject + " has been added!");
            // bullet.enemy
            // Instantiate(bullet, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
    void CancelCollider(){
        circleCollider.enabled = false;
    }
}
