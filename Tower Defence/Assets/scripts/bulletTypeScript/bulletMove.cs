using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    protected Vector3 targetPos;
    protected float movementSpeed;
    public GameObject enemy;
    public Vector3 towerPos;
    public float dmg;
    public bool isBuffed;
    // Start is called before the first frame update
    void Start()
    {
        MovementSpeedSet();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(enemy!=null&&!enemy.GetComponent<EnemyMove>().isDead){
            targetPos = enemy.transform.position;
            Movement();
        }else{
            Destroy(this.gameObject);
        }
        
    }
    public virtual void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 7 && collision.gameObject == enemy){
            enemy.GetComponent<EnemyMove>().GetDamage(dmg);
            Destroy(this.gameObject);
        }
    }
    public virtual void MovementSpeedSet(){
        movementSpeed = 5;
    }
    public virtual void Movement(){
        transform.position = Vector3.MoveTowards(transform.position,targetPos,Time.deltaTime*movementSpeed);
    }
}
