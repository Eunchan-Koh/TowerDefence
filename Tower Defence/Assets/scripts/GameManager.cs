using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.Mathematics;
using System.CodeDom.Compiler;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject[] enemy;
    public int enemyTypeIndex;
    public GameObject[] paths;
    public Image[] hearts;
    public int playerHp;
    public int gold;
    public Text goldText;
    public bool isDead;
    public GameObject[] tower;
    public GameObject createTile;
    Vector3 resetPos;
    public int stageCount;
    public int enemyLevel;
    public int totalEnemyNum;
    public Button stageStartButton;
    public Text stageText;
    public int curEnemyCount;
    public bool selectingTower;
    public GameObject selectedTower;
    public bool isTowerThere = false;
    public bool isWallThere = false;
    public int TowerGenNum;
    public int totalTowerNum;
    int bossNum;
    int bossGenNum;
    public bool isOnStage = false;
    public Text currentTowerTypeText;
    public GameObject RestartButton;
    // bool checkingTower;
    // public GameObject curCollider;
    // Start is called before the first frame update
    void Awake()
    {
        enemyTypeIndex = 0;
        if(GM == null){
            GM = this;
            // DontDestroyOnLoad(gameObject);
        }else{
            // Destroy(gameObject);
        }
        // Debug.Log("awake is called!");
        playerHp = 3;
        isDead = false;
        resetPos = new Vector3(-13, -4);
        Debug.Log("awake is called! current hp: " + playerHp);
        for(int i = 0; i < playerHp; i++){
            hearts[i].color = new Color(1,1,1,1);
        }
        gold = 100;
        stageCount = 0;
        totalEnemyNum = 0;
        curEnemyCount = 0;
        selectingTower = false;
        // checkingTower = false;
        TowerGenNum = 0;
        totalTowerNum = tower.Length;
        bossNum = 0;
        bossGenNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Horizontal Right")){
            TowerGenNum++;
            if(TowerGenNum>=totalTowerNum){
                TowerGenNum=0;
            }
        }else if(Input.GetButtonDown("Horizontal Left")){
            TowerGenNum--;
            if(TowerGenNum <0){
                TowerGenNum = totalTowerNum-1;
            }
        }
        
            
        // }
        if(Input.GetKeyDown(KeyCode.D)){
            if(selectingTower){
                Debug.Log("selling tower!");
                Destroy(selectedTower);
                selectedTower = null;
                selectingTower = false;
                ResetTimeScale();
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            // Debug.Log("z input");
            // playerHp = 5;
            Instantiate(enemy[enemyTypeIndex]);
        }
        GoldTextCheck();
        CurrentTowerTypeTextCheck();
        MouseCheck();
        
        if(Input.GetMouseButtonDown(0)){
            
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                float x = Mathf.Round(mousePos.x);
                float y = Mathf.Round(mousePos.y);
                Vector2 mousePos2D = new Vector2(x, y);

                RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero,0,LayerMask.GetMask("tower", "selectableWall"));//raycasthit은 한번에 하나만 인식 가능, 전부 하려면 raycastAll사용할 것.
                RaycastHit2D towerHit = Physics2D.Raycast(mousePos2D,Vector2.zero, 0, LayerMask.GetMask("tower", "selectableWall"));
                isTowerThere = false;
                isWallThere = false;
                foreach(RaycastHit2D hit in hits){
                    if(hit.collider != null && hit.collider.gameObject.layer ==6){//tower
                        isTowerThere = true;
                        towerHit = hit;
                    }
                    if(hit.collider != null && hit.collider.gameObject.layer==8){
                        isWallThere = true;
                    }
                }
                //타워를 고른 상태에서 다른곳이나 타워를 클릭하면 집중 해제
                //집중 아닌상태에서 타워를 고를 시 타워에 집중
                if(!selectingTower && isTowerThere){//tower에 집중
                    selectingTower = true;
                    // if(!checkingTower){
                        // checkingTower = true;
                        selectedTower = towerHit.collider.gameObject;
                        selectedTower.GetComponent<showRange>().visibleRange.SetActive(!selectedTower.GetComponent<showRange>().visibleRange.activeSelf);
                        TimeSlow();
                    // }else{
                        // checkingTower = false;
                        // hit.collider.gameObject.GetComponent<showRange>().visibleRange.SetActive(false);
                    // }
                    // curCollider = null;
                
                }else if(!selectingTower && !isTowerThere){//별일 안생김, 바닥에 누른거. 돈 있고 벽에 클릭하면 타워생성됨.
                    // Debug.Log("hiii");
                    if(isWallThere){//wall
                    // curCollider = hit.collider.gameObject;
                    // Debug.Log("hit! "+ hit.collider.gameObject);

                        Vector3 newPos = new Vector3(x,y,0);
                        Debug.Log("mouse clicked! "+newPos);
                        if(gold>=tower[TowerGenNum].GetComponentInChildren<TowerScript>()?.towerPrice){//generate tower
                            gold-=tower[TowerGenNum].GetComponentInChildren<TowerScript>().towerPrice;
                            Instantiate(tower[TowerGenNum], newPos, Quaternion.identity);
                        }
                    }
                
                }else if(selectingTower){//tower에 집중 해제
                    selectingTower = false;
                    selectedTower.GetComponent<showRange>().visibleRange.SetActive(!selectedTower.GetComponent<showRange>().visibleRange.activeSelf);
                    ResetTimeScale();
                    
                    
                }else{//일어나면 안됨, 버그생길 시 나오는 문구
                    Debug.Log("I'm out here!");
                }
                
            
            
        }
        // playerHp--;
        // Debug.Log("hp: "+ playerHp);
    }
    void TimeSlow(){
        Time.timeScale = 0.5f;
    }
    void ResetTimeScale(){
        Time.timeScale = 1f;
    }
    void MouseCheck(){
         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        float x = Mathf.Round(mousePos.x);
        float y = Mathf.Round(mousePos.y);
        Vector2 mousePos2D = new Vector2(x, y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero,0,LayerMask.GetMask("tower", "selectableWall"));
        bool isWallThere1 = false;
        bool isTowerThere1 = false;
        foreach(RaycastHit2D hit in hits){
            if(hit.collider != null && hit.collider.gameObject.layer==8){
                isWallThere1 = true;
            }else if(hit.collider != null && hit.collider.gameObject.layer==6){
                isTowerThere1 = true;
            }
        }
        if(isTowerThere1 || !isWallThere1){
            
            createTile.transform.position = resetPos;
                
            
        }else if(isWallThere1){
            // Debug.Log("on wall!");
            // curCollider = null;
            Vector3 newPos = new Vector3(x,y,0);
            // Debug.Log("without tower!! "+newPos);
            createTile.transform.position = newPos;
            // Instantiate(tower, newPos, Quaternion.identity);
        }
    }
    void GoldTextCheck(){
        goldText.text = "$" + gold.ToString();
    }
    public void GetDamage(){//gamemanager를 프리팹으로 저장한 결과 scene내부의 gamemanager와 프리팹인 gamemanager가 동시존재, scene 안에 있는 gamemanager는 알아서 작동하는데 enemy에
                            //있는 gamemanager가 따로 존재해서 거기에 다른 gamemanager의 getdamage를 불러와서 결과적으로 원치 않는 값이 계산됨.
        // Debug.Log("getDamage is called1! current hp: " + playerHp);
        playerHp--;
        if(playerHp<=0){
            isDead = true;
        }
        // Debug.Log("getDamage is called2! current hp: " + playerHp);
        if(isDead){
            Time.timeScale = 0;
            RestartButton.SetActive(true);
        }else{
            hearts[playerHp].color = new Color(1,1,1,0);
        }
        
        
    }
    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Quit(){
        Application.Quit();
    }
    void CurrentTowerTypeTextCheck(){
        currentTowerTypeText.text = TowerGenNum + 1 + ": " + tower[TowerGenNum].name + " | $" + tower[TowerGenNum].GetComponentInChildren<TowerScript>().towerPrice;
    }
    public void StartStage(){
        if(isOnStage)
            return;

        isOnStage = true;
        curEnemyCount = 0;
        stageCount++;
        if(stageCount%5 == 0){
            bossNum = stageCount/5;
            bossGenNum = 0;
            GenBoss();
        }
        enemyLevel = stageCount/5;
        stageText.text = "Stage " + stageCount.ToString();
        totalEnemyNum = stageCount*stageCount;
        GenEnemy();

    }
    public void GenEnemy(){
        curEnemyCount++;
        Instantiate(enemy[enemyTypeIndex]);
        if(curEnemyCount < totalEnemyNum){
            Invoke("GenEnemy", 1f/(enemyLevel+1)<0.05f?0.05f:1f/(enemyLevel+1));
        }else{
            isOnStage = false;
            CancelInvoke("GenEnemy");
            
        }
    }
    public void GenBoss(){
        bossGenNum++;
        Instantiate(enemy[3]);
        if(bossGenNum < bossNum){
            Invoke("GenBoss", 5f);
        }
    }
    
}
