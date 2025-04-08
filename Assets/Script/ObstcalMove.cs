using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcalMove : MonoBehaviour{

    public Rigidbody rb;
    public float forwardSpeed = -15f;

    void Start(){ 

        rb = GetComponent<Rigidbody>();

        //鎖定所有旋轉
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate(){

        rb.velocity = new Vector3(0, rb.velocity.y, forwardSpeed);

    }
}
