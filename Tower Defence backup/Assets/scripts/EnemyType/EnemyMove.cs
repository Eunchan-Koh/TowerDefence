using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public float hp;
    protected float MaxHp;
    public bool isDead;
    GameObject[] paths;
    public int pathCount;
    public int totalPathCount;
    protected float movementSpeed;
    protected float initialMovementSpeed;
    Rigidbody2D rigid;
    public Vector3 fromPosition;
    public Vector3 toPosition;
    public Slider hpSlider;
    GameManager manager;
    CircleCollider2D colliderCircle;
    bool destroying;
    SpriteRenderer spriteRenderer;
    public Canvas canvas;
    protected int enemyLevel;
    public bool isWet;
    public bool isElectric;
    public bool movable;
    
    // public GameManager manager;
    // public GameManager gameManager;

    void Awake(){
        HpSet();
        MaxHp = hp;
        isDead = false;
        MovementSpeedSet();
        initialMovementSpeed = movementSpeed;
        rigid = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<GameManager>();
        PathSetting();
        enemyLevel = manager.enemyLevel;
        // Debug.Log(totalPathCount);
        colliderCircle = GetComponent<CircleCollider2D>();
        destroying = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isWet= false;
        isElectric = false;
        movable = true;
    }
    void PathSetting(){
        // Debug.Log(manager.paths.Length);
        paths = manager.paths;
        pathCount = 0;
        transform.position = paths[pathCount].transform.position;
        totalPathCount = paths.Length;
    }
    void Update(){

        if(isDead){
            // this.gameObject.SetActive(false);
            DeathCall();
            if(!destroying){
                colliderCircle.enabled = false;
                destroying = true;
                manager.gold+=100;
                spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                canvas.enabled = false;
                // Debug.Log(Time.deltaTime*5);   
            }
            Invoke("Destroyer", Time.deltaTime*5);//giving delay since destroying right away can cause error on towerDetect.cs and laserBullet.cs
        }
        if(pathCount<totalPathCount-1){
            fromPosition = paths[pathCount].transform.position;
            toPosition = paths[pathCount+1].transform.position;
        }else{
            // Debug.Log("called damage!1");
            // gameManager.GetDamage();
            // Debug.Log("called damage!2");
            // Destroy(this.gameObject);
        }
        
        float cur_hp = hp/MaxHp;
        // Debug.Log(cur_hp);
        hpSlider.value = cur_hp;
        if(isWet){
            movementSpeed = initialMovementSpeed * 0.9f;
        }else{
            movementSpeed = initialMovementSpeed;
        }
        if(!GetComponentInChildren<EnemyStruck>()){
                movable = true;
            }else{
                movable = false;
            }
        Movement();
        
        
    }

    void Movement(){
        // rigid.velocity = new Vector2(toPosition.x - transform.position.x, toPosition.y - transform.position.y).normalized*movementSpeed;
        if(movable){
            transform.position =  Vector3.MoveTowards(transform.position, toPosition, Time.deltaTime*movementSpeed);
        }
        if(transform.position == toPosition){
            pathCount++;
        }
    }
    public virtual void HpSet(){
        hp = 100+enemyLevel*50;
    }
    public virtual void GetDamage(float dmg){
        hp -= dmg;
        if(hp<=0){
            isDead = true;
        }
    }
    public virtual void MovementSpeedSet(){
        movementSpeed = 1;
    }
    public void Destroyer(){
        Destroy(this.gameObject);
    }
    public virtual void DeathCall(){

    }
    public void Heal(float amount){
        if(hp+amount>MaxHp){
            hp = MaxHp;
        }else{
            hp += amount;
        }
    }
}
