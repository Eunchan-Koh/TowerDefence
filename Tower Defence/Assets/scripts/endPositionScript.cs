using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class endPositionScript : MonoBehaviour
{
    public GameManager manager;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer==7||collision.gameObject.layer == 10){
            manager.GetDamage();
            Destroy(collision.gameObject);
        }
    }
}
