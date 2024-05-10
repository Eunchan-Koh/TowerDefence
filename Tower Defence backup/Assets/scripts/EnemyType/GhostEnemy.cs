using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : BasicEnemy
{
    void Start(){
        LayerCheck();
    }
    void LayerCheck(){
        if(gameObject.layer == 7){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }else{
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        }
        Invoke("LayerCheck", 0.1f);
    }
}
