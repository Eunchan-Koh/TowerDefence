using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamExplosion : MonoBehaviour
{
    void Start(){
        Destroy(gameObject,0.2f);
    }
    public LayerMask TowerLayer;
    void OnTriggerEnter2D(Collider2D collision){
        if(TowerLayer == 1<<collision.gameObject.layer){
            Debug.Log("detected towers!!");
            collision.GetComponent<TowerScript>().jamTime = 3;
        }
    }
}
