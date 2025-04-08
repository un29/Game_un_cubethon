using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour{

    public playMovement movement;
    public float Delay = 2f;

    void Start(){
        //�T�O movement �ܼƳQ���T��l��
        if (movement == null){
            movement = GetComponent<playMovement>();
        }
    }

    void OnCollisionEnter(Collision collisionInfo) {

        //�B�z�P��ê�����I��
        if (collisionInfo.collider.tag == "obstcal"){

            //����a����
            movement.enabled = false;
            FindObjectOfType<GameManager1>().EndGame();

            //����p��
            FindObjectOfType<Score>().StopScoring();
        }

        //�p�G������I�u
        if (collisionInfo.collider.tag == "endLine") {

            Invoke("Completelevel", Delay);
            //����p��
            FindObjectOfType<Score>().StopScoring();

        }
    }

    //����Completelevel UI
    public void Completelevel(){

        FindObjectOfType<GameManager1>().Completelevel();
    }

}

