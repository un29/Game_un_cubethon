using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
// 相機跟隨角色
    public Transform player;
    public Vector3 offset;    // 相機與玩家之間的距離

    void Update(){
        // 相機每幀更新位置
        transform.position = player.position + offset;
    }
}
