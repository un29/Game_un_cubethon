using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour{

    void Update(){

        if (transform.position.y < -1f){

            //�^���������l
            gameObject.SetActive(false); 
        }
    }
}
