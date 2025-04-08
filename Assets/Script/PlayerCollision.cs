using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour{

    public playMovement movement;
    public float Delay = 2f;

    void Start(){
        //確保 movement 變數被正確初始化
        if (movement == null){
            movement = GetComponent<playMovement>();
        }
    }

    void OnCollisionEnter(Collision collisionInfo) {

        //處理與障礙物的碰撞
        if (collisionInfo.collider.tag == "obstcal"){

            //停止玩家移動
            movement.enabled = false;
            FindObjectOfType<GameManager1>().EndGame();

            //停止計分
            FindObjectOfType<Score>().StopScoring();
        }

        //如果撞到終點線
        if (collisionInfo.collider.tag == "endLine") {

            Invoke("Completelevel", Delay);
            //停止計分
            FindObjectOfType<Score>().StopScoring();

        }
    }

    //延遲Completelevel UI
    public void Completelevel(){

        FindObjectOfType<GameManager1>().Completelevel();
    }

}

