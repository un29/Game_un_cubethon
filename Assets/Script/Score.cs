using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour{

    public Transform player;
    public TextMeshProUGUI scoreText;

    public float score1 = 0f;
    public float scoreSpeed = 10f; //每秒加幾分
    private bool isScoring = true;

    void Update (){

        if (isScoring){

            score1 += scoreSpeed * Time.deltaTime;
            scoreText.text = (Mathf.FloorToInt(score1/10).ToString()+"m");
        }
    }

    //停止計分
    public void StopScoring(){

        isScoring = false;
    }


}
