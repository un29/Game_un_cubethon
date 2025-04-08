using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstcal : MonoBehaviour
{
    //�ͦ��]�w
    public GameObject obstaclePrefab;    //��J�A�n�ͦ�����ê�� prefab
    public int poolSize = 10;            //�w���ͦ�������ƶq
    public float spawnInterval = 0.8f;   //�C�X��ͦ��@��
    public float spawnDuration = 15f;    //����X��

    //�ͦ���m�]�w
    public float spawnZ = 55f;           //Z �b��m�]�Z�����a�h���^
    public float spawnXRange = 6.2f;     //�H���ͦ��� X �b�d��]���k�^

    //�����P���I�u
    public GameObject endLine;
    public float Delay = 7f;

    private List<GameObject> obstaclePool = new List<GameObject>();
    private float spawnTimer = 0f;
    private bool spawning = true;

    void Start(){

        //�������I�u
        endLine.SetActive(false);

        //�إߪ����
        for (int i = 0; i < poolSize; i++){

            GameObject obj = Instantiate(obstaclePrefab);
            obj.SetActive(false);
            obstaclePool.Add(obj);
        }

        //����ͦ����ɶ��I
        Invoke("StopSpawning", spawnDuration);

        //��ܲ��I�u
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

    //�ͦ�
    void SpawnObstacle(){

        GameObject obj = GetPooledObstacle();
        if (obj != null){

            float randomX = Random.Range(-spawnXRange, spawnXRange);
            Vector3 spawnPosition = new Vector3(randomX, 0.5f, spawnZ);

            obj.transform.position = spawnPosition;
            obj.SetActive(true);
        }

    }

    //�����
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
