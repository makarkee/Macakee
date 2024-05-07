using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1.5f;
    [SerializeField] private float destroyDelay = 1.5f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name+"    "+collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Åö×²Íæ¼Ò¡£¡£¡£¡£");
            StartCoroutine(Fall());
        }

    }

    private IEnumerator Fall()
    {
        Debug.Log("ÏÂÂä");
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject,destroyDelay);
    }
}
