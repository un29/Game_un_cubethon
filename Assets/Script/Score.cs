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
    public float scoreSpeed = 10f; //�C��[�X��
    private bool isScoring = true;

    void Update (){

        if (isScoring){

            score1 += scoreSpeed * Time.deltaTime;
            scoreText.text = (Mathf.FloorToInt(score1/10).ToString()+"m");
        }
    }

    //����p��
    public void StopScoring(){

        isScoring = false;
    }


}
