using System;
using UnityEngine;
//Manuel Mena
public class Playercontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is 
    
    private Rigidbody2D rb;
    private float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal, rb.linearVelocity.y);
    }
}
