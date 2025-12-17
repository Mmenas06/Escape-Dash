using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manuel Mena
public class Playercontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is 

    public float speed = 5;
    private Rigidbody2D rb2d;

    private float move;
    public float jumpForce = 5;
    private bool isGrounded;
    private int jumpCounter;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    private Animator animator;
    private int coins;
    public TMP_Text textCoins;
    public GameObject endMenu;
    private bool isEndMenu;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpCounter = 0;
        isEndMenu = false;
        endMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        if (move != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCounter < 1)) //Salto
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpCounter++;
        }
        
        if (isGrounded) jumpCounter = 0;

        animator.SetBool("isMoving", move > 0.1 || move < -0.1);
        animator.SetFloat("VerticalVelocity", rb2d.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        if (isEndMenu)
        {
            endMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            endMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            textCoins.text = coins.ToString();
        }

        if (collision.gameObject.CompareTag("Spikes"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            isEndMenu = true;
        }
    }
}