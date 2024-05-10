using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

public class ElectricChainEffect : MonoBehaviour
{
    public CircleCollider2D coll;
    public LayerMask enemyLayer;
    public float dmg;
    public GameObject ElectricChain;
    public GameObject beenStruck;
    public int chainAmount;
    public ParticleSystem parti;
    public Animator anim;

    private GameObject startObject;
    public GameObject endObject;
    public int singleSpawn;

    void Start(){
        if(chainAmount == 0) Destroy(gameObject);
        else Destroy(gameObject, 1.5f);//if nothing happens, destroies itself in 3 sec
        coll = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        startObject = gameObject;
        singleSpawn = 1;
        dmg = 10;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(enemyLayer == (enemyLayer|1<<collision.gameObject.layer)&&!collision.GetComponentInChildren<EnemyStruck>()){
            if(singleSpawn != 0){
                endObject = collision.gameObject;
                chainAmount -= 1;
                endObject.GetComponent<EnemyMove>().GetDamage(dmg);
                if(endObject.GetComponent<EnemyMove>().isWet){
                    Instantiate(ElectricChain, collision.gameObject.transform.position, Quaternion.identity);
                }
                Instantiate(beenStruck, collision.gameObject.transform);
                anim.StopPlayback();
                coll.enabled = false;
                singleSpawn--;
                parti.Play();

                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = startObject.transform.position;
                parti.Emit(emitParams, 1);
                emitParams.position = endObject.transform.position;
                parti.Emit(emitParams, 1);
                Destroy(gameObject, 1f);
            }
        }
    }

}
