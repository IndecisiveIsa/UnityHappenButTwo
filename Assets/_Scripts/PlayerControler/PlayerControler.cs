using System;
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
    public Text scoreText;


    public float Speed = 15f;
    public float acceleration = 25f;
    public float jumpForce = 25;
    public Vector3 maxVel = new Vector3(5, 0, 5);
    public Vector3 lastVelocity;
    public Vector3 accelerationr;

    //variables for jumping
    public bool grounded = true;
    public LayerMask groundMask;
    public Transform groundCheck;
    private float groundDistance = .1f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        StartCoroutine(HandleMove());
        StartCoroutine(HandleJump());
    }

    private IEnumerator HandleMove()
    {

        float x = InputManager.instance.move.x;
        float y = InputManager.instance.move.y;
        Vector3 movement = new Vector3(x, 0, y);
        while (InputManager.instance.movePressed)
        {
            rb.AddForce(movement * Speed);
               Debug.Log(rb.velocity);
            yield return new WaitForSeconds(25f);
        }
        /* if (rb.velocity != maxVel)
            {
               lastVelocity = rb.velocity;
               accelerationr = (rb.velocity - lastVelocity) / Time.fixedDeltaTime;
               rb.AddForce(movement+lastVelocity*3/2);
            yield return new WaitForSeconds(25f);
               } */
    }


    private IEnumerator HandleJump()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (InputManager.instance.jumpPressed&&grounded)
        {
            rb.AddForce(0, jumpForce, 0);
            yield return new WaitForSeconds(1);
            if (InputManager.instance.jumpPressed)
            {
                rb.AddForce(0, jumpForce, 0);
                yield return new WaitForSeconds(1/2);
                while (grounded == false)
                {
                    if (InputManager.instance.jumpPressed)
                    {
                        rb.AddForce(0, jumpForce, 0);
                    }
                    yield return new WaitForSeconds(1/2);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score: " + score;

            coinsRemaining--;

            if(coinsRemaining == 0)
            {
                SceneSwitcher.instance.ChangeScene();
            }
        }
    }
}
