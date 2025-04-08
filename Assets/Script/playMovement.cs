using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class playMovement : MonoBehaviour{

    public Rigidbody rb;
    public float sidewaysForce = 50000f; //�]�w���k���ʳt��
    public float boundary = 5f;          //�]�w���k���ʽd��

    void Start(){

        rb = GetComponent<Rigidbody>();

        //��w���� XZ
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;

    }

    void FixedUpdate(){

        //������a��J (-1 ~ 1)
        float move = Input.GetAxis("Horizontal");

        //�������ܳt�� ���t����
        rb.velocity = new Vector3(move * 10f, rb.velocity.y, rb.velocity.z);


        //���U�h�����C��
        if (rb.position.y <-1f){

            FindObjectOfType<GameManager1>().EndGame();
        }
    }
}
 