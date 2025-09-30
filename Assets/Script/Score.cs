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
    public Transform endLine;         //終點線位置
       
    private bool isScoring = true;    //是否計分

    void Update (){

        if (isScoring){

            //計算玩家到終點距離
            float distance = endLine.position.z - player.position.z;

            //避免顯示負數
            distance = Mathf.Max(0, distance);

            scoreText.text = Mathf.FloorToInt((distance - 11)/10).ToString() + "m";
        }
    }

    //停止計分
    public void StopScoring(){

        isScoring = false;
    }


}
