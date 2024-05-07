using Myd.Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBed : MonoBehaviour
{
    public float jumpForce = 20f;

    public float cd=5;

    public float delayTIme = 1;

    DateTime dateTime;


    bool isRead
    {
        get
        {
            TimeSpan span = DateTime.Now - dateTime;
            if (span.Ticks > 0)
            {
                return true;
            }
            return false;
        }
    }

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        dateTime = DateTime.Now;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            if (isRead)
            {
                dateTime = DateTime.Now.AddSeconds(cd);
                Invoke(nameof(Jump),delayTIme);
            }
        }

    }


    private void Jump()
    {
        if (!CheckPlayerStayInUp()) return;
        Debug.Log("µ¯·É");
        anim.SetTrigger("jump");
        Game.Instance.PlayerContrl.PlayerController.Jump(jumpForce);
    }

    private bool CheckPlayerStayInUp()
    {
        return true;
    }



}