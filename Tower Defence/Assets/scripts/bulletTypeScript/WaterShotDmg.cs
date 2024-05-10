using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShotDmg : MonoBehaviour
{
    public float dmg;
    public bulletMove bullet;
    // Start is called before the first frame update
    void Start()
    {
        dmg = bullet.dmg;
    }
    public void OnTriggerEnter2D(Collider2D collision){
        // Debug.Log("aaaaa!");
        if(collision.gameObject.layer == 7){
            collision.gameObject.GetComponent<EnemyMove>().GetDamage(dmg);
            collision.gameObject.GetComponent<EnemyMove>().isWet = true;
            Debug.Log(collision.gameObject + " is wet!");
        }
    }
}
