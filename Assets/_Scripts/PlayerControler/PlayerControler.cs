﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    //the physical component of the object
    Rigidbody rb;

    public int score;
    public int coinsRemaining;
    public int coinsCollected;
    public Text scoreText;

    public Vector3 respawnPoint;
    private Vector3 addO;
    private List<GameObject> collectedItems = new List<GameObject>();


    public float Speed = 15f;
    public float acceleration = 25f;
    public float jumpForce = 25;
    public Vector3 maxVel = new Vector3(5, 0, 5);
    public Vector3 lastVelocity;
    public Vector3 accelerationr;


    //variables for jumping
    public bool grounded = true;
    public bool canDoubleJ = false;
    public int extraJumps = 0;
    public bool jTiming = false;
    public LayerMask groundMask;
    public Transform groundCheck;
    private float groundDistance = .1f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = rb.position;
    }

    private void FixedUpdate()
    {

        HandleMove();
        StartCoroutine(HandleJump());
    }

    private void HandleMove()
    {

        float x = InputManager.instance.move.x;
        float y = InputManager.instance.move.y;
        Vector3 movement = new Vector3(x, 0, y);
        rb.AddForce(movement * Speed);
    }


    private IEnumerator HandleJump()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (InputManager.instance.jumpPressed&&grounded)
            //base jump
        {
            jTiming = false;
            rb.AddForce(0, jumpForce, 0);
            canDoubleJ = true;
            yield return new WaitForSeconds(0.25f);
            jTiming = true;
        }
        if (!grounded && InputManager.instance.jumpPressed&&jTiming)
            //extra jump(s)
            {
            if (canDoubleJ)
            {
                jump();
                canDoubleJ = false;
                jTiming = false;
                yield return new WaitForSeconds(0.25f);
                jTiming = true;
            }else if (extraJumps > 0)
            {
                jump();
                jTiming = false;
                extraJumps--;
                yield return new WaitForSeconds(0.25f);
                jTiming = true;
            }
        }
    }

    private void jump()
    {
        Vector3 ZeroY = rb.velocity;
        ZeroY.y = 0;
        rb.velocity = ZeroY;
        rb.angularVelocity = ZeroY;
        rb.AddForce(0, jumpForce * 2, 0);
    }


    private Vector3 flipY;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            collectedItems.Add(other.gameObject);
            other.gameObject.SetActive(false);
            score++;
            coinsCollected++;
            scoreText.text = "Score: " + score;

            coinsRemaining--;

            if(coinsRemaining == 0)
            {
                SceneSwitcher.instance.ChangeScene();
            }
        }
        if (other.CompareTag("Respawn"))
        {
            
            score -= coinsCollected;
            coinsRemaining += coinsCollected;
            coinsCollected = 0;
            scoreText.text = "Score: " + score;
            for(int i = 0; i < collectedItems.Count; i++)
            {
                collectedItems[i].SetActive(true);
            }

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            transform.position = respawnPoint;
            
        }
        if (other.CompareTag("Checkpoint"))
        {
            addO = new Vector3(other.transform.position.x, other.transform.position.y+(1/2), other.transform.position.z);
            respawnPoint = addO;

        }
        if (other.CompareTag("JumpPower"))
        {
            collectedItems.Add(other.gameObject);
            other.gameObject.SetActive(false);
            extraJumps++;

        }
    }
}
