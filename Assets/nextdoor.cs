using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YourNamespace;

public class nextdoor : MonoBehaviour
{
    public bool isActive = false;
    // 修改这里的代码，传递场景名称作为参数
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive && collision.CompareTag("Player"))
        {
            isActive = true;
            // 传递场景名称 "Level2"
            Debug.Log("1122");
            DoorToNextLevel.instance.nextLevel("Level2");
            Debug.Log("Player entered the door.");
        }
        else
        {
            Debug.Log("Collision detected, but it's not the player or the player's capsule collider.");
        }
    }
}