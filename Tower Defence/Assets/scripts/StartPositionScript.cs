using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionScript : MonoBehaviour
{
    public GameManager manager;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 7){
            
        }
    }
}
