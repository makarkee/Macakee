using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fruits : MonoBehaviour
{
    private Text FruitsText;
    //private int Fruits = 0;
    private bool foundCanvas = false;

    void Start()
    {
        // 设置一个标志，表示是否已经找到了 Canvas 下的 Text 组件
        FruitsText = GameObject.Find("retain/Canvas/Text").GetComponent<Text>();
        foundCanvas = FruitsText != null;
        Debug.Log("水果UI " + (FruitsText != null));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!foundCanvas)
        {
            // 如果 Canvas 下的 Text 组件尚未找到，则尝试重新查找
            FruitsText = GameObject.Find("retain/Canvas/Text").GetComponent<Text>();
            foundCanvas = FruitsText != null;
        }

        if (collision.gameObject.CompareTag("Fruits"))
        {
            Destroy(collision.gameObject);
            menulist.score++;
            Debug.Log("Strawberry:" + menulist.score);


            // 确保已经找到了 Canvas 下的 Text 组件后再更新文本内容
            if (foundCanvas)
            {
                FruitsText.text = "Strawberry:" + menulist.score;
            }
            else
            {
                Debug.LogWarning("Canvas Text component not found.");
            }

            // 播放音效
            AudioController.Instance.PlaySfx(AudioController.Instance.strawberry);
        }
    }
}
