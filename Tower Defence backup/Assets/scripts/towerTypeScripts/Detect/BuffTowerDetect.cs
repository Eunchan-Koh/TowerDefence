using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTowerDetect : MonoBehaviour
{
    public float buffAmount;
    public GameObject visualizedCircle;
    public float radius;
    CircleCollider2D circleCollider;
    
    void Start(){
        buffAmount = 1.3f;
        circleCollider = GetComponent<CircleCollider2D>();
        SetRadius();
    }
    void Update(){
        circleCollider.radius = radius;
        visualizedCircle.transform.localScale = new Vector3(radius*2,radius*2,1);
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 9){
            TowerScript temp = collision?.gameObject?.GetComponent<TowerScript>();
            if(temp!= null && !temp.isBuffed){
                Debug.Log("entered");
                collision.gameObject.GetComponent<TowerScript>().isBuffed = true;
                collision.gameObject.GetComponent<TowerScript>().dmg = collision.gameObject.GetComponent<TowerScript>().dmg * buffAmount;
            }
        }
    }
    void SetRadius(){
        radius = 5;
    }
}
