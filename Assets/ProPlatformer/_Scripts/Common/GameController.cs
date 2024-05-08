using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Transform testStartTran;

    public static object Instance { get; internal set; }

    public void SetStartPosition(Vector2 startPosition)
    {
        StartPosition = startPosition;
    }
    Vector2 StartPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Die();

        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Obstacle"))
        {
            Die();
            AudioController.Instance.PlaySfx(AudioController.Instance.die);
        }
    }

    private void Die()
    {
        // ���������λ�������ã������ý�ɫλ��Ϊ������λ��
        if (StartPosition != null)
        {
            ResPawn();
        }
    }


    private void ResPawn()
    {
        //   transform.position = testStartTran.position;
        this.transform.position = Vector3.zero;
        Debug.Log("��������λ��");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("ReturnStartScene");
    }


}
