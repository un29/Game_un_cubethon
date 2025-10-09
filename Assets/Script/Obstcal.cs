using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstcal : MonoBehaviour
{
    //生成設定
    public GameObject obstaclePrefab;    //障礙物
    public int poolSize = 10;            //物件池數量大小
    public float spawnInterval = 0.8f;   //每幾秒生成一次障礙物
    public float spawnDuration = 15f;    //持續生成幾秒

    //生成位置設定
    public float spawnZ = 55f;           //Z軸固定玩家前方位置（距離玩家多遠）
    public float spawnXRange = 6.2f;     //X軸隨機生成範圍（左右）

    //終點線
    public GameObject endLine;
    public float Delay = 7f;             //終點線延遲秒數

    //物件池
    private List<GameObject> obstaclePool = new List<GameObject>();
    private float spawnTimer = 0f;
    private bool spawning = true;       

    void Start(){

        //關閉終點線
        endLine.SetActive(false);

        //建立物件池
        for (int i = 0; i < poolSize; i++){

            GameObject obj = Instantiate(obstaclePrefab);
            obj.SetActive(false);
            obstaclePool.Add(obj);
        }

        //停止生成的時間點
        Invoke("StopSpawning", spawnDuration);

        //顯示終點線
        Invoke("EndLine", Delay);
    }

    //每幀累加時間 間隔生成障礙物
    void Update(){

        if (!spawning) return;

        //計算生成間隔
        spawnTimer += Time.deltaTime;

        //當累積時間 >= 設定間隔時生成障礙物
        if (spawnTimer >= spawnInterval){
            spawnTimer = 0f;
            SpawnObstacle();
        }
    }

    //隨機生成障礙物
    void SpawnObstacle(){

        GameObject obj = GetPooledObstacle();
        if (obj != null){

            float randomX = Random.Range(-spawnXRange, spawnXRange);
            Vector3 spawnPosition = new Vector3(randomX, 0.5f, spawnZ);

            //設定障礙物位置 啟用
            obj.transform.position = spawnPosition;
            obj.SetActive(true);
        }

    }

    //物件池搜尋沒有用到的  (如果都在使用 回傳 nulll)
    GameObject GetPooledObstacle(){

        foreach (GameObject obj in obstaclePool){
            
            //如果這個物件還沒被使用
            if (!obj.activeInHierarchy)
            
                //把它拿出來使用
                return obj;  
        }

        return null;
    }

    void StopSpawning(){

        spawning = false;
    }

    void EndLine(){

        endLine.SetActive(true);
    }
}
