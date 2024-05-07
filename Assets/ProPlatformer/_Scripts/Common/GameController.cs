using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    Vector2 starPos;

   
    private void Start()
    {
        starPos = transform.position;
        transform.position = GameObject.Find("GameStartPoint").transform.position;
        
    }

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
        ResPawn();
    }
    
    private void ResPawn()
    {
        transform.position = starPos;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("ReturnStartScene");
    }
}
