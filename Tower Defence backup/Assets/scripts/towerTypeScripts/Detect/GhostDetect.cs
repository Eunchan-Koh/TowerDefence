using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetect : MonoBehaviour
{
    public LayerMask ghostLayer;
    public LayerMask enemyLayer;
    public GameObject visualizedCircle;
    public float radius;
    CircleCollider2D circleCollider;
    void Start(){
        circleCollider = GetComponent<CircleCollider2D>();
        SetRadius();
    }
    void Update(){
        circleCollider.radius = radius;
        visualizedCircle.transform.localScale = new Vector3(radius*2,radius*2,1);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(ghostLayer == 1<<collision.gameObject.layer){
            Debug.Log("ghost found!");
            // Debug.Log("collision layer is: " + collision.gameObject.layer);
            // Debug.Log("enemylayer is: " + (int)enemyLayer);
            int temp = enemyLayer;
            int tempCount=0;
            while(temp/2!=0){
                temp/=2;
                tempCount++;
            }
            collision.enabled = false;
            collision.gameObject.layer = tempCount;
            collision.enabled = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(enemyLayer == 1<<collision.gameObject.layer && collision.GetComponent<GhostEnemy>() && !collision.GetComponent<GhostEnemy>().isDead){
            //return the layer to ghost layer
            int temp = ghostLayer;
            int tempCount=0;
            while(temp/2!=0){
                temp/=2;
                tempCount++;
            }
            
            collision.enabled = false;
            collision.gameObject.layer = tempCount;
            // if(!collision.GetComponent<GhostEnemy>().isDead){
            collision.enabled = true; 
            // }
            
        }
    }
    void SetRadius(){
        radius = 5;
    }
}
