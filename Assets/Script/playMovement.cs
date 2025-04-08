using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class playMovement : MonoBehaviour{

    public Rigidbody rb;
    public float sidewaysForce = 50000f; //設定左右移動速度
    public float boundary = 5f;          //設定左右移動範圍

    void Start(){

        rb = GetComponent<Rigidbody>();

        //鎖定旋轉 XZ
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;

    }

    void FixedUpdate(){

        //獲取玩家輸入 (-1 ~ 1)
        float move = Input.GetAxis("Horizontal");

        //直接改變速度 等速移動
        rb.velocity = new Vector3(move * 10f, rb.velocity.y, rb.velocity.z);


        //掉下去結束遊戲
        if (rb.position.y <-1f){

            FindObjectOfType<GameManager1>().EndGame();
        }
    }
}
 