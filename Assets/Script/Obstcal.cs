using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstcal : MonoBehaviour
{
    //生成設定
    public GameObject obstaclePrefab;    //拖入你要生成的障礙物 prefab
    public int poolSize = 10;            //預先生成的物件數量
    public float spawnInterval = 0.8f;   //每幾秒生成一次
    public float spawnDuration = 15f;    //持續幾秒

    //生成位置設定
    public float spawnZ = 55f;           //Z 軸位置（距離玩家多遠）
    public float spawnXRange = 6.2f;     //隨機生成的 X 軸範圍（左右）

    //結束與終點線
    public GameObject endLine;
    public float Delay = 7f;

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

    void Update(){

        if (!spawning) return;

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval){

            spawnTimer = 0f;
            SpawnObstacle();
        }
    }

    //生成
    void SpawnObstacle(){

        GameObject obj = GetPooledObstacle();
        if (obj != null){

            float randomX = Random.Range(-spawnXRange, spawnXRange);
            Vector3 spawnPosition = new Vector3(randomX, 0.5f, spawnZ);

            obj.transform.position = spawnPosition;
            obj.SetActive(true);
        }

    }

    //物件池
    GameObject GetPooledObstacle(){

        foreach (GameObject obj in obstaclePool){

            if (!obj.activeInHierarchy)
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
