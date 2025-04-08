using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour{

    public GameObject sparks;
    
    void OnCollisionEnter(Collision collisionInfo){

        if (collisionInfo.collider.tag == "obstcal"){

            sparks.gameObject.SetActive(true);
        }
    }
}
